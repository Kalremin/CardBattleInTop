using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFloorScr : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FloorCountScr.Instance.UpFloor();

            PlayerStatSetting.Instance.SaveStat(
                PlayerCharacter.Instance.HealthPoint,
                PlayerCharacter.Instance.MaxHealthPoint,
                PlayerCharacter.Instance.ManaPoint,
                PlayerCharacter.Instance.MaxManaPoint,
                PlayerCharacter.Instance.HealthRegen,
                PlayerCharacter.Instance.ManaRegen,
                PlayerCharacter.Instance.MoveSpeed
                );
            PlayerStatSetting.Instance.playerCardsDeck.Clear();

            foreach(var card in CardPlayer.Instance.PlayerCardsDeck)
            {
                PlayerStatSetting.Instance.playerCardsDeck.Add(card);
            }
            

            SceneLoad.Instance.LoadScene(2);
        }
    }
}
