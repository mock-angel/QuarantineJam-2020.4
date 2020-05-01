using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    
    TowerSpot selectedSpot;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetMouseButtonDown(0)){
            return;
        }
        
        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        RaycastHit2D hit = Physics2D.Raycast(ray, -Vector2.up);
        
        if(hit.collider != null)
        {
            GameObject selection = hit.transform.gameObject;
            TowerSpot spot = selection.GetComponent<TowerSpot>();
            
            if(spot != null){
                //So we clicked on a tower.
                
                if(spot != selectedSpot){
                
                    spot.OnSelected();
                    
                    //Deselect previously selected spot.
                    if(selectedSpot != null)
                        selectedSpot.OnDeSelected();
                    
                    selectedSpot = spot;
                }
                else {
                    spot.OnDeSelected();
                    
                    selectedSpot = null;
                }
                
            }
        }
    }
}
