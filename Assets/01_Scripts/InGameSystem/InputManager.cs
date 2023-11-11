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
    #region
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

    public void OnLockOn(InputValue input)
    {
        isHoldLockOn = Convert.ToBoolean(input.Get<float>());
    }
    // Start is called before the first frame update

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
        }

    }

    float tempTime, setTime = 1;

    // Update is called once per frame
    void Update()
    {
        //tempTime += Time.deltaTime;
        //if (tempTime > setTime) { print(dir);tempTime = 0; }

    }
}
