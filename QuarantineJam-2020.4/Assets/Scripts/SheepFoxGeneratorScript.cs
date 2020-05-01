using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;

public class SheepFoxGeneratorScript : MonoBehaviour
{
    public GameObject sheepPrefab;
    public GameObject foxPrefab;
    
    //amount of time before next sheep is spawned.
    public float spawnSheepTime;
    public float foxSpawnTime;
    
    public bool spawnFox;
    
    float nextSheepSpawnTime = 0;
    float nextFoxSpawnTime = 0;
    
    public Transform finalFarmPosition;
    public Transform finalEscapePosition;
    
    public bool farmBuilt;
    [Range(0f, 1f)]
    public float probabilityOfEnteringFarm;
    
    // Update is called once per frame
    void Update()
    {   
        if(nextSheepSpawnTime <= Time.time){
            nextSheepSpawnTime += spawnSheepTime;
            
            //spawn sheep now.
            CreateSheep();
        }
        
        //If spawnFox is true, spawn fox.
        if(spawnFox && nextFoxSpawnTime <= Time.time){
            nextFoxSpawnTime += foxSpawnTime;
            
            CreateFox();
        }
    }
    
    // Here Decide whether the sheep should go into the farm or not.
    void CreateSheep(){
        GameObject sheep = Instantiate(sheepPrefab, gameObject.transform);
        sheep.transform.position = gameObject.transform.position;
        
        //Decide whether sheep goes inside farm.
        //...
        AIDestinationSetter destinationSetter = sheep.GetComponent<AIDestinationSetter>();
        
        bool enterFarm = false;
        
        float probe = Random.Range(0f, 1f);
        if(probe <= probabilityOfEnteringFarm)
            enterFarm = true;
        else enterFarm = false;
        
        destinationSetter.target = finalEscapePosition;
    }
    
    void CreateFox(){
        GameObject fox = Instantiate(foxPrefab, gameObject.transform);
        fox.transform.position = gameObject.transform.position;
    }
}
