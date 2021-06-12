using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Alarm : MonoBehaviour
{ 
   private SoundController soundController;
   private MusicController musicController;
   private Color red = Color.red;
   private Color green = Color.green;
   
   public GameObject redLight;
   public GameObject greenLight;
   public UnityEngine.Experimental.Rendering.Universal.Light2D alarmLight;
    void Start()
    {
        soundController = GameObject.Find("GameController").GetComponent<SoundController>();
        musicController = GameObject.Find("MusicPlayer").GetComponent<MusicController>();
        redLight.SetActive(false);
        greenLight.SetActive(true);
        alarmLight.color = green;

    }
   private void OnEnable()
   {
       PickBehavior.OnTriggered += AlarmTriggered; 
   }

   private void OnDisable()
   {
       PickBehavior.OnTriggered -= AlarmTriggered; 
   }

    private void AlarmTriggered()
    {
        soundController.PlayAlarmTrigger();
        musicController.StartTimer();
        redLight.SetActive(true);
        greenLight.SetActive(false);
        alarmLight.color = red;
    }

    public void ResetAlarm()
    {
        redLight.SetActive(false);
        greenLight.SetActive(true);
        alarmLight.color = green;
    }
}
