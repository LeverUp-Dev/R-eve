using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    const int DIAGONAL_WEIGHT = 14;
    const int STRAIGHT_WEIGHT = 10;

    CGrid grid;

    MinHeap<Node> openedHeap;
    HashSet<Node> closedList;

    public AStar()
    {
        grid = CGrid.Instance;

        openedHeap = new MinHeap<Node>(grid.gridXSize * grid.gridYSize * 8);
        closedList = new HashSet<Node>();
    }

    public Node FindPath(Node start, Node end)
    {
        closedList.Add(start);

        SearchNearNodes(start, end);

        Node minCostNode;
        while ((minCostNode = openedHeap.Pop()) != null)
        {
            if (minCostNode.hCost == 0)
                break;

            closedList.Add(minCostNode);

            SearchNearNodes(minCostNode, end);
        }

        if (minCostNode == null)
            Debug.LogError("¸ø Ã£À½");

        return minCostNode;
    }

    public void SearchNearNodes(Node target, Node end)
    {
        int x = target.x - 1;
        int y = target.y - 1;

        for (int i = x; i < x + 3; ++i)
        {
            for (int j = y; j < y + 3; ++j)
            {
                if (i < 0 || i >= grid.gridXSize || j < 0 || j >= grid.gridYSize)
                    continue;

                Node node = grid.nodes[i, j];

                if (closedList.Contains(node))
                    continue;

                if (!node.isWalkable)
                    continue;

                int gCost = target.gCost + (IsDiagonal(node, target) ? DIAGONAL_WEIGHT : STRAIGHT_WEIGHT);
                int hCost = (Mathf.Abs(node.x - end.x) + Mathf.Abs(node.y - end.y)) * STRAIGHT_WEIGHT;
                int fCost = gCost + hCost;

                if (node.fCost != 0 && node.fCost < fCost)
                    continue;

                node.gCost = gCost;
                node.hCost = hCost;
                node.fCost = fCost;
                node.parent = target;

                openedHeap.Insert(fCost, node);
            }
        }
    }

    private bool IsDiagonal(Node node, Node target)
    {
        int dx = node.x - target.x;
        int dy = node.y - target.y;

        if (dx == 0 || dy == 0)
            return false;

        return true;
    }
}
