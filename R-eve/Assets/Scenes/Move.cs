using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.XR;

public class Move : MonoBehaviour
{
    public GameObject[] disks;
    Vector3 target1 = new Vector3(-8, 0.5f, 0);
    Vector3 target2 = new Vector3(0, 0.5f, 0);
    Vector3 target3 = new Vector3(8, 0.5f, 0);
    int dNum = 5;

    Hanoi hanoi = new Hanoi();

    void Update()
    {
        //hanoi.HanoiTop(1, target1, target2, target3, gameObject);
            disks[0].transform.position = Vector3.MoveTowards(transform.position, target3, 2f);
    }
}
