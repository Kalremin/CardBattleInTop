using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneScr : MonoBehaviour
{
    public void NextScene(int val)
    {
        SceneLoad.Instance.LoadScene(val);
    }
}
