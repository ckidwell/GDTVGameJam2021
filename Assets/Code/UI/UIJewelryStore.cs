using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIJewelryStore : MonoBehaviour
{ 
    [Header("Store Table Prefabs")]
    public GameObject table1Anchor;
    public GameObject table2Anchor;
    public GameObject table3Anchor;
    public GameObject table4Anchor;
    public GameObject table5Anchor;

    private GameObject table1Lid;
    private GameObject table2Lid;
    private GameObject table3Lid;
    private GameObject table4Lid;
    private GameObject table5Lid;
    
    public void GetLidsAndGemColliders()
    {
        Lid lidItem = null;
        table1Lid = table1Anchor.GetComponentInChildren<Lid>().gameObject;
        table2Lid = table2Anchor.GetComponentInChildren<Lid>().gameObject;
        
        lidItem = table3Anchor.GetComponentInChildren<Lid>();
        if(lidItem != null)
            table3Lid = lidItem.gameObject;
        
        lidItem = table4Anchor.GetComponentInChildren<Lid>();
        if(lidItem != null)
            table4Lid = lidItem.gameObject;
        lidItem = table5Anchor.GetComponentInChildren<Lid>();
        if(lidItem != null)
            table5Lid = lidItem.gameObject;
    }

    public void OpenLidForBoxNumber(int boxNumber)
    {
        switch (boxNumber)
        {
            case 1:
                table1Lid.SetActive(false);
                EnableGemCollidersForBox(1,true);
                break;
            case 2:
                table2Lid.SetActive(false);
                EnableGemCollidersForBox(2,true);
                break;
            case 3:
                table3Lid.SetActive(false);
                EnableGemCollidersForBox(3,true);
                break;
            case 4:
                table4Lid.SetActive(false);
                EnableGemCollidersForBox(4,true);
                break;
            case 5 :
                table5Lid.SetActive(false);
                EnableGemCollidersForBox(5,true);
                break;
            default:
                break;
                
        }
    }

    public void CloseAllLids()
    {
        table1Lid.SetActive(true);
        table2Lid.SetActive(true);
        table3Lid.SetActive(true);
        table4Lid.SetActive(true);
        table5Lid.SetActive(true);
    }

    public void DisableAllGemColliders()
    {
        DisableGemCollidersForBox(1);
        DisableGemCollidersForBox(2);
        DisableGemCollidersForBox(3);
        DisableGemCollidersForBox(4);
        DisableGemCollidersForBox(5);
    }
    public void DisableGemCollidersForBox(int boxNumber)
    {
        EnableGemCollidersForBox(boxNumber, false);
    }

    private void ToggleColliders(BoxCollider2D[] boxes, bool on)
    {
        foreach (var boxCollider2D in boxes)
        {
            boxCollider2D.enabled = on;
        }
    }
    public void EnableGemCollidersForBox(int boxNumber, bool toggleOn)
    {
        var boxColliders = table1Anchor.GetComponentsInChildren<BoxCollider2D>();
        switch (boxNumber)
        {
            case 1:
                ToggleColliders(GetGemBoxCollidersForAnchor(table1Anchor), toggleOn);
                break;
            case 2:
                ToggleColliders(GetGemBoxCollidersForAnchor(table2Anchor), toggleOn);
                break;
            case 3:
                boxColliders = GetGemBoxCollidersForAnchor(table3Anchor);
                if(boxColliders != null)
                    ToggleColliders(boxColliders, toggleOn);
                break;
            case 4:
                boxColliders = GetGemBoxCollidersForAnchor(table4Anchor);
                if(boxColliders != null)
                    ToggleColliders(boxColliders, toggleOn);
                break;
            case 5:
                boxColliders = GetGemBoxCollidersForAnchor(table5Anchor);
                if(boxColliders != null)
                    ToggleColliders(boxColliders, toggleOn);
                break;
        }
    }

    private BoxCollider2D[] GetGemBoxCollidersForAnchor(GameObject anchor)
    {
        var jSpots = anchor.GetComponentsInChildren<JSpot>();
        List<GameObject> obs = new List<GameObject>();
        foreach (var jewelrySpot in jSpots)
        {
            obs.Add(jewelrySpot.gameObject);
        }

        HashSet<BoxCollider2D> boxCollider2Ds = new HashSet<BoxCollider2D>();
        foreach (GameObject o in obs)
        {
            boxCollider2Ds.Add(o.GetComponent<BoxCollider2D>());
        }

        return boxCollider2Ds.ToArray();
    }
}
