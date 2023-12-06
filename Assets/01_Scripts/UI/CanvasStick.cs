using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

public class CanvasStick : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    Vector2 startPos;
    Vector2 m_downPos;
    float movementRange = 50;

    private void Start()
    {
        startPos = ((RectTransform)transform).anchoredPosition;
        m_downPos = startPos;
    }

    public void OnPointerUp(PointerEventData data)
    {

        ((RectTransform)transform).anchoredPosition = m_downPos = startPos;
        SendValueToControl(Vector2.zero);
    }

    public void OnPointerDown(PointerEventData data)
    {
        RectTransform canvasRect = transform.parent?.GetComponentInParent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, data.position, data.pressEventCamera, out var m_startPos);
        SendValueToControl(data.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //print(eventData.delta);
        //SendValueToControl(eventData.delta);

        RectTransform canvasRect = transform.parent?.GetComponentInParent<RectTransform>();
        if (canvasRect == null)
        {
            Debug.LogError("OnScreenStick needs to be attached as a child to a UI Canvas to function properly.");
            return;
        }
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, eventData.position, eventData.pressEventCamera, out var position);
        
        var delta = position - m_downPos;

        delta = Vector2.ClampMagnitude(delta, movementRange);
        ((RectTransform)transform).anchoredPosition = (Vector2)startPos + delta;

        var newPos = new Vector2(delta.x / movementRange, delta.y / movementRange);
        SendValueToControl(newPos);
    }

    [InputControl(layout = "Vector2")]
    [SerializeField]
    private string m_ControlPath;

    protected override string controlPathInternal
    {
        get => m_ControlPath;
        set => m_ControlPath = value;
    }

}
