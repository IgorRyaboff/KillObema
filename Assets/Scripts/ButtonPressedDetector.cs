using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonPressedDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}