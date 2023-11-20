using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public enum DeckState
{
    Ready,
    Reset,
    Play
}
public class CardPlayer : MonoBehaviour
{
    

    static CardPlayer instance;
    public static CardPlayer Instance=>instance;

    DeckState nowState;

    bool isResetDeck = false;
    int tempIdx;
    int cardLIdx=-1;
    int cardRIdx=-1;

    List<int> playerCardsDeck = new List<int>(); // 가지고 있는 카드 리스트
    List<int> cardIdxList = new List<int>();    // 사용할 카드리스트
    Queue<int> tempIdxQueue = new Queue<int>(); // 임시 

    CardListUI cardListUI;

    [SerializeField]
    Transform magicPointTransform;
    void Start()
    {
        instance = this;

        cardListUI = FindAnyObjectByType<CardListUI>();
        TestAddCardT();
        ChangeState(DeckState.Ready);
    }

    // Update is called once per frame
    void Update()
    {
        switch (nowState)
        {
            case DeckState.Ready:// 카드 사용

                if (cardLIdx == -1 && cardRIdx == -1)
                {
                    /* 덱 딜레이 기능 추가*/
                    ResetCardDeck();
                    ChangeState(DeckState.Reset);
                }


                break;
            case DeckState.Reset:// 리셋
                if (cardListUI.transform.childCount == cardIdxList.Count)
                {
                    ChangeState(DeckState.Play);
                }


                break;
            case DeckState.Play:// UI 리스트 불러오기
                if (cardIdxList.Count == 0)
                    ChangeState(DeckState.Ready);

                if (cardLIdx == -1)
                {
                    cardLIdx = cardIdxList[cardIdxList.Count-1];
                    cardIdxList.RemoveAt(cardIdxList.Count - 1);
                    cardListUI.RemoveFirstCardUI(true);
                }
                else if (cardRIdx == -1)
                {
                    cardRIdx = cardIdxList[cardIdxList.Count - 1];
                    cardIdxList.RemoveAt(cardIdxList.Count - 1);
                    cardListUI.RemoveFirstCardUI(false);
                }


                break;
        }
    }

    [ContextMenu("Ready")]
    public void Ready() => ChangeState(DeckState.Ready);


    [ContextMenu("ResetDeck")]
    public void ResetDeck() => ChangeState(DeckState.Reset);


    [ContextMenu("PlayDeck")]
    public void PlayDeck() => ChangeState(DeckState.Play);

    public void ChangeState(DeckState state) => nowState = state;



    [ContextMenu("TestAddCard")]
    public void TestAddCardT()
    {
        AddCard(0);
        AddCard(1);
        AddCard(2);
    }

    [ContextMenu("ResetDeck")]
    public void ResetCardDeck()
    {
        cardListUI.RemoveAllCardUI();

        tempIdxQueue.Clear();
        cardIdxList.Clear();
        while (tempIdxQueue.Count != playerCardsDeck.Count)
        {
            do
            {
                tempIdx = Random.Range(0, playerCardsDeck.Count);
            }
            while (tempIdxQueue.Contains(tempIdx));//

            tempIdxQueue.Enqueue(tempIdx); // 
            cardIdxList.Add(playerCardsDeck[tempIdx]); // 무작위 리스트 등록
        }

        cardListUI.AddCardUI(cardIdxList);


        //AssetAddressLoad.Instance.LoadSprite(playerCardIdInDeck[useCardsIndexQueue.Dequeue()], attackImageL);

    }




    [ContextMenu("MagicIDX")]
    public void PrintMagic()
    {
        print("L: " + cardLIdx + ", R: " + cardRIdx);
    }

    [ContextMenu("show")]
    public void Show()
    {
        string tempstring = "";
        foreach(var temp in cardIdxList)
        {
            tempstring += temp.ToString() + ", ";
        }

        print(tempstring);
    }

    public void AddCard(int cardId)
    {
        playerCardsDeck.Add(cardId);
    }


    public void UseCard(bool isLeft)
    {
        if (nowState == DeckState.Reset)
            return;

        

        if (isLeft && cardLIdx!=-1)
        {

            AssetAddressLoad.Instance.LoadPrefab(cardLIdx, magicPointTransform);
            cardLIdx = -1;
            
        }

        if(!isLeft && cardRIdx != -1)
        {
            AssetAddressLoad.Instance.LoadPrefab(cardRIdx, magicPointTransform);
            cardRIdx = -1;
        }

        cardListUI.RemoveSpriteAttack(isLeft);

    }
}
