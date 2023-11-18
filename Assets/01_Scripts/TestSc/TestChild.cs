using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("TestChild")]
    public void Test()
    {
        if(TryGetComponent<BaseCharacter>(out BaseCharacter character))
        {
            print("ye");
        }
    }
}
