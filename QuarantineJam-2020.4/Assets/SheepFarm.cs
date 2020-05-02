﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class SheepFarm : TickObjectMonoBehaviour
{
    public bool sheepFarmBought;
    
    [Space(5)]
    public int initialPurchaseCost;
    public int initialUpgradeCost;
    
    private int currentUpgradeCost;
    
    [Space(5)]
    public GameObject buyButton;
    public GameObject AfterBuyPanel;
    
    public static SheepFarm Instance {get; private set;}
    
    [Space(5)]
    public int maxSheepLimit; //Max number of sheeps in Farm. Can be upgraded.
    public int sheepsInFarm; //Number of sheeps currently in Farm.
    public int shepherdsInFarm;
    
    [Space(5)]
    public TextMeshProUGUI maxSheepLimitTxt;
    public TextMeshProUGUI sheepsInFarmTxt;
    public TextMeshProUGUI shepherdsInFarmTxt;
    
    [Space(5)]
    [Range(0, 5)]
    public int woolPerShepherdPerTick = 1;
    
    void Start(){
        Instance = this;
        
        currentUpgradeCost = initialUpgradeCost;
        
    }
    
    void Update(){
        //Update UI text.
        maxSheepLimitTxt.text = maxSheepLimit.ToString();
        sheepsInFarmTxt.text = sheepsInFarm.ToString();
        shepherdsInFarmTxt.text = shepherdsInFarm.ToString();
    }
    
    public void OnClickedBuy(){
        
        int temp = 100;//Replace with amount of wool.
        if(initialPurchaseCost <= temp){
            temp -= initialPurchaseCost;
            
            OnBuy();
        }
    }
    
    void OnBuy(){
        sheepFarmBought = true;
        
        //Remove buy button and replace with upgrade button.
        buyButton.SetActive(false);
        AfterBuyPanel.SetActive(true);
    }
    
    public void OnClickedUpgrade(){
    
        if(ResourcesManager.Instance.SpendWool(currentUpgradeCost)){
            maxSheepLimit += currentUpgradeCost ;
            
            currentUpgradeCost *= 2;//Upgrade cost doubles.
        }
        
    }
    
    public override void OnTick(){
        
        //Calculate amount of wool Gained this turn.
        
        int woolGainThisTurn;
        if( shepherdsInFarm >= sheepsInFarm ) woolGainThisTurn = sheepsInFarm * woolPerShepherdPerTick;
        
        else woolGainThisTurn = shepherdsInFarm * woolPerShepherdPerTick;
        
        //Calculate loss of cattle this turn.
        int sheepLostThisTurn = 0;
        
        if( !(shepherdsInFarm >= sheepsInFarm) ) sheepLostThisTurn = sheepsInFarm - shepherdsInFarm;
        
        //Calculate loss of shepherds due to attrition.
        
        int totalFood = 100;//Will have to replace this ofcourse to ResourceManager.
        
        int totalEatFood = shepherdsInFarm;
        
        int totalShepherdsListThisTurn = 0;
        
        if(totalFood < totalEatFood)
            totalShepherdsListThisTurn = sheepsInFarm - totalEatFood;
        
        
    }
}

