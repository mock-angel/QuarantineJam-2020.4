﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [HideInInspector] public bool isItInTheFarm;

    [SerializeField] private float helthNumber;//how many times should we hit the sheep to hunt
    [SerializeField] private float numOfRecorcesAfterHunt;//number of the recorces that you gonna git if you hunted the sheep;
    [SerializeField] private float numOfRecorcesPreducePerMinute;//number of the recorces that the sheep is gonna preduce each minute in the farm
    

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

    public IEnumerator PreduceRecources()
    {
        while (isItInTheFarm)
        {
            yield return new WaitForSeconds(60 / numOfRecorcesPreducePerMinute);
            //add the generated recources to the recources count
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            hitsTakenCounter++;
            if (hitsTakenCounter >= helthNumber)
            {
                //add some recources to the recources count
                Destroy(gameObject);
            }
        }
    }
}