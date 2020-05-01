using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector] public TowerSpot SpotUnderTower;//the spot under the tower
    [HideInInspector] public int NumOfHuntersInTheTower;//the number of the Hunters that they are inside the tower

    [SerializeField] private GameObject towerMenu;
    [SerializeField] private GameObject[] hunters;
    [SerializeField] private float maxNumOfHunters;//max number of hunters in the tower
    [SerializeField] private float numOfResourcesNeededToUpgrade;
    [SerializeField] private float numOfResourcesConsumedByHunterPerMinute;

    private ResourcesManager resourcesManager;

    // Start is called before the first frame update
    void Start()
    {
        resourcesManager = FindObjectOfType<ResourcesManager>();
        NumOfHuntersInTheTower = 1;
        StartCoroutine(ConsumeResources());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpgradeTower()//add more hunters to that tower
    {
        if (NumOfHuntersInTheTower < maxNumOfHunters && resourcesManager.numOfResources >= numOfResourcesNeededToUpgrade)
        {
            NumOfHuntersInTheTower++;
            hunters[NumOfHuntersInTheTower - 1].SetActive(true);
            EventsSystem.OnUpdateResourcesCount(-numOfResourcesNeededToUpgrade);
        }
        
    }

    public void DestroyTower()//destroy the tower
    {
        Destroy(gameObject);
        SpotUnderTower.gameObject.SetActive(true);
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

    public IEnumerator ConsumeResources()
    {
        while (this != null)
        {
            yield return new WaitForSeconds(60 / (numOfResourcesConsumedByHunterPerMinute * NumOfHuntersInTheTower));
            EventsSystem.OnUpdateResourcesCount(-1);
        }
    }
}
