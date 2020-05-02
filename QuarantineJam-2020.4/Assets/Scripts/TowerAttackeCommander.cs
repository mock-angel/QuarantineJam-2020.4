using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackeCommander : MonoBehaviour
{
    [HideInInspector] public bool HasToAttack;

    [SerializeField] private Tower tower;
    [SerializeField] private Transform weaponPrefab;//the weapon that we are going to hunt the animals with
    [SerializeField] private float timeToShootArrow;//the number of arrows that we are going to shoot in one minut
    [SerializeField] private Transform weaponPosition;

    private bool hasToTargetWantedAnimal;
    private Transform target;
    private float nextShootTime;

    // Start is called before the first frame update
    void Start()
    {
        nextShootTime = 0;
        HasToAttack = false;
        hasToTargetWantedAnimal = true;

        //StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        //print(tower.huntersInTower);
        if (target == null)
        {
            HasToAttack = false;
        }
        if (nextShootTime <= Time.time)
        {
            nextShootTime += timeToShootArrow;
            Shoot();
        }
    }

    public void SetTarget(bool hasToTargetWantedAnimal)//if true then target the WantedAnimal else target the NotWantedAnimal
    {
        target = null;
        this.hasToTargetWantedAnimal = hasToTargetWantedAnimal;
        HasToAttack = false;
    }

    //public IEnumerator Shoot()
    //{
    //    while (true)
    //    {
    //        if (target != null && tower.huntersInTower > 0)
    //        {
    //            if (target.tag == "WantedAnimal" && !target.GetComponent<Sheep>().isItInTheFarm)
    //            {
    //                Transform weaponObj = Instantiate(weaponPrefab, weaponPosition.position, weaponPrefab.rotation);
    //                Weapon weapon = weaponObj.GetComponent<Weapon>();
    //                weapon.damageValue = tower.huntersInTower;
    //                weapon.target = this.target;
    //            }
    //            else if(target.tag == "NotWantedAnimal" && !target.GetComponent<Sheep>().isItInTheFarm)
    //            {
    //                Transform weaponObj = Instantiate(weaponPrefab, weaponPosition.position, weaponPrefab.rotation);
    //                Weapon weapon = weaponObj.GetComponent<Weapon>();
    //                weapon.damageValue = tower.huntersInTower;
    //                weapon.target = this.target;
    //            }
                
    //        }
           
    //        yield return new WaitForSeconds(60 / (timeToShootArrow * tower.huntersInTower));
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!HasToAttack)
        {
            if (hasToTargetWantedAnimal)
            {
                if (collision.tag == "WantedAnimal")
                {
                    target = collision.transform;
                    HasToAttack = true;
                    //print("Entered");
                }
            }
            else
            {
                if (collision.tag == "NotWantedAnimal")
                {
                    target = collision.transform;
                    HasToAttack = true;
                    //print("Entered");
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
                target = null;
                HasToAttack = false;
                //print("Exit");
            }
        }
    }

    public void Shoot()
    {
        print(HasToAttack);
        if (HasToAttack)
        {
            print(tower.huntersInTower);
            if (target != null && tower.huntersInTower > 0)
            {
                if (target.tag == "WantedAnimal" && !target.GetComponent<Sheep>().IsItInTheFarm)
                {
                    Transform weaponObj = Instantiate(weaponPrefab, weaponPosition.position, weaponPrefab.rotation);
                    Weapon weapon = weaponObj.GetComponent<Weapon>();
                    weapon.damageValue = tower.huntersInTower;
                    weapon.target = this.target;
                }
                else if (target.tag == "NotWantedAnimal" && !target.GetComponent<Fox>().IsItInTheFarm)
                {
                    Transform weaponObj = Instantiate(weaponPrefab, weaponPosition.position, weaponPrefab.rotation);
                    Weapon weapon = weaponObj.GetComponent<Weapon>();
                    weapon.damageValue = tower.huntersInTower;
                    weapon.target = this.target;
                }

            }

        }
    }
}
