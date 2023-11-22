using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : CardMagic
{
    [SerializeField] float moveSpeed = 1f;
    
    public override void ActivateEffect()
    {
        base.ActivateEffect();
        //transform.Translate(transform.forward*moveSpeed*Time.deltaTime);
        transform.position += transform.forward*moveSpeed*Time.deltaTime;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out BaseCharacter character))//other.CompareTag("Enemy"))
        {
            character.Hitted(effectNum);
            //other.GetComponent<BaseCharacter>().Hitted(effectNum);
            // 이펙트 리소스 생성
            Destroy(gameObject); //  오브젝트 풀링 사용으로 전환
        }
    }
}
