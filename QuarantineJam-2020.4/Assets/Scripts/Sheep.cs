using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [HideInInspector] public bool IsItInTheFarm;
    [HideInInspector] public bool IsItMoving;
    [HideInInspector] public Transform TargetMovingTo;
    [SerializeField] private int helthNumber = 3;//how many times should we hit the sheep to hunt
    
    [SerializeField] private int foodAfterHunt = 3;//number of the recorces that you gonna git if you hunted the sheep;
    [SerializeField] private float secToMoveSheepAround = 5;
    [SerializeField] private Transform patrolPoitsParent;

    private Transform[] petrolPoints;
    private Animator animator;
    private AIDestinationSetter destinationSetter;
    private bool isPatroling;
    private AudioManager audioManager;
    [SerializeField] private float hitsTakenCounter;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        isPatroling = false;
        petrolPoints = new Transform[patrolPoitsParent.childCount];

        for (int i = 0; i < patrolPoitsParent.childCount; i++)
        {
            petrolPoints[i] = patrolPoitsParent.GetChild(i);
        }

        destinationSetter = GetComponent<AIDestinationSetter>();
        IsItInTheFarm = false;
        hitsTakenCounter = 0;
        animator = GetComponent<Animator>();
    }

    
    public void AddPower(int powerValue){
        helthNumber += powerValue;
        foodAfterHunt += (int)(powerValue * 1.5f);
    }
    
    // Update is called once per frame
    void Update()
    {
        //if (transform.position == TargetMovingTo.position)
        //{
        //    IsItMoving = false;
        //}

        if (!isPatroling && IsItInTheFarm)
        {
            isPatroling = true;
            StartCoroutine(PetrolAround());
        }
        animator.SetFloat("Rotation", transform.rotation.z);
    }

//    public IEnumerator PreduceRecources()
//    {
//        while (isItInTheFarm)
//        {
//            yield return new WaitForSeconds(60 / numOfRecorcesPreducePerMinute);
//            if (isItInTheFarm)
//            {
//                EventsSystem.OnUpdateResourcesCount(1);
//            }
//        }
//    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            hitsTakenCounter+= collision.GetComponent<Weapon>().damageValue;

            if (hitsTakenCounter >= helthNumber)
            {
                ResourcesManager.Instance.EarnFood(foodAfterHunt);
                audioManager.PlaySheepDiedAudio();
                Destroy(gameObject);
            }
        }
        else if (collision.tag == "Farm")
        {
            
            if(SheepFarm.Instance.AddSheep()){
                SheepFarm.Instance.SheepQueue.Enqueue(gameObject);
                IsItInTheFarm = true;
            }
            else Destroy(gameObject);
//            StartCoroutine(PreduceRecources());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Farm")
        {
            IsItInTheFarm = false;
//            StopCoroutine(PreduceRecources());
        }
    }



    public IEnumerator PetrolAround()
    {
        int randomPatrolPosition = Random.Range(0, petrolPoints.Length);
        Transform patrolTrans = petrolPoints[randomPatrolPosition];
        destinationSetter.target = patrolTrans;
        TargetMovingTo = patrolTrans;
        yield return new WaitForSeconds(secToMoveSheepAround);
        isPatroling = false;
    }
}
