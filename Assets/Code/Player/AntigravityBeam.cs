using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AntigravityBeam : MonoBehaviour
{
    public SpriteRenderer sr;
    public float beamSpeed = 2;

    void Start()
    {
        sr.DOColor(new Color(1, 1, 1, 0.5f), 1)
            .SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // todo nosta collision gameobjectia ylöspäin
        if (collision.gameObject.layer == 6)
        {
            print("Lol");
            collision.transform.position = collision.transform.position + Vector3.up * Time.fixedDeltaTime * beamSpeed;
        }
    }
}
