using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderForEvent : MonoBehaviour
{
    [SerializeField] Collider[] attackColliders;
    // Start is called before the first frame update
    bool isAttack = false;
    bool isAlive = true;
    bool isHit = false;

    public bool IsAlive => isAlive;
    public bool IsAttack=>isAttack;
    public bool IsHit => isHit;
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

    public void IsAttacking(int val)
    {
        isAttack = val > 0 ? true : false;
    }

    public void ClearPrefab()
    {
        isAlive = false;
    }

    public void IsHitting(int val)
    {
        isHit = val > 0 ? true : false;
    }
}
