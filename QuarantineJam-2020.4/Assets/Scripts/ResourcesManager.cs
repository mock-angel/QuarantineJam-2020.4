using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ResourcesManager : MonoBehaviour
{
    public float numOfResources;
    [HideInInspector] public List<GameObject> CreatedHunters;

    [SerializeField] private TextMeshProUGUI resourcesCountTxt;
    
    [SerializeField] private TextMeshProUGUI meatCountTxt;
    [SerializeField] private TextMeshProUGUI woolCountTxt;
    
    [SerializeField] private TextMeshProUGUI idleSettlersCountTxt;
    [SerializeField] private TextMeshProUGUI sheepInFarmCountTxt;
    
//    [SerializeField] private TextMeshProUGUI huntersCountTxt;
    
    [SerializeField] private int numOfHuntersToDiePerMinute;//the number of the hunters are gonna die starving  per minute
    [SerializeField] private AudioManager audioManager;

    private bool hasToKillHunters;
    private bool waskillerCalled;
    private void Awake()
    {
        EventsSystem.onUpdateResourcesCount += UpdateResourcesNumber;
    }
    // Start is called before the first frame update
    void Start()
    {
        waskillerCalled = false;
        CreatedHunters = new List<GameObject>();
        hasToKillHunters = false;
        resourcesCountTxt.text = numOfResources.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateResourcesNumber(float resourcesToAdd)
    {
        numOfResources = Mathf.Clamp(numOfResources + resourcesToAdd, 0, 500);
        resourcesCountTxt.text = numOfResources.ToString();
        if (numOfResources <= 0)
        {
            hasToKillHunters = true;
            if (!waskillerCalled)
            {
                waskillerCalled = true;
                StartCoroutine(KillHunters());
            }
            
        }
        else
        {
            hasToKillHunters = false;
            StopCoroutine(KillHunters());
            waskillerCalled = false;
        }
    }

    private void OnDestroy()
    {
        EventsSystem.onUpdateResourcesCount -= UpdateResourcesNumber;
    }

    public IEnumerator KillHunters()
    {
        while (hasToKillHunters)
        {
            yield return new WaitForSeconds(60 / numOfHuntersToDiePerMinute);
            if (hasToKillHunters && CreatedHunters.Count > 0)
            {
                int rand = Random.Range(0, CreatedHunters.Count);
                GameObject hunter = CreatedHunters[rand];
                Tower tower = hunter.transform.parent.GetComponent<Tower>();
                tower.NumOfHuntersInTheTower--;
                if (tower.NumOfHuntersInTheTower <= 0)
                {
                    tower.DestroyTower();
                }
                else
                {
                    Destroy(hunter);
                }
                CreatedHunters.RemoveAt(rand);
                audioManager.PlayHunterDiedAudio();
            }
        }
    }
}
