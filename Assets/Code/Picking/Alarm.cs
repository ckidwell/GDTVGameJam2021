using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
  
   private Color red = Color.red;
   private Color green = Color.green;
   private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.color = green;
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
        sr.color = red;
    }


}
