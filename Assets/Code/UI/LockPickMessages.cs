using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockPickMessages : MonoBehaviour
{
    private TMP_Text messageText;
    private float timeTillNextMessage;
    void Start()
    {
        messageText = GetComponentInChildren<TMP_Text>();
        StartCoroutine(TypeText("LOCKED"));
        timeTillNextMessage = Time.time + 2f;
    }
    private void OnEnable()
    {
        Lock.OnSendLockPickMessage += SetMesage; 
    }

    private void OnDisable()
    {
        Lock.OnSendLockPickMessage  -= SetMesage; 
    }

    private void SetMesage(string message)
    {
        if (timeTillNextMessage > Time.time)
            return;
        timeTillNextMessage = Time.time + 2f;
        StopCoroutine(TypeText(""));
        StartCoroutine(TypeText(message));
    }
    IEnumerator TypeText(string message)
    {
        messageText.text = "";
        foreach (var c in message) 
        {
            messageText.text += c;
            yield return new WaitForSeconds (0.125f);
        }
    }
}
