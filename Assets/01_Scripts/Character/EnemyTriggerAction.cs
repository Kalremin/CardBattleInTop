using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerAction : MonoBehaviour
{
    [SerializeField]
    float damage = 1;


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerCharacter character))
        {
            character.Hitted(damage);
        }
    }
}
