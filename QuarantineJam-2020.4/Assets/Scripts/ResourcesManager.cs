using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ResourcesManager : MonoBehaviour
{
    public float numOfResources;

    [SerializeField] private TextMeshProUGUI resourcesCountTxt;


    // Start is called before the first frame update
    void Start()
    {
        resourcesCountTxt.text = numOfResources.ToString();
        EventsSystem.onUpdateResourcesCount += UpdateResourcesNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateResourcesNumber(float resourcesToAdd)
    {
        numOfResources += resourcesToAdd;
        resourcesCountTxt.text = numOfResources.ToString();
    }

    private void OnDestroy()
    {
        EventsSystem.onUpdateResourcesCount -= UpdateResourcesNumber;
    }
}
