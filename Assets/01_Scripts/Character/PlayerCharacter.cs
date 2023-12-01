using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCharacter : BaseCharacter
{

    public enum PlayerState
    {
        Idle,
        Move,
        Magic,
        Die
    }

    static PlayerCharacter instance;
    public static PlayerCharacter Instance=>instance;

    PlayerState nowState;
    float deckResetDuration = 2f;

    //CameraPointCenter camPointCenter;
    TouchPadRotation padRotation;

    [SerializeField] Transform navTarget;
    public Vector3 NavTargetVec => navTarget.position;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    private void Start()
    {
        //camPointCenter = GetComponentInChildren<CameraPointCenter>();
        padRotation = FindAnyObjectByType<TouchPadRotation>();
        animator = GetComponentInChildren<Animator>();
        CardPlayer.Instance.AddCard(0);
        CardPlayer.Instance.AddCard(1);
        CardPlayer.Instance.AddCard(2);
        CardPlayer.Instance.ChangeState(DeckState.Ready);
    }

    protected override void Update()
    {
        base.Update();

        if (camPointCenter.IsLock)
        {
            
            navTarget.LookAt(camPointCenter.LockonTransformm);
            navTarget.localEulerAngles = new Vector3(0, navTarget.localEulerAngles.y, 0);
        }
        else
        {
            navTarget.localEulerAngles = Vector3.zero;
        }

        switch (nowState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Move:
                break;
            
        }
    }
    

    #region ICharacterAct
    public override void AttackL()
    {
        
        if(CardPlayer.Instance.UseCard(true,manaPoint))
            animator.SetTrigger("Magic");
        
        
    }

    public override void AttackR()
    {
        
        if(CardPlayer.Instance.UseCard(false, manaPoint))
            animator.SetTrigger("Magic");

        
    }

    public override void Hitted(float damage)
    {
        healthPoint -= damage;
        if (healthPoint > 0)
            animator.SetTrigger("Hit");
        else if(nowState != PlayerState.Die)
        {
            nowState = PlayerState.Die;
            isAlive = false;
            animator.SetTrigger("Die");
        }

    }

    public override void Idle()
    {
        animator.SetBool("Move", false);
    }

    public override void Move()
    {
        animator.SetBool("Move", true);
    }

    #endregion

    public void CostManaPoint(float costMana)
    {
        manaPoint -= costMana;
    }

    public void RestoreHealthPoint(float restorePoint)
    {
        healthPoint += restorePoint;
        if (healthPoint > maxHealthPoint)
            healthPoint = maxHealthPoint;
    }
    


    
}
