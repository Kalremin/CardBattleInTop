using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorUI : MonoBehaviour
{
    int count;

    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        count = FloorCountScr.Instance.Floor;
        text.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(FloorCountScr.Instance.Floor != count)
        {
            count = FloorCountScr.Instance.Floor;
            text.text = count.ToString();
        }

        
    }
}
