using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicEffectAttack : MonoBehaviour
{

    protected int idx;
    [SerializeField] protected float effectNum = 1;
    [SerializeField] protected float duration = 1f;

    protected float tempTime = 0;

    delegate void MagicEffect();
    MagicEffect magicEffectMethod;

    // Start is called before the first frame update
    void Start()
    {
        magicEffectMethod = ActivateEffect;
    }

    // Update is called once per frame
    void Update()
    {
        magicEffectMethod.Invoke();
    }

    public virtual void ActivateEffect()
    {
        tempTime += Time.deltaTime;
        if(tempTime >= duration)
        {
            tempTime = 0;
            ObjectPooling.Instance.ReturnEffect(gameObject, idx);
            //Destroy(gameObject);// 리소스 생성 및 오브젝트 풀링
        }
    }

    public void SetIdx(int idx) => this.idx = idx;

}
