using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class SheepFarm : TickObjectMonoBehaviour
{
    
    public bool sheepFarmBought;
    
    public Queue<GameObject> SheepQueue;
    
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
    public int foodGainPerSheepOwned = 2;
    
    [Space(5)]
    [Range(0, 5)]
    public int woolPerShepherdPerTick = 1;
    
    public int addShepherdCountPerAdd = 1;
    
    public static SheepFarm Instance {get; private set;}
    
    void Awake(){
        Instance = this;
        TickManager.Instance.AddITickObject((ITickObject)this);
        
        SheepQueue = new Queue<GameObject>();
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
            
            if(SheepFoxGeneratorScript.Instance.addedSheepSpawnPower == 0) 
                SheepFoxGeneratorScript.Instance.addedSheepSpawnPower = 1;
            else SheepFoxGeneratorScript.Instance.addedSheepSpawnPower *= 2;
            //addShepherdCountPerAdd = currentUpgradeCost / 10;
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
    
    public void OnSheepEscaped(int numberOfSheepEscaped){
        
        for (int i = 0;i < numberOfSheepEscaped; i++){
        
            Destroy(SheepFarm.Instance.SheepQueue.Dequeue());
            
        }
        
//        GameObject sheep = //Get the sheep.;
        
//        AIDestinationSetter destinationSetter = sheep.GetComponent<AIDestinationSetter>();
        
//        destinationSetter.target = finalEscapePosition;
    }
    
    // <summary>
    // Kill sheep if fox enters farm.
    // </summary>
    public void OnSheepKilled(){
        //Kill 1 sheep.
        
        sheepsInFarm -= 1;
        if(sheepsInFarm <= 0)
            sheepsInFarm = 0;
            
        else{
            OnSheepEscaped(1);
        
            AudioManager.Instance.PlaySheepDiedAudio();
        }
        //Add sheep killed music.
    }
    
    public override void OnTick(){
        
        //Calculate amount of wool Gained this turn.
        //print("SheepFarm: OnTick");
        int woolGainThisTurn;
        if( shepherdsInFarm >= sheepsInFarm ) woolGainThisTurn = sheepsInFarm * woolPerShepherdPerTick;
        
        else woolGainThisTurn = shepherdsInFarm * woolPerShepherdPerTick;
        
        ResourcesManager.Instance.EarnWool(woolGainThisTurn);
        
        ResourcesManager.Instance.EarnFood(woolGainThisTurn * foodGainPerSheepOwned);
        
        //Calculate loss of cattle this turn.
        int sheepLostThisTurn = 0;
        
        if( !(shepherdsInFarm >= sheepsInFarm) ) sheepLostThisTurn = sheepsInFarm - shepherdsInFarm;
        
        sheepsInFarm -= sheepLostThisTurn;
        
        if(sheepLostThisTurn != 0 ) OnSheepEscaped(sheepLostThisTurn);
        
        //Calculate loss of shepherds due to attrition.
        
        ResourcesManager.Instance.EatFoodCumulative(shepherdsInFarm, 1, out shepherdsInFarm);
        
        addShepherdCountPerAdd = (shepherdsInFarm / 10) + 1;
    }
}


