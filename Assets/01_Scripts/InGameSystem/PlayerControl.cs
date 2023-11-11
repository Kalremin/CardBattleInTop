using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField]
    float moveSpeed = 1f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(new Vector3(InputManager.Instance.dir.x, 0, InputManager.Instance.dir.y) * Time.deltaTime * moveSpeed);
        //transform.Translate(new Vector3(InputManager.Instance.dir.x, 0, InputManager.Instance.dir.y) * Time.deltaTime);
        //transform.position += new Vector3(InputManager.Instance.dir.x,0, InputManager.Instance.dir.y)* Time.deltaTime;
    }
}
