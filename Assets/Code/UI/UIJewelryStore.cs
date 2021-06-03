using System;
using System.Collections;
using System.Collections.Generic;
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
            case 0:
                table1Lid.SetActive(false);
                break;
            case 1:
                table2Lid.SetActive(false);
                break;
            case 2:
                table3Lid.SetActive(false);
                break;
            case 3:
                table4Lid.SetActive(false);
                break;
            case 4 :
                table5Lid.SetActive(false);
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

    public void DisableGemCollidersForBox(int boxNumber)
    {
        
    }

    public void EnableGemCollidersForBox(int boxNumber)
    {
        
    }
}
