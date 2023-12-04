using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    static InputManager instance;
    public static InputManager Instance => instance;

    bool isHoldAttackL,isHoldAttackR;
    bool isHoldLockOn=false;

    public Vector2 dir;
    #region Input
    public void OnMove(InputValue input)
    {
        dir = input.Get<Vector2>();
    }

    public void OnAttackL()
    {
        print("AttackL");
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

    public void OnRot(InputValue val)
    {
        print(val.Get<Vector3>());
    }

    public void OnLockOn(InputValue input)
    {
        isHoldLockOn = Convert.ToBoolean(input.Get<float>());
    }
    // Start is called before the first frame update

    public void OnLockOnTarget(InputValue input)
    {

    }

    #endregion
    
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

}
