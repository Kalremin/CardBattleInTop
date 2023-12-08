using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    PlayerCharacter character;
    [SerializeField]
    GameObject gameoverImage;

    [SerializeField]
    TextMeshProUGUI floorText;

    float tempTime = 0, delayTime = 5f;
    private void Start()
    {
        character = FindAnyObjectByType<PlayerCharacter>();
    }

    private void Update()
    {
        if (!character.IsAlive && !gameoverImage.activeSelf)
        {
            tempTime += Time.deltaTime;
            if (tempTime >= delayTime)
            {
                tempTime = 0;
                floorText.text = FloorCountScr.Instance.Floor.ToString();
                gameoverImage.SetActive(true);

            }
        }
    }



    public void RestartBtn()
    {
        FloorCountScr.Instance.ResetFloor();
        PlayerStatSetting.Instance.ResetStat();
        SceneLoad.Instance.LoadScene(2);

    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
