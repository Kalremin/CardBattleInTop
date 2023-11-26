using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderForEvent : MonoBehaviour
{
    [SerializeField] Collider[] attackColliders;
    // Start is called before the first frame update
    void Start()
    {
        attackColliders = GetComponentsInChildren<Collider>();
    }
    public void AttackPlayer(int val)
    {
        for (int i = 0; i < attackColliders.Length; i++)
        {
            attackColliders[i].enabled = val > 0 ? true : false;
        }
    }
}
