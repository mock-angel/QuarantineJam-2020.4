﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TickManager : MonoBehaviour
{
    public static TickManager Instance {get; private set;}
    
    private List<ITickObject> ITickObjectList;
    
    public Slider TickSlider;
    
    [Range(2f, 30f)]
    public float TickLength = 15f;
    
    float nextTickTime = 0;
    
    void Awake()
    {
        ITickObjectList = new List<ITickObject>();
        
        Instance = this;
    }

    void Update()
    {
        if(nextTickTime <= Time.time){
        
            if(nextTickTime != 0) nextTickTime += TickLength;
            
            else nextTickTime = Time.time + TickLength;
            
            ProcessTick();
        }
        
        TickSlider.value = 1f - (nextTickTime - Time.time)/TickLength;
    }
    
    public void AddITickObject(ITickObject obj){
        //print("Added");
        ITickObjectList.Add(obj);
        
    }
    
    void ProcessTick(){
        //print("Tick processed");
        for(int i = 0; i < ITickObjectList.Count; i++)
        
            ITickObjectList[i].OnTick();
            
    }
}
