using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using System.Linq;

public class CardListUI : MonoBehaviour
{
    
    [SerializeField]
    Image attackImageL, attackImageR;

    public void AddCardUI(int spriteIdx)
    {
        AssetAddressLoad.Instance.LoadCardUI(spriteIdx, transform);
    }

    public void AddCardUI(List<MagicCard> cardUIList)
    {
        AssetAddressLoad.Instance.LoadCardUIList(cardUIList, transform);
    }



    //IEnumerator AddCardCoroutine()
    //{
    //    yield return new Wait
    //}


    public void RemoveFirstCardUI(bool isLeft)
    {
        if (isLeft)
        {
            attackImageL.sprite = transform.GetChild(transform.childCount - 1).GetComponent<Image>().sprite;
            
            
        }
        else
        {
            
            attackImageR.sprite = transform.GetChild(transform.childCount - 1).GetComponent<Image>().sprite;
            
        }
        Destroy(transform.GetChild(transform.childCount - 1).gameObject);// 오브젝트 풀링으로 전환 필요
    }


    public void RemoveAllCardUI()
    {
        if (transform.childCount <= 0)
            return;

        foreach(Image temp in transform.GetComponentsInChildren<Image>())
        {
            temp.sprite = null;
        }

        while (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);// 오브젝트 풀링으로 전환 필요
        }
    }

    public void RemoveSpriteAttack(bool isLeft)
    {
        if (isLeft)
            attackImageL.sprite = null;
        else
            attackImageR.sprite = null;
    }



}
