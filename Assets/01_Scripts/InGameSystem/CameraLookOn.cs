using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CameraLookOn : MonoBehaviour
{
    CameraPointCenter camPointCenter;
    Transform playerLookTransform;
    Vector3 tempLookonVec;

    // Start is called before the first frame update
    void Start()
    {
        camPointCenter = GetComponentInParent<CameraPointCenter>();
        playerLookTransform = transform.parent;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camPointCenter.IsLock)
        {
            if (camPointCenter.LockonTransformm == null)
                return;
            tempLookonVec = (playerLookTransform.position + camPointCenter.LockonTransformm.position) / 2;
            transform.LookAt(tempLookonVec);
        }
        else
            transform.LookAt(playerLookTransform);
    }



}
