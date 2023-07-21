using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipMovement : MonoBehaviour
{
    Sequence sequence;

    private void Awake()
    {
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 10);
    }

    void Start()
    {
        
    }

    private void OnDisable()
    {
        sequence.Kill();
    }

    void Update()
    {
        
    }
}
