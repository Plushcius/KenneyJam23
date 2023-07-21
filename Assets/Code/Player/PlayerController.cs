using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    Transform t;
    public float movementSpeed = 0.1f;
    public FixedJoystick ilotikku;

    void Start()
    {
        t = transform;
        ilotikku = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();


    }

    
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            t.position = t.position + Vector3.right * movementSpeed * Input.GetAxis("Horizontal");
        else
            t.position = t.position + Vector3.right * movementSpeed * ilotikku.Horizontal;
    }
}
