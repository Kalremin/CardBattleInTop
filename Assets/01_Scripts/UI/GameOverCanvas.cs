using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    PlayerCharacter character;
    [SerializeField]
    GameObject gameoverImage;

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
                gameoverImage.SetActive(true);

            }
        }
    }


    public void RestartBtn()
    {
        FloorCountScr.Instance.ResetFloor();
        SceneLoad.Instance.LoadScene(2);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
