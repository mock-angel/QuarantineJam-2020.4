using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ResourcesManager : TickObjectMonoBehaviour
{

    public static ResourcesManager Instance { get; private set; }

    public float numOfResources;
    //    [HideInInspector] public List<GameObject> CreatedHunters;

    public int meatCount;
    public int woolCount;
    public int idleSettlersCount;

    [SerializeField] private TextMeshProUGUI resourcesCountTxt;

    [SerializeField] private TextMeshProUGUI meatCountTxt;
    [SerializeField] private TextMeshProUGUI woolCountTxt;

    [SerializeField] private TextMeshProUGUI idleSettlersCountTxt;

    //    [SerializeField] private TextMeshProUGUI huntersCountTxt;

    [SerializeField] private int numOfHuntersToDiePerMinute;//the number of the hunters are gonna die starving  per minute.
    [SerializeField] private int setlerMeatCost;

    private bool hasToKillHunters;
    private bool waskillerCalled;

    private void Awake()
    {
        Instance = this;
        TickManager.Instance.AddITickObject((ITickObject)this);
        //        EventsSystem.onUpdateResourcesCount += UpdateResourcesNumber;
    }

    void Start()
    {
        waskillerCalled = false;
        hasToKillHunters = false;
        resourcesCountTxt.text = numOfResources.ToString();
    }

    void Update()
    {
        //Update all UI display texts.
        meatCountTxt.text = meatCount.ToString();
        woolCountTxt.text = woolCount.ToString();
        idleSettlersCountTxt.text = idleSettlersCount.ToString();
    }

    public void EarnFood(int foodToAdd) {
        meatCount += foodToAdd;
        EventsSystem.OnUpdateResourcesCount();
    }

    // <summary>
    // Returns true if operation was successful.
    // </summary>
    public bool EatFood(int amountToEat) {
        if (meatCount < amountToEat) return false;

        meatCount -= amountToEat;
        EventsSystem.OnUpdateResourcesCount();
        return true;
    }

    public void EarnWool(int woolToAdd)
    {
        woolCount += woolToAdd;
        EventsSystem.OnUpdateResourcesCount();
    }

    // <summary>
    // Returns true if operation was successful.
    // Use this to remove said amount of ide settlers to convert them to shepherd or hunter.
    // </summary>
    public bool GetSettler(int count) {
        if (count > idleSettlersCount) return false;

        idleSettlersCount -= count;

        return true;
    }


    public void AddSettler()
    {
        if (meatCount >= setlerMeatCost)
        {
            print("settler Added");
            idleSettlersCount++;
            EatFood(setlerMeatCost);
        }

    }

    public void GainSettlers(int count) {
        idleSettlersCount += count;
    }

    // <summary>
    // Returns true if operation was successful.
    // </summary>
    public bool SpendWool(int woolToSpend)
    {
        //print(woolToSpend + "  " + woolCount);
        if (woolCount < woolToSpend) return false;

        woolCount -= woolToSpend;

        return true;

    }
    public override void OnTick() {
        int c = idleSettlersCount;

        EatFoodCumulative(idleSettlersCount, 1, out idleSettlersCount);

        if (c > idleSettlersCount) AudioManager.Instance.PlayHunterDiedAudio();
    }

    // <summary>
    // If u have 100 workers(unitCount), and u want every unit to get certain 
    // amount of food(foodPerUnit), this function will output to out param
    // (unitSurvived) the remaining units that survived attrition.
    // </summary>
    public void EatFoodCumulative(int unitCount, int foodPerUnit, out int unitSurvived) {
        int c = unitCount;
        unitSurvived = unitCount;
        for (int i = 0; i < c; i++) if (!ResourcesManager.Instance.EatFood(foodPerUnit)) unitSurvived -= 1;
    }
}
    
//    private void OnDestroy()
//    {
//        EventsSystem.onUpdateResourcesCount -= UpdateResourcesNumber;
//    }

//    public IEnumerator KillHunters()
//    {
//        while (hasToKillHunters)
//        {
//            yield return new WaitForSeconds(60 / numOfHuntersToDiePerMinute);
//            if (hasToKillHunters && CreatedHunters.Count > 0)
//            {
//                int rand = Random.Range(0, CreatedHunters.Count);
//                GameObject hunter = CreatedHunters[rand];
//                Tower tower = hunter.transform.parent.GetComponent<Tower>();
//                tower.NumOfHuntersInTheTower--;
//                if (tower.NumOfHuntersInTheTower <= 0)
//                {
//                    tower.DestroyTower();
//                }
//                else
//                {
//                    Destroy(hunter);
//                }
//                CreatedHunters.RemoveAt(rand);
//                audioManager.PlayHunterDiedAudio();
//            }
//        }
//    }

