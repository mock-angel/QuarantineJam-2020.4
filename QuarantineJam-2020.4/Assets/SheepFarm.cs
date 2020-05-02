using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class SheepFarm : TickObjectMonoBehaviour
{
    
    public bool sheepFarmBought;
    
    [Space(5)]
    public int initialPurchaseCost = 50;
    public int initialUpgradeCost = 5;
    
    private int currentUpgradeCost;
    
    [Space(5)]
    public GameObject buyButton;
    public GameObject AfterBuyPanel;
    
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
    
    public int addShepherdCountPerAdd = 1;
    
    public static SheepFarm Instance {get; private set;}
    
    void Awake(){
        Instance = this;
    }
    
    void Start(){
        
        currentUpgradeCost = initialUpgradeCost;
        
    }
    
    void Update(){
        //Update UI text.
        maxSheepLimitTxt.text = maxSheepLimit.ToString();
        sheepsInFarmTxt.text = sheepsInFarm.ToString();
        shepherdsInFarmTxt.text = shepherdsInFarm.ToString();
    }
    
    public void OnClickedBuy(){
        if(ResourcesManager.Instance.EatFood(initialPurchaseCost))
            
            OnBuy();
            
    }
    
    void OnBuy(){
        maxSheepLimit = 5;
        
        sheepFarmBought = true;
        print("Farm bought.");
        //Remove buy button and replace with upgrade button.
        buyButton.SetActive(false);
        AfterBuyPanel.SetActive(true);
    }
    
    public void OnClickedUpgrade(){
    
        if(ResourcesManager.Instance.SpendWool(currentUpgradeCost)){
            print("Farm upgrading.");
            maxSheepLimit += currentUpgradeCost ;
            
            currentUpgradeCost *= 2;//Upgrade cost doubles.
        }
        
    }
    
    public bool AddSheep(){
        if(sheepsInFarm < maxSheepLimit){
            sheepsInFarm += 1;
            return true;
        }
        else return false;
        
    }
    
    public void OnClickedAddShepherd(){
        if(ResourcesManager.Instance.GetSettler(addShepherdCountPerAdd))
        
            shepherdsInFarm += addShepherdCountPerAdd;
        
    }
    
    public override void OnTick(){
        
        //Calculate amount of wool Gained this turn.
        
        int woolGainThisTurn;
        if( shepherdsInFarm >= sheepsInFarm ) woolGainThisTurn = sheepsInFarm * woolPerShepherdPerTick;
        
        else woolGainThisTurn = shepherdsInFarm * woolPerShepherdPerTick;
        
        ResourcesManager.Instance.EarnWool(woolGainThisTurn);
        
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


