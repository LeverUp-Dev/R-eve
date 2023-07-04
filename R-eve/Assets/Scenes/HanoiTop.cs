using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows.Speech;
using static UnityEngine.GraphicsBuffer;

public class Hanoi : MonoBehaviour
{
    int dNum = 5;

    public void HanoiTop(int dNum, Vector3 start, Vector3 assist, Vector3 target, GameObject obj)
    {
        if (obj.name == $"Cube{dNum}")
        {
            Move(start, target, obj);
        }
        else
        {
            HanoiTop(dNum - 1, start, target, assist, obj);
            Move(start, target, obj);
            HanoiTop(dNum - 1, assist, start, target, obj);
        }
    }

    public void Move(Vector3 zone, Vector3 zone2, GameObject obj)
    {
        obj.transform.position = Vector3.MoveTowards(zone, zone2, 2f);
    }
}
