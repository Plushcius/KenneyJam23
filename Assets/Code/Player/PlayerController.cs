using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.1f, movementBoundaryLeft = -39.5f, movementBoundaryRight = -4f;

    public GameObject beam;
    public Cinemachine.CinemachineVirtualCamera vCam;
    FixedJoystick joystick;
    Transform t;
    float horizontalInput;

    public static bool OnVictorySpin;
    public static PlayerController I;

    void Start()
    {
        I = this;
        t = transform;
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        vCam.enabled = false;
        beam.SetActive(false);
        OnVictorySpin = false;
        Entrance();
    }

    [ContextMenu("VictorySpin")]
    public void DoVictorySpin()
    {
        OnVictorySpin = true;
        t.localRotation = Quaternion.Euler(0, 0, 0);
        t.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .OnComplete(ResetVictorySpinStatus);
    }

    private void ResetVictorySpinStatus()
    {
        OnVictorySpin = false;
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
        horizontalInput = 0;

        if (Input.GetAxis("Horizontal") != 0)
            horizontalInput = Input.GetAxis("Horizontal");
        else
            horizontalInput = joystick.Horizontal;

        if (horizontalInput < 0 && t.localPosition.x < movementBoundaryLeft)
            return;

        if (horizontalInput > 0 && t.localPosition.x > movementBoundaryRight)
            return;

        t.position += horizontalInput * movementSpeed * Time.deltaTime * Vector3.right;
    }
}
