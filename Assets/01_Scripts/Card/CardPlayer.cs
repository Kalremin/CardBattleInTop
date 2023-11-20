using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPlayer : MonoBehaviour
{
    static CardPlayer instance;
    public static CardPlayer Instance=>instance;

    int tempIdx;
    int cardLIdx;
    int cardRIdx;

    List<int> playerCardIdInDeck = new List<int>(); // 가지고 있는 카드 리스트
    List<int> tempIntList = new List<int>();
    Queue<int> cardIdQueue = new Queue<int>(); // 현재 덱

    CardListUI cardListUI;

    [SerializeField]
    Image attackImageL, attackImageR;

    [SerializeField]
    Transform magicPointTransform;

    public Queue<int> CardIdQueue => cardIdQueue;
    public List<int> PlayerCardIdInDeck => playerCardIdInDeck;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        cardListUI = FindAnyObjectByType<CardListUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("TestAddCard1_2_3")]
    public void TestAddCard()
    {
        AddCard(0);
    }

    [ContextMenu("ResetDeck")]
    public void ResetCardDeck()
    {
        cardListUI.RemoveAllCardUI();

        cardIdQueue.Clear();
        tempIntList.Clear();
        while (cardIdQueue.Count != playerCardIdInDeck.Count)
        {
            do
            {
                tempIdx = Random.Range(0, playerCardIdInDeck.Count);
            }
            while (cardIdQueue.Contains(tempIdx));

            cardIdQueue.Enqueue(tempIdx);
            tempIntList.Add(tempIdx);
        }

        cardListUI.AddCardUI(tempIntList);


    }

    public void AddCard(int cardId)
    {
        playerCardIdInDeck.Add(cardId);
    }

    public void ReadyCard(bool isLeft, Sprite magicSprite)
    {
        if (isLeft)
        {
            attackImageL.sprite = magicSprite;
            if (cardIdQueue.Count > 0)
                cardLIdx = CardIdQueue.Dequeue();
            else
                cardLIdx = -1;
        }
        else
        {
            attackImageR.sprite = magicSprite;
            if (cardIdQueue.Count > 0)
                cardRIdx = CardIdQueue.Dequeue();
            else
                cardRIdx = -1;
        }
    }

    public void UseCard(bool isLeft)
    {
        AssetAddressLoad.Instance.LoadPrefab(isLeft ? cardLIdx : cardRIdx, magicPointTransform);

        if(cardIdQueue.Count>0)
        {
            if (isLeft)
            {
                cardLIdx = cardIdQueue.Dequeue();
            }
            else
            {
                cardRIdx = cardIdQueue.Dequeue();
            }

            cardListUI.RemoveFirstCardUI();
        }
        else
        {
            if (isLeft)
            {
                cardLIdx = -1;
            }
            else
            {
                cardRIdx = -1;
            }
        }


    }

    public void RemoveCard(int cardDeckIdx)
    {
        playerCardIdInDeck.RemoveAt(cardDeckIdx);
    }
}
