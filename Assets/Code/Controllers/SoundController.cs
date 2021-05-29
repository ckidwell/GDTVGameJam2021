using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundController : MonoBehaviour
{
    public AudioSource lockClick1;
    public AudioSource lockClick2;
    public AudioSource lockJiggle1;
    public AudioSource lockJiggle2;
    public AudioSource lockOpen1;
    public AudioSource pinReset;
    public AudioSource policeSiren;
    public AudioSource hint;
    public AudioSource alarmTrigger;
    public void PlayLockClick1()
    {
        lockOpen1.Play();
    }
    public void PlayLockClick2()
    {
        lockClick2.Play();
    }
    public void PlayLockJiggle()
    {
        if (Random.Range(1, 100) < 50)
        {
            lockJiggle1.Play();
            return;
        }

        lockJiggle2.Play();
    }
    public void PlayLockOpen1()
    {
        lockClick1.Play();
    }
    public void PlayPinReset()
    {
        pinReset.Play();
    }
    public void LoopPoliceSiren()
    {
        policeSiren.loop = true;
        policeSiren.Play();
    }

    public void StopPoliceSiren()
    {
        policeSiren.Stop();
    }
    public void PlayHint()
    {
        hint.Play();
    }
    public void PlayAlarmTrigger()
    {
        alarmTrigger.Play();
    }
}
