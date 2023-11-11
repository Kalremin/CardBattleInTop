using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class TestNavBake : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshSurface navSurface;

    void Start()
    {
        navSurface = GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("Bake")]
    public void BakeMesh()
    {
        navSurface.BuildNavMesh();
    }

    [ContextMenu("Clear")]
    public void ClearBake()
    {
        navSurface.RemoveData();
    }
}
