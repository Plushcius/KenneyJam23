using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Waggler : MonoBehaviour
{
    Transform t;
    public float swingRange = 5f;

    void Start()
    {
        t = transform;

        t.localRotation = Quaternion.Euler(0, 0, swingRange);
        t.DORotate(new Vector3(0, 0, -swingRange), 1)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }
}
