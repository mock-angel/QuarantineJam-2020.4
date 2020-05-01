using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackeCommander : MonoBehaviour
{
    [HideInInspector] public bool IsAttacking;

    private bool hasToTargetWantedAnimal;
    private Transform target;


    // Start is called before the first frame update
    void Start()
    {
        hasToTargetWantedAnimal = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(bool hasToTargetWantedAnimal)//if true then target the WantedAnimal else target the NotWantedAnimal
    {
        this.hasToTargetWantedAnimal = hasToTargetWantedAnimal;
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
                    EventsSystem.OnTargetEnter(target);
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
                    EventsSystem.OnTargetEnter(target);
                    IsAttacking = true;
                    print("Entered");
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
                EventsSystem.OnTargetExit();
                print("Exit");
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
