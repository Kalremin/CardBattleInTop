using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    bool isLock = false;
    float deckResetDuration = 2f;

    [SerializeField]
    Transform navTarget;

    Transform lockonTransform;
    int lockonIdx = 0;

    List<Transform> enemyLockonTransform = new List<Transform>();
    public Vector3 NavTargetVec => navTarget.position;

    public Transform LockonTransformm => lockonTransform;

    public bool IsLock => isLock && enemyLockonTransform.Count>0;

    private void Start()
    {
        CardPlayer.Instance.AddCard(0);
        CardPlayer.Instance.AddCard(1);
        //CardPlayer.Instance.AddCard(2);
        CardPlayer.Instance.ChangeState(DeckState.Ready);
    }

    protected override void Update()
    {
        base.Update();

        if (IsLock)
        {
            lockonTransform = enemyLockonTransform[lockonIdx];

        }
    }
    
    public void SetLockState(bool isLock)
    {
        this.isLock = isLock;
        if (isLock)
        {
            lockonIdx = 0;

        }
        
    }

    #region ICharacterAct
    public override void AttackL()
    {
        print("P_Att_L");
        CardPlayer.Instance.UseCard(true,manaPoint);
        
    }

    public override void AttackR()
    {
        print("P_Att_R");
        CardPlayer.Instance.UseCard(false,manaPoint);
        
    }

    public override void Hitted(float damage)
    {
        print("P_Hit:"+ damage);
    }

    public override void Idle()
    {
        print("P_Idle");
    }

    public override void Move()
    {
        print("P_Move");
    }

    #endregion

    public void ChangeLockonTarget()
    {
        if (lockonIdx == enemyLockonTransform.Count - 1)
        {
            lockonIdx = 0;
        }
        else
            lockonIdx++;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
            enemyLockonTransform.Add(other.transform);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
            enemyLockonTransform.Remove(other.transform);
        
    }
}
