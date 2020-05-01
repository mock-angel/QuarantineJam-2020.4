using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    [HideInInspector] public Transform target;


    [SerializeField] private float foodConsumePerMinut;//how much food this hunter consume
    [SerializeField] private Transform weaponPrefab;//the weapon that we are going to hunt the animals with
    [SerializeField] private float numOfArrowsPerMinute;//the number of arrows that we are going to shoot in one minut
    [SerializeField] private Transform weaponPosition;

    private bool hasToAttack;



    // Start is called before the first frame update
    void Start()
    {
        hasToAttack = false;
        EventsSystem.onTargetEnter += Attack;
        EventsSystem.onTargetExit += StopAttacking;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(Transform target)
    {
        if (!hasToAttack)
        {
            this.target = target;
            hasToAttack = true;
            StartCoroutine(Shoot());
        }
    }

    public void StopAttacking()
    {
        hasToAttack = false;
        this.target = null;
    }

    public IEnumerator Shoot()
    {
        while (hasToAttack)
        {
            Transform weaponObj = Instantiate(weaponPrefab, weaponPosition.position, weaponPrefab.rotation);
            Weapon weapon = weaponObj.GetComponent<Weapon>();
            weapon.target = this.target;
            yield return new WaitForSeconds(60 / numOfArrowsPerMinute);
        }
    }

    private void OnDestroy()
    {
        EventsSystem.onTargetEnter -= Attack;
        EventsSystem.onTargetExit -= StopAttacking;
    }
}
