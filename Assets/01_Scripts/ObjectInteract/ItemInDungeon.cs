using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemInDungeon : MonoBehaviour
{
    [SerializeField] protected UnityEvent eventItem;

    protected bool used = false;
    
    public virtual void ActivateInteraction()
    {
        print("par");
    }
}
