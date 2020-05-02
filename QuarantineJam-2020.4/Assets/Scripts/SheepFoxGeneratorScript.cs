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
            nextSheepSpawnTime = Time.time + spawnSheepTime;
            
            //spawn sheep now.
            CreateSheep();
        }
        
        //If spawnFox is true, spawn fox.
        if(spawnFox && nextFoxSpawnTime <= Time.time){
            nextFoxSpawnTime = Time.time + foxSpawnTime;
            
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
        if(probe <= probabilityOfEnteringFarm && SheepFarm.Instance.sheepFarmBought)
            destinationSetter.target = finalFarmPosition;
        else destinationSetter.target = finalEscapePosition;
        
//        ResourcesManager.Instance.GainSettlers(1);
        //print("" + probe);
    }
    
    void CreateFox(){
        GameObject fox = Instantiate(foxPrefab, gameObject.transform);
        fox.transform.position = gameObject.transform.position;

        //Decide whether wolf goes inside farm.
        //...
        AIDestinationSetter destinationSetter = fox.GetComponent<AIDestinationSetter>();

        bool enterFarm = false;

        float probe = Random.Range(0f, 1f);
        if (probe <= probabilityOfEnteringFarm && SheepFarm.Instance.sheepFarmBought)
            destinationSetter.target = finalFarmPosition;
        else destinationSetter.target = finalEscapePosition;
    }
}


