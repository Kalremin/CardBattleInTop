using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    ItemInDungeon objectInDungeon;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ItemInDungeon>(out ItemInDungeon tempObject)) 
        {
            objectInDungeon = tempObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out ItemInDungeon temp))
        {
            objectInDungeon = null;
        }
    }

    public void ActivateItem()
    {
        if (objectInDungeon != null)
        {
            objectInDungeon.ActivateInteraction();
        }
    }
}
