using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CameraLookOn : MonoBehaviour
{
    Vector3 tempLookonVec;
    [SerializeField] Transform lookTarget;

    [SerializeField] float PlayerDistance = 10.0f;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = lookTarget.position + Vector3.up * PlayerDistance;

        //if (PlayerControl.Instance.LockonCharacter !=null)
        //{
        //    tempLookonVec = (lookTarget.position + PlayerControl.Instance.LockonCharacter.transform.position) / 2;
        //    transform.LookAt(tempLookonVec);
        //}
        //else
            //transform.LookAt(lookTarget);
        transform.LookAt(lookTarget);
    }



}
