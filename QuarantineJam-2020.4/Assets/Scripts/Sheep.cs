using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{

    [SerializeField] private int helthNumber;//how many times should we hit the sheep to hunt
    [SerializeField] private int foodAfterHunt = 3;//number of the recorces that you gonna git if you hunted the sheep;
    
    private bool isItInTheFarm;
    private Animator animator;
    private float hitsTakenCounter;

    private void Start()
    {
        isItInTheFarm = false;
        hitsTakenCounter = 0;
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
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
            hitsTakenCounter++;
            if (hitsTakenCounter >= helthNumber)
            {
                ResourcesManager.Instance.EarnFood(foodAfterHunt);
                Destroy(gameObject);
            }
        }
        else if (collision.tag == "Farm")
        {
            isItInTheFarm = true;
            SheepFarm.Instance.AddSheep();
//            StartCoroutine(PreduceRecources());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Farm")
        {
            isItInTheFarm = false;
//            StopCoroutine(PreduceRecources());
        }
    }
}
