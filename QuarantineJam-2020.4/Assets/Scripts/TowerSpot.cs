using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;//the tower that we want to creat in this spot position
    [SerializeField] private Vector3 positionOffset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        GameObject towerObj = Instantiate(towerPrefab, transform.position + positionOffset, towerPrefab.transform.rotation);
        Tower tower = towerObj.GetComponent<Tower>();
        tower.SpotUnderTower = this;
    }
}
