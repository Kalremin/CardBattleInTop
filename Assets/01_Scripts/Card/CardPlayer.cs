using System;
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

    int tempIdx;
    int cardLIdx=-1;
    int cardRIdx=-1;

    List<MagicCard> playerCardsDeck = new List<MagicCard>(); // 가지고 있는 카드 리스트
    List<MagicCard> cardIdxList = new List<MagicCard>();    // 사용할 카드리스트
    Queue<int> tempIdxQueue = new Queue<int>(); // 임시 저장

    CardListUI cardListUI;
    PlayerCharacter character;

    [SerializeField]
    Transform magicPointTransform;

    [SerializeField]
    Transform magicAreaEffectTransform;

    public int CardLIdx => cardLIdx;
    public int CardRIdx => cardRIdx;

    private void Awake()
    {
        instance = this;

        cardListUI = FindAnyObjectByType<CardListUI>();
        character = FindAnyObjectByType<PlayerCharacter>();
    }
    void Start()
    {
        //instance = this;

        //cardListUI = FindAnyObjectByType<CardListUI>();
        //TestAddCardT();
        //ChangeState(DeckState.Ready);
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
                    cardLIdx = cardIdxList[cardIdxList.Count-1].idx;
                    cardIdxList.RemoveAt(cardIdxList.Count - 1);
                    cardListUI.RemoveFirstCardUI(true);
                }
                else if (cardRIdx == -1 && cardIdxList.Count > 0)
                {
                    cardRIdx = cardIdxList[cardIdxList.Count - 1].idx;
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
        AddCard(0);
        AddCard(2);
        AddCard(0);
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
                tempIdx = UnityEngine.Random.Range(0, playerCardsDeck.Count);
            }
            while (tempIdxQueue.Contains(tempIdx));//

            tempIdxQueue.Enqueue(tempIdx); // 
            cardIdxList.Add(playerCardsDeck[tempIdx]); // 무작위 리스트 등록
        }

        cardListUI.AddCardUI(cardIdxList);


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
        playerCardsDeck.Add(CardsAsset.Instance.GetMagic(cardId));


    }


    public bool UseCard(bool isLeft, float curManaPoint)
    {
        if (nowState == DeckState.Reset)
            return false;

        if (isLeft && cardLIdx!=-1)
        {
            if (curManaPoint >= CardsAsset.Instance.GetMagic(cardLIdx).costManaPoint)
            {
                character.CostManaPoint(CardsAsset.Instance.GetMagic(cardLIdx).costManaPoint);

                if(CardsAsset.Instance.GetMagic(cardLIdx).isArea)
                    ObjectPooling.Instance.InstantiateEffect(cardLIdx, magicAreaEffectTransform);
                else
                    ObjectPooling.Instance.InstantiateEffect(cardLIdx, magicPointTransform);
                cardLIdx = -1;

                cardListUI.RemoveSpriteAttack(isLeft);

                return true;
            }
            
        }

        if(!isLeft && cardRIdx != -1)
        {
            if (curManaPoint >= CardsAsset.Instance.GetMagic(cardRIdx).costManaPoint)
            {
                character.CostManaPoint(CardsAsset.Instance.GetMagic(cardRIdx).costManaPoint);

                if (CardsAsset.Instance.GetMagic(cardRIdx).isArea)
                    ObjectPooling.Instance.InstantiateEffect(cardRIdx, magicAreaEffectTransform);
                else
                    ObjectPooling.Instance.InstantiateEffect(cardRIdx, magicPointTransform);
                cardRIdx = -1;
                cardListUI.RemoveSpriteAttack(isLeft);
                return true;
            }
        }

        return false;
        

    }

    
}
