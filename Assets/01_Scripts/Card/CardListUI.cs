using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class CardListUI : MonoBehaviour
{
    List<CardUI> cardList = new List<CardUI>();

    [SerializeField] GameObject cardUI;

    private void Start()
    {
        
    }

    public void AddCardUI(int idx)
    {
        //Instantiate(cardUI.gameObject, transform).GetComponent<Image>().sprite = //dlalwl;
    }



}
