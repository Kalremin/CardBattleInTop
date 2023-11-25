using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerControl : MonoBehaviour
{
    PlayerCharacter character;
    Rigidbody playerRigid;

    bool isHoldLockOn = false;

    Vector2 dir;
    

    void Awake()
    {
        playerRigid = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {        
        playerRigid.MovePosition(transform.position +
            (transform.forward * dir.y + transform.right * dir.x) * Time.deltaTime * character.MoveSpeed);

    }

    #region PlayerInput
    public void OnMove(InputValue input)
    {
        dir = input.Get<Vector2>();
    }

    public void OnAttackL()
    {
        character.AttackL();
    }

    public void OnAttackR()
    {
        
        character.AttackR();
    }

    public void OnInteract()
    {
        print("Interact");
        if (isHoldLockOn)
        {
            character.ChangeLockonTarget();
        }
    }


    public void OnLockOn(InputValue input)
    {
        isHoldLockOn = Convert.ToBoolean(input.Get<float>());
        character.SetLockState(isHoldLockOn);
    }

    #endregion

}
