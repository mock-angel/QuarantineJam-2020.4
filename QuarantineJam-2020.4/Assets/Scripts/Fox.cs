using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    [HideInInspector] public bool IsItInTheFarm;

    [SerializeField] private int helthNumber;//how many times should we hit the sheep to hunt
    
    private Animator animator;
    private float hitsTakenCounter;

    private void Start()
    {
        IsItInTheFarm = false;
        hitsTakenCounter = 0;
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Rotation", transform.rotation.z);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            hitsTakenCounter += collision.GetComponent<Weapon>().damageValue;
            
            if (hitsTakenCounter >= helthNumber)
            
                Destroy(gameObject);
        }
        else if (collision.tag == "Farm")
        {
            IsItInTheFarm = true;
            
            SheepFarm.Instance.OnSheepKilled(1);
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Farm")
        
            IsItInTheFarm = false;
    }
}
