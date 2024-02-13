using System;
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

    [SerializeField] Transform playerModelTransform;
    [SerializeField] float noDamageTime = 3;

    PlayerState nowState;
    bool isHit = false;
    int manaPointInt;

    float deckResetDuration = 2f;
    float tempTime = 0;

    public Transform PlayerModelTransform => playerModelTransform;

    public Vector3 playerModelPos => playerModelTransform.position;

    public int ManaPointInt => manaPointInt;

    protected override void Awake()
    {
        //base.Awake();
        
        instance = this;
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        //camPointCenter = GetComponentInChildren<CameraPointCenter>();
        if (PlayerStatSetting.Instance.IsSave)
        {
            maxHealthPoint = PlayerStatSetting.Instance.maxHealth;
            maxManaPoint = PlayerStatSetting.Instance.maxMana;

            healthPoint = PlayerStatSetting.Instance.health;
            manaPoint = PlayerStatSetting.Instance.mana;

            healthRegen = PlayerStatSetting.Instance.healthRegen;
            manaRegen = PlayerStatSetting.Instance.manaRegen;

            moveSpeed = PlayerStatSetting.Instance.moveSpeed;

            foreach(var card in PlayerStatSetting.Instance.playerCardsDeck)
            {
                CardPlayer.Instance.AddCard(card);
            }

        }
        else
        {

            CardPlayer.Instance.AddCard(0);
            CardPlayer.Instance.AddCard(1);
            CardPlayer.Instance.AddCard(2);

        }


        SetManaPointInt();
        animator = GetComponentInChildren<Animator>();
        CardPlayer.Instance.ChangeState(DeckState.Ready);
    }

    protected override void Update()
    {
        base.Update();

        // 모델 회전
        //if (PlayerControl.Instance.LockonCharacter !=null)
        //{
        //    if (!PlayerControl.Instance.LockonCharacter.IsAlive)
        //    {
        //        PlayerControl.Instance.ResetTarget();

        //    }
        //    else
        //    {
        //        playerModelTransform.LookAt(PlayerControl.Instance.LockonCharacter.transform);
        //        playerModelTransform.localEulerAngles = new Vector3(0, playerModelTransform.localEulerAngles.y, 0);

        //    }

        //}
        //else
        //{
        //    playerModelTransform.localEulerAngles = Vector3.zero;
        //}

        // 피격시간 딜레이
        if (isHit)
        {
            tempTime += Time.deltaTime;
            if (tempTime > noDamageTime)
            {
                tempTime = 0;
                isHit = false;
            }
            
        }

        // 상태
        switch (nowState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Move:
                break;
            case PlayerState.Die:

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
        if (isHit)
            return;
        isHit = true;
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
    
    public int SetManaPointInt()
    {
        manaPointInt = Convert.ToInt32(manaPoint);
        return manaPointInt;
    }


    
}
