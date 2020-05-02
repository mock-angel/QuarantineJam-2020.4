using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [HideInInspector] public Transform target;

    [SerializeField] private float weaponSpeed;

    private Rigidbody2D rig;
    private float x, y, angle;
    private bool hasToMove;


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        hasToMove = false;
        Shoot();
    }

    private void Update()
    {
        if (hasToMove)
        {
            if (target != null)
            {
                x = transform.position.x;
                y = transform.position.y;

                x = x - target.position.x;
                y = y - target.position.y;
                angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                transform.Rotate(new Vector3(0, 0, 180));
                transform.position += transform.right * Time.deltaTime * weaponSpeed;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void Shoot()
    {
        hasToMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "WantedAnimal" || collision.tag == "NotWantedAnimal")
        {
            Destroy(gameObject);
        }
    }
}
