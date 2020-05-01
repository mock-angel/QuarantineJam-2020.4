using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector] public TowerSpot SpotUnderTower;//the spot under the tower
    [HideInInspector] public int NumOfHuntersInTheTower;//the number of the Hunters that they are inside the tower

    [SerializeField] private GameObject towerMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (towerMenu.activeInHierarchy)
        {
            towerMenu.SetActive(false);//hide the menu
        }
        else
        {
            towerMenu.SetActive(true);//show the menu
        }
    }

    //private void OnMouseExit()
    //{
    //    towerMenu.SetActive(false);//show the menu
    //}

    public void UpgradeTower()//add more hunters to that tower
    {
        print("Upgrade");
    }

    public void DestroyTower()//destroy the tower
    {
        Destroy(gameObject);
        SpotUnderTower.gameObject.SetActive(true);
    }
}
