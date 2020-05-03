using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;//the tower that we want to creat in this spot position
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private ResourcesManager resourcesManager;
    [SerializeField] private int numOfWoolNeededToCreat;
    [SerializeField] private AudioManager audioManager;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        EventsSystem.onUpdateResourcesCount += ChickForCreatAbility;
    }

    public void OnClickedSpot(){
        SelectionManager.Instance.OnClickedSpot(this);
    }
    
    public void OnSelected()
    {
        if (resourcesManager.SpendWool(numOfWoolNeededToCreat))
        {
            gameObject.SetActive(false);
            GameObject towerObj = Instantiate(towerPrefab, transform.position + positionOffset, towerPrefab.transform.rotation);
            Tower tower = towerObj.GetComponent<Tower>();
            tower.SpotUnderTower = this;
            audioManager.PlayBuildTowerAudio();
            EventsSystem.OnUpdateResourcesCount();
        }
    }
    
    public void OnDeSelected(){
        
        //print("TowerSpot.OnDeSelected() called");
    }

    public void ChickForCreatAbility()
    {
        if (resourcesManager.woolCount < numOfWoolNeededToCreat)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .35f);
        }
        else
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
        }
    }

    private void OnDestroy()
    {
        EventsSystem.onUpdateResourcesCount -= ChickForCreatAbility;
    }
}
