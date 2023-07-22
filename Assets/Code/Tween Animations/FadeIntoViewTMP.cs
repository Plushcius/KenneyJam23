using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class FadeIntoViewTMP : MonoBehaviour
{
    public float initialD = 3, fadeInTime = 2f;
    Color transparent, initialColor;
    private TMP_Text text;
    Sequence sequence;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        initialColor = text.color;
        transparent = new Color(text.color.r, text.color.g, text.color.b, 0f);
        text.color = transparent;

        Invoke(nameof(Fade), initialD);
    }

    void Fade()
    {
        text.DOColor(initialColor, fadeInTime);
    }

    private void OnDisable()
    {
        print(text.DOKill());
    }
}
