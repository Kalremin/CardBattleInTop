using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;


public class OnCanvasStick : OnScreenStick, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        rectTransform.position = eventData.position;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Up");
    }
}
