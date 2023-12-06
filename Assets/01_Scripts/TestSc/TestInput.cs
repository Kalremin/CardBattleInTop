using DunGen;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;
using UnityEngine.InputSystem.OnScreen;

public class TestInput : MonoBehaviour
{
    OnCanvasStick screenTick;
    Vector3 pivotPos;


    private void Awake()
    {
        screenTick = GetComponent<OnCanvasStick>();
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        pivotPos = screenTick.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float dist = Vector3.Distance(screenTick.transform.position,temp);
        print(screenTick.transform.position + ", " + pivotPos);
        print(Vector3.Normalize(screenTick.transform.position - pivotPos));

    }


    public void TestInputMethod(InputAction.CallbackContext ctx)
    {
        print(ctx.ReadValue<Vector2>());
    }
}
