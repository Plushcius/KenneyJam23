using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipMovement : MonoBehaviour
{
    Sequence sequence;
    public Transform shipContainer;
    public float swingRange = 15;
    public float swingDuration = 1.5f;
    public Tween tween;
    private bool stabilizing;
    public static ShipMovement I;

    private void Awake()
    {
        I = this;
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
    }

    void Start()
    {
        shipContainer.localRotation = Quaternion.Euler(0,0, swingRange);
        tween = shipContainer.DORotate(new Vector3(0, 0, -swingRange), swingDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        tween.Kill();
    }

    public void BUTTON_Stabilize()
    {
        stabilizing = true;
    }

    void Update()
    {
        if (PlayerController.OnVictorySpin)
        {
            tween.timeScale = 0;
            return;
        }

        if (stabilizing || Input.GetKey(KeyCode.Space))
        {
            stabilizing = false;
            tween.timeScale = 0.5f;
        }
        else
        {
            tween.timeScale = 1f;
        }
    }
}
