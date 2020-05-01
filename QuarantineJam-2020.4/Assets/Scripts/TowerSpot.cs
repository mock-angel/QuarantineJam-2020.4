using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;//the tower that we want to creat in this spot position
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private ResourcesManager resourcesManager;
    [SerializeField] private float numOfResourcesNeededToCreat;
    
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        EventsSystem.onUpdateResourcesCount += ChickForCreatAbility;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelected()
    {
        if (resourcesManager.numOfResources >= numOfResourcesNeededToCreat)
        {
            gameObject.SetActive(false);
            GameObject towerObj = Instantiate(towerPrefab, transform.position + positionOffset, towerPrefab.transform.rotation);
            Tower tower = towerObj.GetComponent<Tower>();
            tower.SpotUnderTower = this;
            EventsSystem.OnUpdateResourcesCount(-numOfResourcesNeededToCreat);
        }
    }
    
    public void OnDeSelected(){
        
        print("TowerSpot.OnDeSelected() called");
    }

    public void ChickForCreatAbility(float notNeeded)
    {
        if (resourcesManager.numOfResources < numOfResourcesNeededToCreat)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .25f);
        }
        else
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
        }
    }
}
