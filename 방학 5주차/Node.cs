using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int x;
    public int y;
    public Vector3 position;

    public int gCost;
    public int hCost;
    public int fCost;
    public Node parent;

    public bool isWalkable;
    public bool isPath;

    public Node(int x, int y, Vector3 position)
    {
        this.x = x;
        this.y = y;
        this.position = position;

        isWalkable = true;
        isPath = false;
    }
}
