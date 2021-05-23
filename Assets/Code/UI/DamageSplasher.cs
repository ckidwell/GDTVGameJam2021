using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSplasher : MonoBehaviour
{
    private Image damageSprite;
    private Color spriteColor;
    void Start()
    {
        damageSprite = GetComponent<Image>();
        spriteColor = new Color(0, 0, 0, 0);
        damageSprite.color = spriteColor;
    }

    public void SplashDamage(int magnitude)
    {
        if (magnitude == 100)
        {
            spriteColor = new Color(1, 1, 1, 1);
            damageSprite.color = spriteColor;
            return;
        }

        StartCoroutine(SplashAndFade());
    }

    private IEnumerator SplashAndFade()
    {
        yield return null;
    }
}
