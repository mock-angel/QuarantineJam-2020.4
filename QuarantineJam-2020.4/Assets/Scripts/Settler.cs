using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settler : MonoBehaviour
{
    //[HideInInspector] public Transform TargetMovingTo;

    [SerializeField] private float secToMoveSheepAround = 5;
    [SerializeField] private Transform patrolPoitsParent;

    private Transform[] petrolPoints;
    private bool isPatroling;

    private AIDestinationSetter destinationSetter;
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        isPatroling = false;
        petrolPoints = new Transform[patrolPoitsParent.childCount];

        for (int i = 0; i < patrolPoitsParent.childCount; i++)
        {
            petrolPoints[i] = patrolPoitsParent.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPatroling)
        {
            isPatroling = true;
            StartCoroutine(PetrolAround());
        }
    }

    public IEnumerator PetrolAround()
    {
        int randomPatrolPosition = Random.Range(0, petrolPoints.Length);
        Transform patrolTrans = petrolPoints[randomPatrolPosition];
        destinationSetter.target = patrolTrans;
        yield return new WaitForSeconds(secToMoveSheepAround);
        isPatroling = false;
    }
}
