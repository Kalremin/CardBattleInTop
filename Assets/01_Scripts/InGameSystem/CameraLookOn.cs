using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CameraLookOn : MonoBehaviour
{
    Vector3 tempLookonVec;
    [SerializeField] Transform lookTarget;
    

    // Update is called once per frame
    void Update()
    {
        if (PlayerControl.Instance.LockonCharacter !=null)
        {
            tempLookonVec = (lookTarget.position + PlayerControl.Instance.LockonCharacter.transform.position) / 2;
            transform.LookAt(tempLookonVec);
        }
        else
            transform.LookAt(lookTarget);
    }



}
