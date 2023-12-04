using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureItem : ItemInDungeon
{
    int cardIdx;
    Animator animator;
    [SerializeField]
    GameObject magicItem;
    // Start is called before the first frame update
    void Start()
    {
        cardIdx = Random.Range(0, CardsAsset.Instance.CountAllCard);
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (magicItem.activeSelf)
        {
            magicItem.transform.Rotate(Vector3.up);
        }
    }

    public override void ActivateInteraction()
    {
        if (used)
            return;
        CardPlayer.Instance.AddCard(cardIdx);
        magicItem.SetActive(false);
        used = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerCharacter character))
        {
            animator.SetTrigger("open");
            
        }
    }

    public void ShowMagicItem()
    {
        magicItem.GetComponent<Renderer>().material = CardsAsset.Instance.GetMagic(cardIdx).magicMat;
        magicItem.SetActive(true);
    }





}
