using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : CardMagic
{
    [SerializeField] float moveSpeed = 1f;
    
    public override void ActivateEffect()
    {
        base.ActivateEffect();
        transform.Translate(transform.forward);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyCharacter>().Hitted(effectNum);
            // 이펙트 리소스 생성
            Destroy(gameObject); //  오브젝트 풀링 사용으로 전환
        }
    }
}
