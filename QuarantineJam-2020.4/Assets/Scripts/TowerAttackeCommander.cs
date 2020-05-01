using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackeCommander : MonoBehaviour
{
    [HideInInspector] public bool IsAttacking;

    [SerializeField] private Tower tower;
    [SerializeField] private Transform weaponPrefab;//the weapon that we are going to hunt the animals with
    [SerializeField] private float numOfArrowsPerMinute;//the number of arrows that we are going to shoot in one minut
    [SerializeField] private Transform weaponPosition;

    private bool hasToTargetWantedAnimal;
    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        IsAttacking = false;
        hasToTargetWantedAnimal = true;

        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(bool hasToTargetWantedAnimal)//if true then target the WantedAnimal else target the NotWantedAnimal
    {
        target = null;
        this.hasToTargetWantedAnimal = hasToTargetWantedAnimal;
        IsAttacking = false;
    }

    public IEnumerator Shoot()
    {
        while (true)
        {
            if (target != null)
            {
                Transform weaponObj = Instantiate(weaponPrefab, weaponPosition.position, weaponPrefab.rotation);
                Weapon weapon = weaponObj.GetComponent<Weapon>();
                weapon.target = this.target;
            }
           
            yield return new WaitForSeconds(60 / (numOfArrowsPerMinute * tower.NumOfHuntersInTheTower));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!IsAttacking)
        {
            if (hasToTargetWantedAnimal)
            {
                if (collision.tag == "WantedAnimal")
                {
                    target = collision.transform;
                    //EventsSystem.OnTargetEnter(target);
                    IsAttacking = true;
                    print("Entered");
                    //give shoot command to the hunters to hunt WantedAnimal
                }
            }
            else
            {
                if (collision.tag == "NotWantedAnimal")
                {
                    target = collision.transform;
                    //EventsSystem.OnTargetEnter(target);
                    IsAttacking = true;
                    //print("Entered");
                    //give shoot command to the hunters to hunt NotWantedAnimal
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (target != null)
        {
            if (collision.gameObject == target.gameObject)
            {
                IsAttacking = false;
                //EventsSystem.OnTargetExit();
                //print("Exit");
                //give shoot command to the hunters to hunt WantedAnimal
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (hasToTargetWantedAnimal)
    //    {
    //        if (collision.tag == "WantedAnimal")
    //        {
    //            //give shoot command to the hunters to hunt WantedAnimal
    //        }
    //    }
    //    else
    //    {
    //        if (collision.tag == "NotWantedAnimal")
    //        {
    //            //give shoot command to the hunters to hunt NotWantedAnimal
    //        }
    //    }

    //}
}
