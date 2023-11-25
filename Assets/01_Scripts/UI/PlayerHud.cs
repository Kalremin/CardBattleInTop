using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    PlayerCharacter character;

    [SerializeField] Slider playerHealth;
    [SerializeField] Slider playerMana;

    private void Awake()
    {
        character = FindAnyObjectByType<PlayerCharacter>();
    }
    // Update is called once per frame
    void Update()
    {
        playerHealth.value = character.HealthPoint / character.MaxHealthPoint;
        playerMana.value = character.ManaPoint / character.MaxManaPoint;

        //print(character.HealthPoint + ", " + character.MaxHealthPoint);
        //print(character.ManaPoint + ", " + character.MaxManaPoint);

        //Debug.Log(string.Format("{0:0.00}", character.ManaPoint));
        //print(character.HealthPoint);
        //print(character.ManaPoint);

    }
}
