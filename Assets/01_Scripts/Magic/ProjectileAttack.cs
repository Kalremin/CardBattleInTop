using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MagicEffectAttack
{
    
    [SerializeField] float moveSpeed = 1f;
    
    public override void ActivateEffect()
    {
        base.ActivateEffect();
        //transform.Translate(transform.forward*moveSpeed*Time.deltaTime);

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.name);

        if (other.TryGetComponent(out EnemyCharacter character))//other.CompareTag("Enemy"))
        {
            tempTime = 0;
            character.Hitted(effectNum);
            //other.GetComponent<BaseCharacter>().Hitted(effectNum);
            // ����Ʈ ���ҽ� ����
            //Destroy(gameObject); //  ������Ʈ Ǯ�� ������� ��ȯ

            ObjectPooling.Instance.ReturnEffect(gameObject, idx);
        }
    }

    
}
