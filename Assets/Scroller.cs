using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed = 10;
    Transform t;

    void Start()
    {
        t = transform;
    }

    void Update()
    {
        t.position += speed * Time.deltaTime * Vector3.left; 
    }
}
