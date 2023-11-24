using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CameraLookOn : MonoBehaviour
{
    PlayerCharacter character;
    Transform playerLookTransform;
    Vector3 tempLookonVec;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<PlayerCharacter>();
        playerLookTransform = transform.parent;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (character.IsLock)
        {
            tempLookonVec = (playerLookTransform.position + character.LockonTransformm.position) / 2;
            transform.LookAt(tempLookonVec);
        }
        else
            transform.LookAt(playerLookTransform);
    }
}
