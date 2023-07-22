using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipMovement : MonoBehaviour
{
    Sequence sequence;
    public Transform shipContainer;
    public float swingRange = 15;
    public Tween tween;
    //public Tween timescaleTween;

    private void Awake()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
    }

    void Start()
    {
        shipContainer.localRotation = Quaternion.Euler(0,0, swingRange);
        tween = shipContainer.DORotate(new Vector3(0, 0, -swingRange), 1)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        tween.Kill();
    }

    void Update()
    {
        if (PlayerController.OnVictorySpin)
        {
            tween.timeScale = 0;
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            tween.timeScale = 0.5f;
        }
        else
        {
            tween.timeScale = 1f;
        }
    }
}
