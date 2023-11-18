using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerControl : MonoBehaviour
{


    CharacterController characterController;
    PlayerCharacter character;
    Rigidbody playerRigid;

    bool isHoldAttackL = false;
    bool isHoldAttackR = false;
    bool isHoldLockOn = false;

    Vector2 dir;

    [SerializeField] Transform projectileTransform;

    void Awake()
    {
        //base.Awake();
        
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
        print("AttackL");
        character.AttackL();
    }

    public void OnAttackR()
    {
        print("AttackR");
    }

    public void OnInteract()
    {
        print("Interact");
    }

    public void OnSwap()
    {
        print("Swap");
    }

    public void OnLockOn(InputValue input)
    {
        isHoldLockOn = Convert.ToBoolean(input.Get<float>());
    }

    #endregion

}
