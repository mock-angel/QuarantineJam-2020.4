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
        NumOfHuntersInTheTower = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnMouseExit()
    //{
    //    towerMenu.SetActive(false);//show the menu
    //}

    public void UpgradeTower()//add more hunters to that tower
    {
        NumOfHuntersInTheTower++;
    }

    public void DestroyTower()//destroy the tower
    {
        Destroy(gameObject);
        SpotUnderTower.gameObject.SetActive(true);
    }

    public void OnSelected()
    {
        if (!towerMenu.activeInHierarchy)
        {
            towerMenu.SetActive(true);//hide the menu
        }

    }

    public void OnDeSelected()
    {
        if (towerMenu.activeInHierarchy)
        {
            towerMenu.SetActive(false);//show the menu
        }
    }
}
