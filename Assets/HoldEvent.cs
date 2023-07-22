using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldEvent : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed;

    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            ShipMovement.I.BUTTON_Stabilize();
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
}
