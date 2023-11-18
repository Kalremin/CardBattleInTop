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
            // ����Ʈ ���ҽ� ����
            Destroy(gameObject); //  ������Ʈ Ǯ�� ������� ��ȯ
        }
    }
}
