using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFloorScr : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneLoad.Instance.LoadScene(2);
        }
    }
}
