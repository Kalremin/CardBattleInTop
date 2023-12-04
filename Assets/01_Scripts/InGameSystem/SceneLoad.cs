using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoad
{
    
    public static void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public static void LoadScene(string sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
