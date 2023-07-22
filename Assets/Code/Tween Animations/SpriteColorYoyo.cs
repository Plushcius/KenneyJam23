using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpriteColorYoyo : MonoBehaviour
{
    public SpriteRenderer sr;
    public float lowerRange = 0.6f;
    public float duration = 1.5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.DOColor(new Color(1, 1, 1, lowerRange), duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}