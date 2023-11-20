using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter
{
    float deckResetDuration = 2f;

    [SerializeField]
    CardPlayer cardPlayer;

    [SerializeField]
    Transform projectTransform;


    private void Start()
    {

    }

    private void Update()
    {
        
    }



    public void UseCardL()
    {
    }


    public void UseCardR()
    {
    }
    private void ActivateMagic(int cardLIdx)
    {
        throw new System.NotImplementedException();
    }

    #region ICharacterAct
    public override void AttackL()
    {
        print("P_Att_L");
        //AssetAddressLoad.Instance.LoadPrefab(11, projectTransform);
    }

    public override void AttackR()
    {
        print("P_Att_R");
        //AssetAddressLoad.Instance.LoadPrefab(11, projectTransform);
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
}
