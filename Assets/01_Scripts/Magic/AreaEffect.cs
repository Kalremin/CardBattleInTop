using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffect : MagicEffectAttack
{
    List<BaseCharacter> characterList = new List<BaseCharacter>();

    public override void ActivateEffect()
    {
        base.ActivateEffect();

        foreach(var character in characterList)
        {
            character.Hitted(effectNum / Time.deltaTime);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
            characterList.Add(other.GetComponent<BaseCharacter>());
            

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
            characterList.Remove(other.GetComponent<BaseCharacter>());
    }
}
