using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tower : TickObjectMonoBehaviour
{
    [HideInInspector] public TowerSpot SpotUnderTower;//the spot under the tower
    
    [HideInInspector] public int NumOfHuntersInTheTower;//the number of the Hunters that they are inside the tower

    [SerializeField] private GameObject towerMenu;
//    [SerializeField] private GameObject[] hunters;
    [SerializeField] private int huntersInTower;
    [SerializeField] private int maxNumOfHunters;//max number of hunters in the tower
    [SerializeField] private int woolToUpgrade;
    
    [SerializeField] private int meatEatenPerHunterPerTick;
    
    public int initialUpgradeCost = 5;
    int maxHunterLimit;
    int currentUpgradeCost;
   
    public TextMeshProUGUI hunterCountTxt;
    
    void Awake(){
        TickManager.Instance.AddITickObject((ITickObject)this);
    }
    
    void Start()
    {
        NumOfHuntersInTheTower = 1;
        currentUpgradeCost = initialUpgradeCost;
//        StartCoroutine(ConsumeResources());
//        resourcesManager.CreatedHunters.Add(hunters[NumOfHuntersInTheTower - 1]);
    }
    
    
    void Update(){
        
        hunterCountTxt.text = huntersInTower.ToString();
    }
    
    
    
    public void UpgradeTower()//add more hunters to that tower
    {
        //now we first check if we have enough resources.
        
        if(ResourcesManager.Instance.SpendWool(currentUpgradeCost)){
            
            maxHunterLimit += currentUpgradeCost;
            
            currentUpgradeCost *= 2;
            
            AudioManager.Instance.PlayUpgradeTowerAudio();
        }
        
//        if (NumOfHuntersInTheTower < maxNumOfHunters && resourcesManager.numOfResources >= woolToUpgrade)
//        {
//            NumOfHuntersInTheTower++;
//            hunters[NumOfHuntersInTheTower - 1].SetActive(true);
////            resourcesManager.CreatedHunters.Add(hunters[NumOfHuntersInTheTower - 1]);
////            EventsSystem.OnUpdateResourcesCount(-woolToUpgrade);
//            
//        }
    }
    
    public void OnClickedAddHunter(){
        
    }
    
    public void DestroyTower()//destroy the tower
    {
        Destroy(gameObject);
        SpotUnderTower.gameObject.SetActive(true);
        AudioManager.Instance.PlayDestroyTowerAudio();

        for (int i = 0; i < NumOfHuntersInTheTower; i++)
        {
//            resourcesManager.CreatedHunters.Remove(hunters[i]);
        }
    }

    public void OnSelected()
    {
        if (!towerMenu.activeInHierarchy)
        {
            towerMenu.SetActive(true);//hide the menu
        }

    }

    public void OnDeSelected()
    {
        if (towerMenu.activeInHierarchy)
        {
            towerMenu.SetActive(false);//show the menu
        }
    }
    
    public override void OnTick(){
    
        //Hunter's Lunchtime.
        int huntersCount = huntersInTower;
        ResourcesManager.Instance.EatFoodCumulative(huntersInTower, meatEatenPerHunterPerTick, out huntersInTower)
    }
    
//    public IEnumerator ConsumeResources()
//    {
//        while (this != null)
//        {
//            yield return new WaitForSeconds(60 / (numOfResourcesConsumedByHunterPerMinute * NumOfHuntersInTheTower));
//            EventsSystem.OnUpdateResourcesCount(-1);
//        }
//    }
}
