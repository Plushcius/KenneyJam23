using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    Transform t;
    public float movementSpeed = 0.1f;
    public FixedJoystick ilotikku;
    public Cinemachine.CinemachineVirtualCamera vCam;
    public GameObject beam;

    void Start()
    {
        t = transform;
        ilotikku = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        vCam.enabled = false;
        beam.SetActive(false);
        Entrance();
    }

    [ContextMenu("Entrance")]
    void Entrance()
    {
        vCam.enabled = false;
        t.DOMove(new Vector3(t.position.x + 4, t.position.y + 7, t.position.z), 3f)
            .From()
            .SetEase(Ease.OutSine)
            .OnComplete(StartBeamAndCamera);
    }

    void StartBeamAndCamera()
    {
        beam.SetActive(true);
        vCam.enabled = true;
    }
    
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
            t.position = t.position + Vector3.right * Time.deltaTime * movementSpeed * Input.GetAxis("Horizontal");
        else
            t.position = t.position + Vector3.right * Time.deltaTime * movementSpeed * ilotikku.Horizontal;
    }
}
