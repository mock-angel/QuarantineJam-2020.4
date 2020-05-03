using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;

public class SheepFoxGeneratorScript : MonoBehaviour
{
    public GameObject sheepPrefab;
    public GameObject foxPrefab;
    
    //amount of time before next sheep is spawned.
    [Space(5)]
    public float spawnSheepTime = 6f;
    public float foxSpawnTime = 15f;
    
    public float spawnSheepVariance = 1f;
    public float spawnFoxVariance = 3f;
    
    [Space(5)]
    public bool spawnFox;
    
    [Space(5)]
    float nextSheepSpawnTime = 0;
    float nextFoxSpawnTime = 0;
    
    public int addedSheepSpawnPower = 0;
    
    [Space(5)]
    public Transform finalFarmPosition;
    public Transform finalEscapePosition;
    
    [Range(0f, 1f)]
    public float probabilityOfEnteringFarm;
    
    public static SheepFoxGeneratorScript Instance {get; private set;}
    
    void Awake(){
        Instance = this;
    }
    
    // Update is called once per frame.
    void Update()
    {   
        if(nextSheepSpawnTime <= Time.time){
            nextSheepSpawnTime = Time.time + spawnSheepTime + Random.Range(-spawnFoxVariance, spawnFoxVariance);
            
            //spawn sheep now.
            CreateSheep();
        }
        
        if((!spawnFox) && SheepFarm.Instance.sheepFarmBought) spawnFox = true;
        
        //If spawnFox is true, spawn fox.
        if(spawnFox && nextFoxSpawnTime <= Time.time){
            nextFoxSpawnTime = Time.time + foxSpawnTime + Random.Range(-spawnFoxVariance, spawnFoxVariance);
            
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
        Sheep sheepScript = sheep.GetComponent<Sheep>();
        sheepScript.AddPower(addedSheepSpawnPower); 
        
        float probe = Random.Range(0f, 1f);
        if(probe <= probabilityOfEnteringFarm && SheepFarm.Instance.sheepFarmBought)
            destinationSetter.target = finalFarmPosition;
        else destinationSetter.target = finalEscapePosition;
        
    }
    
    void CreateFox(){
        GameObject fox = Instantiate(foxPrefab, gameObject.transform);
        fox.transform.position = gameObject.transform.position;

        //Decide whether wolf goes inside farm.
        //...
        AIDestinationSetter destinationSetter = fox.GetComponent<AIDestinationSetter>();

        destinationSetter.target = finalFarmPosition;
    }
}


