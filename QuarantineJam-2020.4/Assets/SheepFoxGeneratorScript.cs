using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepFoxGeneratorScript : MonoBehaviour
{
    public GameObject sheepPrefab;
    public GameObject foxPrefab;
    
    //amount of time before next sheep is spawned.
    public float spawnSheepTime;
    
    float nextSheepSpawnTime;
    
    // Update is called once per frame
    void Update()
    {   
        //
        if(nextSheepSpawnTime > Time.time){
            nextSheepSpawnTime += spawnSheepTime;
            
            //spawn sheep now.
            CreateSheep();
        }
    }
    
    void CreateSheep(){
        GameObject sheep = Instantiate(sheepPrefab, gameObject.transform);
        sheep.transform.position = gameObject.transform.position;
    }
}
