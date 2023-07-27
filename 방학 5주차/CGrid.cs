using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGrid : MonoBehaviour
{
    public static CGrid Instance { get; private set; }

    public int gridXSize;
    public int gridYSize;
    public int nodeDiameter;
    public float lineWidth;

    public Node[,] nodes;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        Vector3 start = transform.position + nodeDiameter * (gridXSize / 2) * Vector3.left + nodeDiameter * (gridYSize / 2) * Vector3.forward;

        nodes = new Node[gridXSize, gridYSize];
        for (int i = 0; i < gridXSize; ++i)
        {
            for (int j = 0; j < gridYSize; ++j)
            {
                nodes[i, j] = new Node(i, j, start + nodeDiameter * i * Vector3.right + nodeDiameter * j * Vector3.back);
            }
        }

        for (int i = 0; i < 4; ++i)
            nodes[i, 1].isWalkable = false;
    }

    private void OnDrawGizmos()
    {
        if (nodes != null)
        {
            foreach (Node node in nodes)
            {
                if (node.isPath)
                    Gizmos.color = Color.blue;
                else if (node.isWalkable)
                    Gizmos.color = Color.white;
                else
                    Gizmos.color = Color.red;

                Gizmos.DrawCube(node.position, Vector3.one * (nodeDiameter - lineWidth));
            }
        }
    }
}
