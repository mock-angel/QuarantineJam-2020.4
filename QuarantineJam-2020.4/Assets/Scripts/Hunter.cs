using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
   //[HideInInspector] public Transform target;


    [SerializeField] private float foodConsumePerMinut;//how much food this hunter consume
    

    //private bool hasToAttack;



    // Start is called before the first frame update
    void Start()
    {
        //hasToAttack = false;
        //EventsSystem.onTargetEnter += Attack;
        //EventsSystem.onTargetExit += StopAttacking;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void Attack(Transform target)
    //{
    //    if (!hasToAttack)
    //    {
    //        this.target = target;
    //        hasToAttack = true;
    //        StartCoroutine(Shoot());
    //    }
    //}

    //public void StopAttacking()
    //{
    //    hasToAttack = false;
    //    this.target = null;
    //}

    

    //private void OnDestroy()
    //{
    //    EventsSystem.onTargetEnter -= Attack;
    //    EventsSystem.onTargetExit -= StopAttacking;
    //}
}
