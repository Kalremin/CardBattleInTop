using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerControl : MonoBehaviour
{
   // CameraPointCenter camCenter;
    PlayerCharacter character;
    Rigidbody playerRigid;

    bool isHoldLockOn = false;

    Vector2 dir;
    

    void Awake()
    {
        //camCenter = GetComponentInChildren<CameraPointCenter>();
        playerRigid = GetComponent<Rigidbody>();
        character = GetComponent<PlayerCharacter>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
        if(character.IsAlive)
            playerRigid.MovePosition(transform.position +
                (transform.forward * dir.y + transform.right * dir.x) * Time.deltaTime * character.MoveSpeed);

    }

    #region PlayerInput
    public void OnMove(InputValue input)
    {
        if (character.IsAlive)
        {

            dir = input.Get<Vector2>();
            if (dir.Equals(Vector2.zero))
            {
                character.Idle();
            }
            else
            {
                character.Move();
            }
        }
        
    }

    public void OnAttackL()
    {
        if (character.IsAlive)
            character.AttackL();
    }

    public void OnAttackR()
    {
        if (character.IsAlive)
            character.AttackR();
    }

    public void OnInteract()
    {
        //if (character.IsAlive)
        //    if (isHoldLockOn)
        //        camCenter.ChangeLockonTarget();
            
    }


    public void OnLockOn(InputValue input)
    {
        //if (character.IsAlive)
        //{
        //    isHoldLockOn = Convert.ToBoolean(input.Get<float>());
        //    camCenter.SetIsLock(isHoldLockOn);
        //}
        
    }

    #endregion

}
