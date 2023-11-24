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

    }

    private void Update()
    {
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
        CardPlayer.Instance.UseCard(true);
        
    }

    public override void AttackR()
    {
        print("P_Att_R");
        CardPlayer.Instance.UseCard(false);
        
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
