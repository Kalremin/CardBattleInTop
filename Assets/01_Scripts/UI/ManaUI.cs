using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUI : MonoBehaviour
{
    int manaCount;
    int temp;
    // Start is called before the first frame update
    void Start()
    {
        manaCount = PlayerCharacter.Instance.SetManaPointInt();

        for(int i = 0; i < manaCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (manaCount != PlayerCharacter.Instance.ManaPointInt)
        {
            temp = PlayerCharacter.Instance.ManaPointInt;

            if (manaCount < temp)
            {
                for (int i = 0; i < manaCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            else
            {
                for(int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }

                for (int i = 0; i < temp; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }

            manaCount = temp;
        }
    }
}
