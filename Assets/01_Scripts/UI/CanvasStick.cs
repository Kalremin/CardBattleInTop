using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

public class CanvasStick : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    if (eventData == null)
    //        throw new System.ArgumentNullException(nameof(eventData));

    //    BeginInteraction(eventData.position, eventData.pressEventCamera);
    //}

    ///// <summary>
    ///// Callback to handle OnDrag UI events.
    ///// </summary>
    //public void OnDrag(PointerEventData eventData)
    //{
    //    if (eventData == null)
    //        throw new System.ArgumentNullException(nameof(eventData));

    //    MoveStick(eventData.position, eventData.pressEventCamera);
    //}

    ///// <summary>
    ///// Callback to handle OnPointerUp UI events.
    ///// </summary>
    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    EndInteraction();
    //}

    //private void BeginInteraction(Vector2 pointerPosition, Camera uiCamera)
    //{
    //    var canvasRect = transform.parent?.GetComponentInParent<RectTransform>();
    //    if (canvasRect == null)
    //    {
    //        Debug.LogError("OnScreenStick needs to be attached as a child to a UI Canvas to function properly.");
    //        return;
    //    }

    //    switch (m_Behaviour)
    //    {
    //        case Behaviour.RelativePositionWithStaticOrigin:
    //            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, pointerPosition, uiCamera, out m_PointerDownPos);
    //            break;
    //        case Behaviour.ExactPositionWithStaticOrigin:
    //            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, pointerPosition, uiCamera, out m_PointerDownPos);
    //            MoveStick(pointerPosition, uiCamera);
    //            break;
    //        case Behaviour.ExactPositionWithDynamicOrigin:
    //            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, pointerPosition, uiCamera, out var pointerDown);
    //            m_PointerDownPos = ((RectTransform)transform).anchoredPosition = pointerDown;
    //            break;
    //    }
    //}

    //private void MoveStick(Vector2 pointerPosition, Camera uiCamera)
    //{
    //    var canvasRect = transform.parent?.GetComponentInParent<RectTransform>();
    //    if (canvasRect == null)
    //    {
    //        Debug.LogError("OnScreenStick needs to be attached as a child to a UI Canvas to function properly.");
    //        return;
    //    }
    //    RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, pointerPosition, uiCamera, out var position);
    //    var delta = position - m_PointerDownPos;

    //    switch (m_Behaviour)
    //    {
    //        case Behaviour.RelativePositionWithStaticOrigin:
    //            delta = Vector2.ClampMagnitude(delta, movementRange);
    //            ((RectTransform)transform).anchoredPosition = (Vector2)m_StartPos + delta;
    //            break;

    //        case Behaviour.ExactPositionWithStaticOrigin:
    //            delta = position - (Vector2)m_StartPos;
    //            delta = Vector2.ClampMagnitude(delta, movementRange);
    //            ((RectTransform)transform).anchoredPosition = (Vector2)m_StartPos + delta;
    //            break;

    //        case Behaviour.ExactPositionWithDynamicOrigin:
    //            delta = Vector2.ClampMagnitude(delta, movementRange);
    //            ((RectTransform)transform).anchoredPosition = m_PointerDownPos + delta;
    //            break;
    //    }

    //    var newPos = new Vector2(delta.x / movementRange, delta.y / movementRange);
    //    SendValueToControl(newPos);
    //}

    //private void EndInteraction()
    //{
    //    ((RectTransform)transform).anchoredPosition = m_PointerDownPos = m_StartPos;
    //    SendValueToControl(Vector2.zero);
    //}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
