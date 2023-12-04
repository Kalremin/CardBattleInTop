using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPadRotation : MonoBehaviour, IPointerDownHandler,IDragHandler
{
    [SerializeField]
    float multiplyRot=1;
    Camera playerCam;

    Vector2 touchPosition;
    Vector2 nowPos;
    EnemyCharacter lockonCharacter;

    public EnemyCharacter LockOnCharacter => lockonCharacter;
    private void Start()
    {
        playerCam = FindAnyObjectByType<CameraLookOn>().GetComponent<Camera>();
        
        
    }

    private void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //isTouching = true;
        //SetTouchPosition(eventData);

        //if (lockonCharacter != null)
        //{
        //    lockonCharacter.lockOnGround.SetActive(false);
        //}

        //Ray ray = playerCam.ScreenPointToRay(eventData.position);
        //if (Physics.Raycast(ray,out RaycastHit hitInfo))
        //{
        //    if(hitInfo.transform.TryGetComponent(out EnemyCharacter eCharacter))
        //    {
        //        lockonCharacter = eCharacter;
        //        lockonCharacter.lockOnGround.SetActive(true);
        //    }
        //}

    }

    public void OnDrag(PointerEventData eventData)
    {
        PlayerCharacter.Instance.transform.rotation =
            Quaternion.Euler(PlayerCharacter.Instance.transform.eulerAngles.x,
            PlayerCharacter.Instance.transform.eulerAngles.y + eventData.delta.x * multiplyRot,
            PlayerCharacter.Instance.transform.eulerAngles.z);


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


}
