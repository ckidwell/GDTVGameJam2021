using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashMoneyTextEffect : MonoBehaviour
{
    public int moneyAmount = 0;
    public Color startColor;
    public Color endColor;
    private float colorChangeDuration = .42f;
    private float lerpStart = 0f;
    private TMP_Text text;
    private float endYPosition = 600f;
    private float targetYPosition;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        StartCoroutine(MoveText(endYPosition));
        StartCoroutine(FadeText());
       
    }

    IEnumerator MoveText(float endValue )
    {
        float duration = 1.5f;
        float time = 0;
        float startValue = transform.localPosition.y;

        while (time < duration)
        {
            targetYPosition = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            transform.localPosition = new Vector3(0, targetYPosition, 0);
            yield return new WaitForSeconds(.009f);
        }
        targetYPosition = endValue;
        
        StopCoroutine(FadeText());
        Destroy(gameObject);
    }
    IEnumerator FadeText()
    {
        bool fading = true;
        while(fading)
        {
            text.color = Color.Lerp(startColor, endColor, lerpStart);
            if (lerpStart < 1){
                lerpStart += Time.deltaTime/colorChangeDuration;
            }
            else
            {
                fading = false;
            }
            yield return new WaitForSeconds(.007f);
        }
      
        yield return null;

    }
}
