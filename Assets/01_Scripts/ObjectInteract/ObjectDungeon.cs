using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDungeon : MonoBehaviour
{
    enum ObjectType
    {
        Obelisk,
        MagicTreasure
    }

    [SerializeField] ObjectType type;
    int cardIdx;

    private void Start()
    {
        cardIdx = Random.Range(0, CardsAsset.Instance.CountAllCard);
    }

    public void ActivateInteraction()
    {
        switch (type)
        {
            case ObjectType.MagicTreasure:
                CardPlayer.Instance.AddCard(cardIdx);

                break;
            case ObjectType.Obelisk:
                //PlayerCharacter.
                break;
        }
    }
}
