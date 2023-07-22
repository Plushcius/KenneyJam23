using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ScaleIntoView : MonoBehaviour
{
    public float initialD = 3, fadeInTime = 2f;
    public Ease ease = Ease.OutBounce;
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
        transform.localScale = Vector3.zero;
        Invoke(nameof(Scale), initialD);
    }

    void Scale()
    {
        transform.DOScale(initialScale, fadeInTime)
            .SetEase(ease);
    }

    private void OnDisable()
    {
        print(transform.DOKill());
    }
}
