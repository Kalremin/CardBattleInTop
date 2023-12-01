using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPadRotation : MonoBehaviour, IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    [SerializeField]
    float multiplyRot=1;
    Transform playerTransform;
    Camera playerCam;

    Vector2 touchPosition;
    Vector2 nowPos;
    bool isTouching = false;
    EnemyCharacter lockonCharacter;

    public EnemyCharacter LockOnCharacter => lockonCharacter;
    private void Start()
    {
        playerCam = FindAnyObjectByType<CameraLookOn>().GetComponent<Camera>();
        playerTransform = FindAnyObjectByType<PlayerCharacter>().transform;
        
    }

    private void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //isTouching = true;
        //SetTouchPosition(eventData);
        if (lockonCharacter != null)
        {
            lockonCharacter.lockOnGround.SetActive(false);
        }

        Ray ray = playerCam.ScreenPointToRay(eventData.position);
        if (Physics.Raycast(ray,out RaycastHit hitInfo))
        {
            if(hitInfo.transform.TryGetComponent(out EnemyCharacter eCharacter))
            {
                lockonCharacter = eCharacter;
                lockonCharacter.lockOnGround.SetActive(true);
            }
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        playerTransform.rotation =
            Quaternion.Euler(playerTransform.eulerAngles.x,
            playerTransform.eulerAngles.y + eventData.delta.x * multiplyRot,
            playerTransform.eulerAngles.z);


        //if (isTouching)
        //{
        //    nowPos = eventData.position;
        //    Vector2 dir = nowPos - touchPosition;
        //    playerTransform.rotation = 
        //        Quaternion.Euler(playerTransform.eulerAngles.x, 
        //        playerTransform.eulerAngles.y + dir.x*multiplyRot, 
        //        playerTransform.eulerAngles.z);
        //    SetTouchPosition(eventData);
        //}
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouching = false;
    }

    private void SetTouchPosition(PointerEventData eventData)
    {
        touchPosition = eventData.position;
    }

}
