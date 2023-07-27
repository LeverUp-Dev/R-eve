using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    void Start()
    {
        AStar astar = new AStar();

        Node next = astar.FindPath(CGrid.Instance.nodes[1, 3], CGrid.Instance.nodes[2, 0]);

        while (next != null)
        {
            next.isPath = true;
            next = next.parent;
        }
    }
}
