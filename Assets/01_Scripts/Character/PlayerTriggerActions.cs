using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerActions : MonoBehaviour
{
    PlayerCharacter character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponentInParent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseCardMagicL()
    {
        CardPlayer.Instance.UseCard(true, character.ManaPoint);
    }

    public void UseCardMagicR()
    {
        CardPlayer.Instance.UseCard(false, character.ManaPoint);
    }
}
