using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    static SceneLoad instance;
    public static SceneLoad Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void LoadScene(string sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
