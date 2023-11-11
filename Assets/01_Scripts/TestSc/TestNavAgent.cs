using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavAgent : MonoBehaviour
{
    NavMeshAgent navAgent;

    bool isch = false;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Move")]

    public void Move()
    {
        navAgent.destination = isch ? new Vector3(-1, transform.position.y, -1) : new Vector3(1, transform.position.y, 1);
        isch = !isch;
        
    }


}
