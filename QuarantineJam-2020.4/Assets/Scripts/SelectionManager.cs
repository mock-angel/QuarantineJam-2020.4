﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    
    public static SelectionManager Instance {get; private set;}
    
    TowerSpot selectedSpot;
    Tower selectedTower;
    
    void Awake()
    {
        Instance = this;
    }

//    void Update()
//    {
//        if (!Input.GetMouseButtonDown(0))
//        {
//            return;
//        }

//        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        worldPoint.z = Camera.main.transform.position.z;
//        Ray ray = new Ray(worldPoint, new Vector3(0, 0, 1));
//        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, 1 << 13);


//        if (hit.collider != null)
//        {
//            GameObject selection = hit.transform.gameObject;
//            TowerSpot spot = selection.GetComponent<TowerSpot>();

//            //Check if raycast hit TowerSpot.
////            if (spot != null)
////            {
////                //So we clicked on a tower.

////                if (spot != selectedSpot)
////                {

////                    spot.OnSelected();

////                    //Deselect previously selected spot.
////                    if (selectedSpot != null)
////                        selectedSpot.OnDeSelected();

////                    selectedSpot = null;
////                }
////                else
////                {
////                    spot.OnDeSelected();

////                    selectedSpot = null;
////                }

////            }

//            //Now see if the raycast hit a tower.
//            Tower tower = selection.GetComponent<Tower>();
//            if (tower != null)
//            {
//                //So we clicked on a tower.

//                if (tower != selectedTower)
//                {

//                    tower.OnSelected();

//                    //Deselect previously selected tower.
//                    if (selectedTower != null)
//                        selectedTower.OnDeSelected();

//                    selectedTower = tower;
//                }
//                else
//                {
//                    tower.OnDeSelected();

//                    selectedTower = null;
//                }

//            }
//        }
//    }
    
    public void OnClickedSpot(TowerSpot spot){
        if(spot == null) return;
        
        if (spot != selectedSpot)
        {

            spot.OnSelected();

            //Deselect previously selected spot.
            if (selectedSpot != null)
                selectedSpot.OnDeSelected();

            selectedSpot = null;
        }
        else
        {
            spot.OnDeSelected();

            selectedSpot = null;
        }
        
    }
    
    public void OnClickedTower(Tower tower){
        //Not Implemented yet.
        if (tower == null) return;
        
        //So we clicked on a tower.

        if (tower != selectedTower)
        {

            tower.OnSelected();

            //Deselect previously selected tower.
            if (selectedTower != null)
                selectedTower.OnDeSelected();

            selectedTower = tower;
        }
        else
        {
            tower.OnDeSelected();

            selectedTower = null;
        }
    }
}
