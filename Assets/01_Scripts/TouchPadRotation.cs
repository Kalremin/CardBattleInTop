using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPadRotation : MonoBehaviour, IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    [SerializeField]
    Transform playerTransform;

    Vector2 touchPosition;
    Vector2 nowPos;
    bool isTouching = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouching = true;
        SetTouchPosition(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isTouching)
        {
            nowPos = eventData.position;
            Vector2 dir = nowPos - touchPosition;
            playerTransform.rotation = Quaternion.Euler(playerTransform.eulerAngles.x, playerTransform.eulerAngles.y + dir.x, playerTransform.eulerAngles.z);
            SetTouchPosition(eventData);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouching = false;
    }

    private void SetTouchPosition(PointerEventData eventData)
    {
        touchPosition = eventData.position;

        Debug.Log("Touch Position: " + touchPosition);
    }

}
