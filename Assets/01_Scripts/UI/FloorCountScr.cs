using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCountScr : MonoBehaviour
{
    static FloorCountScr instance;
    public static FloorCountScr Instance => instance;

    int nowFloor = 1;

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

    public void UpFloor()
    {
        nowFloor++;
    }

    public int Floor => nowFloor;

    public void ResetFloor()
    {
        nowFloor = 0;
    }

}
