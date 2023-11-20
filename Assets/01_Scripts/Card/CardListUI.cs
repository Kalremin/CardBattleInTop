using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class CardListUI : MonoBehaviour
{
    readonly int loadUIIdx=0;


    public void AddCardUI(int spriteIdx)
    {
        AssetAddressLoad.Instance.LoadCardUI(spriteIdx, transform);
    }

    public void AddCardUI(List<int> cardUIList)
    {
        AssetAddressLoad.Instance.LoadCardUIList(cardUIList, transform);
    }


    //IEnumerator AddCardCoroutine()
    //{
    //    yield return new Wait
    //}

    [ContextMenu("TestAdd")]
    public void TestAddCardUI()
    {
        AssetAddressLoad.Instance.LoadCardUI(0, transform);

    }

    [ContextMenu("TestAdd2")]
    public void TestAddCardUI2()
    {
        AssetAddressLoad.Instance.LoadCardUI(1, transform);

    }

    [ContextMenu("TestAdd3")]
    public void TestAddCardUI3()
    {
        AssetAddressLoad.Instance.LoadCardUI(2, transform);

    }

    public void RemoveFirstCardUI()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = null;
        Destroy(transform.GetChild(0).gameObject);// 오브젝트 풀링으로 전환 필요
    }

    public void RemoveAllCardUI()
    {
        foreach(Image temp in transform.GetComponentsInChildren<Image>())
        {
            temp.sprite = null;
        }

        while (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);// 오브젝트 풀링으로 전환 필요
        }
    }



}
