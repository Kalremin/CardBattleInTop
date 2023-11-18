using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : BaseCharacter, ICharacterAct
{
    int tempIdx;
    int cardLIdx;
    int cardRIdx;
    float deckResetDuration = 2f;

    List<int> playerCardIdInDeck = new List<int>();
    List<int> temp = new List<int>();
    Queue<int> cardIdQueue = new Queue<int>();

    CardListUI cardListUI;

    public Queue<int> CardIdQueue => cardIdQueue;

    private void Start()
    {
        cardListUI = FindAnyObjectByType<CardListUI>();
    }

    private void Update()
    {
        
    }

    public void ResetCardDeck()
    {
        cardIdQueue.Clear();
        temp.Clear();
        
        while(cardIdQueue.Count != playerCardIdInDeck.Count)
        {
            do
            {
                tempIdx = Random.Range(0, playerCardIdInDeck.Count);
            }
            while ( cardIdQueue.Contains(tempIdx));

            cardIdQueue.Enqueue(tempIdx);
        }

        cardLIdx = cardIdQueue.Dequeue();
        cardRIdx = cardIdQueue.Dequeue();

    }

    public void AddCard(int cardId)
    {
        playerCardIdInDeck.Add(cardId);
    }
    
    public void RemoveCard(int cardDeckIdx)
    {
        playerCardIdInDeck.RemoveAt(cardDeckIdx);
    }

    public void UseCardL()
    {
        ActivateMagic(cardLIdx);
        if (cardIdQueue.Count > 0)
            cardLIdx = cardIdQueue.Dequeue();
        else
            cardLIdx = -1;

        if (cardIdQueue.Count == 0)
            ResetCardDeck();
    }


    public void UseCardR()
    {
        ActivateMagic(cardRIdx);
        if (cardIdQueue.Count > 0)
            cardRIdx = cardIdQueue.Dequeue();
        else
            cardRIdx = -1;

        if (cardIdQueue.Count == 0)
            ResetCardDeck();
    }
    private void ActivateMagic(int cardLIdx)
    {
        throw new System.NotImplementedException();
    }

    #region ICharacterAct
    public override void AttackL()
    {
        throw new System.NotImplementedException();
    }

    public override void AttackR()
    {
        throw new System.NotImplementedException();
    }

    public override void Hitted(float damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Idle()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
