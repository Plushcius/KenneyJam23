using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType { Toothbrush, CoffeePot, FryingPan, GameController, PaintRoller, PaintBucket, USBStick, Cash, Book, Saw, }

public class Collectable : MonoBehaviour
{

    public CollectableType ItemType;
    Transform t;
    public float beamSpeed = 0.5f;
    public float fallSpeed = 1;
    public bool IsInGravityBeam;

    public float initialHeight;

    void Start()
    {
        t = transform;
        initialHeight = t.position.y;
    }

    public void DropItem()
    {
        GetComponent<Rigidbody2D>().simulated = false;
    }

    void FixedUpdate()
    {
        if (IsInGravityBeam)
        {
            IsInGravityBeam = false;
            t.position = t.position + Vector3.up * Time.fixedDeltaTime * beamSpeed;
        }
        else
        {
            if (t.position.y > initialHeight)
                t.position = t.position + Vector3.down * Time.fixedDeltaTime * fallSpeed;
        }
    }
}
