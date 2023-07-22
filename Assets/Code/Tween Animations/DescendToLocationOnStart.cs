using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DescendToLocationOnStart : MonoBehaviour
{
    Transform t;

    void Start()
    {
        t = transform;  
    }

    public void BUTTON_MoveCamera()
    {
        t = transform;
        t.DOMoveY(20, 4.5f)
            .From();
    }
}
