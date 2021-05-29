using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Alarm : MonoBehaviour
{
  
   private Color red = Color.red;
   private Color green = Color.green;
   
   //private SpriteRenderer sr;
   public GameObject redLight;
   public GameObject greenLight;
   public UnityEngine.Experimental.Rendering.Universal.Light2D alarmLight;
    void Start()
    {
        redLight.SetActive(false);
        greenLight.SetActive(true);
        alarmLight.color = green;
        // sr = GetComponentInChildren<SpriteRenderer>();
        // sr.color = green;
    }
   private void OnEnable()
   {
       PickBehavior.OnTriggered += AlarmTriggered; 
   }

   private void OnDisable()
   {
       PickBehavior.OnTriggered -= AlarmTriggered; 
   }

    void Update()
    {
        
    }

    private void AlarmTriggered()
    {
        redLight.SetActive(true);
        greenLight.SetActive(false);
        alarmLight.color = red;
    }


}
