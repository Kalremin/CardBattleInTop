using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerControl : MonoBehaviour
{
    // CameraPointCenter camCenter;
    static PlayerControl instance;
    public static PlayerControl Instance => instance;

    [SerializeField]
    InputAction moveAction, attackLeftAction, attackRightAction, interactAction, lockOnAction;//, rotateAction;



    [SerializeField] float multiplyRot = 1;
    [SerializeField] PlayerTriggerActions triggerActions;
    [SerializeField] PlayerInteract playerInteract;
   

    Camera playerCam;
    Rigidbody playerRigid;
    EnemyCharacter lockonCharacter;
    
    bool isHoldLockOn = false;

    Vector2 dir;
    Vector2 movPos;
    
    public EnemyCharacter LockonCharacter { get { return lockonCharacter; } }

    public void ResetTarget() { lockonCharacter = null; }

    void Awake()
    {
        instance = this;
        playerRigid = GetComponent<Rigidbody>();
        playerCam = GetComponentInChildren<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        moveAction.performed += MoveAction_performed;
        moveAction.canceled += MoveAction_canceled;
        moveAction.Enable();

        attackLeftAction.performed += AttackLeftAction_performed;
        attackLeftAction.Enable();

        attackRightAction.performed += AttackRightAction_performed;
        attackRightAction.Enable();

        interactAction.performed += InteractAction_performed;
        interactAction.Enable();

        //rotateAction.performed += RotateAction_performed;
        //rotateAction.Enable();

        lockOnAction.performed += LockOnAction_performed;
        lockOnAction.Enable();

    }

    private void OnDisable()
    {
        moveAction.Disable();
        moveAction.performed -= MoveAction_performed;
        moveAction.canceled -= MoveAction_canceled;

        attackLeftAction.Disable();
        attackLeftAction.performed -= AttackLeftAction_performed;

        attackRightAction.Disable();
        attackRightAction.performed -= AttackRightAction_performed;

        interactAction.Disable();
        interactAction.performed -= InteractAction_performed;

        //rotateAction.Disable();
        //rotateAction.performed -= RotateAction_performed;

        lockOnAction.Disable();
        lockOnAction.performed -= LockOnAction_performed;
    }


    private void LockOnAction_performed(InputAction.CallbackContext obj)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = playerCam.ScreenPointToRay(obj.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.TryGetComponent(out EnemyCharacter eCharacter))
            {
                if (lockonCharacter != null)
                    lockonCharacter.lockOnGround.SetActive(false);
                lockonCharacter = eCharacter;
                lockonCharacter.lockOnGround.SetActive(true);
            }
        }
    }

    private void RotateAction_performed(InputAction.CallbackContext obj)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        
        PlayerCharacter.Instance.transform.rotation =
            Quaternion.Euler(PlayerCharacter.Instance.transform.eulerAngles.x,
            PlayerCharacter.Instance.transform.eulerAngles.y + obj.ReadValue<Vector2>().x * multiplyRot,
            PlayerCharacter.Instance.transform.eulerAngles.z);
    }

    private void InteractAction_performed(InputAction.CallbackContext obj)
    {
        if (triggerActions.IsHit)
            return;
        if (lockonCharacter != null)
        {
            lockonCharacter.lockOnGround.SetActive(false);
            lockonCharacter = null;
        }
        triggerActions.SetFalseHit();
        playerInteract.ActivateItem();
    }

    private void AttackRightAction_performed(InputAction.CallbackContext obj)
    {
        if (triggerActions.IsHit)
            return;
        triggerActions.SetFalseHit();
        if (PlayerCharacter.Instance.IsAlive)
            PlayerCharacter.Instance.AttackR();
    }

    private void AttackLeftAction_performed(InputAction.CallbackContext obj)
    {
        if (triggerActions.IsHit)
            return;
        triggerActions.SetFalseHit();
        if (PlayerCharacter.Instance.IsAlive)
            PlayerCharacter.Instance.AttackL();
    }

    private void MoveAction_canceled(InputAction.CallbackContext obj)
    {
        if (PlayerCharacter.Instance.IsAlive)
        {
            dir = Vector2.zero;
            PlayerCharacter.Instance.Idle();
        }
    }

    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
        if (triggerActions.IsHit)
            return;
        triggerActions.SetFalseHit();
        if (PlayerCharacter.Instance.IsAlive)
        {

            dir = obj.ReadValue<Vector2>();

            

            PlayerCharacter.Instance.Move();// 이동 애니메이션
            
        }
    }

    // Update is called once per frame
    void Update()
    {        
        if(PlayerCharacter.Instance.IsAlive &&
            !triggerActions.IsHit)
        {
            //playerRigid.MovePosition(transform.position +
            //    (transform.forward * dir.y + transform.right * dir.x) * Time.deltaTime * PlayerCharacter.Instance.MoveSpeed);

            //playerRigid.MovePosition(transform.position + dir.x * Vector3.right + dir.y * Vector3.forward);



            if (dir != Vector2.zero)
            {
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                print(angle);
                //PlayerCharacter.Instance.PlayerModelTransform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                PlayerCharacter.Instance.PlayerModelTransform.localRotation = Quaternion.Euler(0, -angle, 0);

            }


        }

    }

    #region PlayerInput
    public void OnMove(InputValue input)
    {
        
        //dir = input.Get<Vector2>();
        //dir.magnitude


        if (PlayerCharacter.Instance.IsAlive)
        {

            if (dir.Equals(Vector2.zero))
            {
                PlayerCharacter.Instance.Idle();
            }
            else
            {
                PlayerCharacter.Instance.Move();
            }
        }
        
    }

    public void OnAttackL()
    {
        if (PlayerCharacter.Instance.IsAlive)
            PlayerCharacter.Instance.AttackL();
    }

    public void OnAttackR()
    {
        if (PlayerCharacter.Instance.IsAlive)
            PlayerCharacter.Instance.AttackR();
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

    public void OnLockOnTarget(InputValue input)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = playerCam.ScreenPointToRay(input.Get<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.TryGetComponent(out EnemyCharacter eCharacter))
            {
                if (lockonCharacter != null)
                    lockonCharacter.lockOnGround.SetActive(false);
                lockonCharacter = eCharacter;
                lockonCharacter.lockOnGround.SetActive(true);
            }
        }

    }

    public void OnRotate(InputValue input)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        PlayerCharacter.Instance.transform.rotation =
            Quaternion.Euler(PlayerCharacter.Instance.transform.eulerAngles.x,
            PlayerCharacter.Instance.transform.eulerAngles.y + input.Get<Vector2>().x * multiplyRot,
            PlayerCharacter.Instance.transform.eulerAngles.z);
    }



    #endregion


}
