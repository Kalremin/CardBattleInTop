using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TestNavAgent : MonoBehaviour
{
    [SerializeField] Transform[] movePoint;

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
        navAgent.destination = isch ? movePoint[0].position : movePoint[1].position;
        isch = !isch;
        
    }

    [ContextMenu("Stop")]
    public void Stop()
    {
        navAgent.isStopped = true;
    }

    [ContextMenu("Resume")]
    public void Resume()
    {
        navAgent.isStopped = false;
    }


}
