using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 0.1f, movementBoundaryLeft = -39.5f, movementBoundaryRight = -4f;

    public GameObject beam;
    public Cinemachine.CinemachineVirtualCamera vCam;
    public FixedJoystick joystick;
    Transform t;
    float horizontalInput;

    public static bool OnVictorySpin;
    public static PlayerController I;

    // end animation
    public GameObject momBeam;

    void Start()
    {
        I = this;
        t = transform;
        vCam.enabled = false;
        beam.SetActive(false);
        OnVictorySpin = false;
        Entrance();
    }

    [ContextMenu("VictorySpin")]
    public void DoVictorySpin()
    {
        OnVictorySpin = true;
        beam.SetActive(false);
        t.localRotation = Quaternion.Euler(0, 0, 0);
        t.DORotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .OnComplete(ResetVictorySpinStatus);
    }

    private void ResetVictorySpinStatus()
    {
        if (GameManager.I.Won == false)
            beam.SetActive(true);

        OnVictorySpin = false;
    }

    [ContextMenu("Entrance")]
    void Entrance()
    {
        Camera.main.GetComponent<DescendToLocationOnStart>().enabled = true;
        vCam.enabled = false;
        t.DOMove(new Vector3(t.position.x + 5, t.position.y + 10, t.position.z), 4f)
            .From()
            .SetEase(Ease.OutSine)
            .SetDelay(0.5f)
            .OnComplete(StartBeamAndCamera);
    }

    void StartBeamAndCamera()
    {
        beam.SetActive(true);
        vCam.enabled = true;
        GameManager.I.onScreenInputUI.SetActive(true);
    }

    [ContextMenu("End Animation")]
    public void EndAnimation()
    {
        momBeam.SetActive(true);
        momBeam.transform.parent = null;
        Invoke(nameof(DisableOwnBeam), 0.5f);
        t.DOMoveY(10, 5f)
            .OnComplete(EndAnimPhase2);
    }

    void EndAnimPhase2()
    {
        momBeam.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Game view").transform.DOMoveY(-20, 5)
            .OnComplete(GMEndScreen);
    }

    void GMEndScreen()
    {
        GameManager.I.ShowEndScreen();
    }

    void DisableOwnBeam()
    {
        beam.SetActive(false);
    }

    private void OnDisable()
    {
        t.DOKill();
    }

    void Update()
    {
        if (GameManager.I.Won)
        {
            vCam.enabled = false;
            return;
        }

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
