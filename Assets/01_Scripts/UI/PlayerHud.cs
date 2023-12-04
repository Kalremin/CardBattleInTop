using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{

    [SerializeField] Slider playerHealth;
    [SerializeField] Slider playerMana;

    // Update is called once per frame
    void Update()
    {
        playerHealth.value = PlayerCharacter.Instance.HealthPoint / PlayerCharacter.Instance.MaxHealthPoint;
        playerMana.value = PlayerCharacter.Instance.ManaPoint / PlayerCharacter.Instance.MaxManaPoint;

        //print(character.HealthPoint + ", " + character.MaxHealthPoint);
        //print(character.ManaPoint + ", " + character.MaxManaPoint);

        //Debug.Log(string.Format("{0:0.00}", character.ManaPoint));
        //print(character.HealthPoint);
        //print(character.ManaPoint);

    }
}
