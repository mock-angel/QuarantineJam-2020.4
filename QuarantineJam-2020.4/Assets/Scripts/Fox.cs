﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    [HideInInspector] public bool IsItInTheFarm;

    [SerializeField] private int helthNumber;//how many times should we hit the sheep to hunt
    
    private Animator animator;
    private float hitsTakenCounter;
    
    public GameObject AffectCircle;
    public float speedWhenEatingSheep = 2f;
    public float speedWhenCatchingSheep = 3f;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        IsItInTheFarm = false;
        hitsTakenCounter = 0;
        animator = GetComponent<Animator>();
        
        AffectCircle.SetActive(false);
    }


    // Update is called once per frame.
    void Update()
    {
        animator.SetFloat("Rotation", transform.rotation.z);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            hitsTakenCounter += collision.GetComponent<Weapon>().damageValue;
            audioManager.PlayWolfHurtAudio();
            if (hitsTakenCounter >= helthNumber)
            { 
                Destroy(gameObject);
                audioManager.PlayWolfDiedAudio();
            }
                
        }
        else if (collision.tag == "Farm")
        {
            IsItInTheFarm = true;
            
            SheepFarm.Instance.OnSheepKilled();
            audioManager.PlaySheepDiedAudio();
            audioManager.PlayWolfAttackAudio();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Farm")
        
            IsItInTheFarm = false;
    }
}
