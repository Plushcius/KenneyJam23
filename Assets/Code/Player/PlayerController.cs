using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform t;

    void Start()
    {
        t = transform;
    }

    
    void Update()
    {
        t.position = t.position + Vector3.right * Input.GetAxis("Horizontal");
        print(Input.GetAxis("Horizontal"));
    }
}
