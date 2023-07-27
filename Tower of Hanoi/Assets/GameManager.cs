using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject pillar1;
    public GameObject pillar2;
    public GameObject pillar3;

    public GameObject Disk1;
    public GameObject Disk2;
    public GameObject Disk3;

    List<GameObject> disks;

    private void Awake()
    {
        disks = new List<GameObject>();
        disks.Add(Disk1);
        disks.Add(Disk2);
        disks.Add(Disk3);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Hanoi(3, pillar1, pillar2, pillar3));
    }

    private IEnumerator Hanoi(int num, GameObject from, GameObject via, GameObject to)
    {
        yield return new WaitForSeconds(0.5f);
        if (num == 1)
        {
            yield return StartCoroutine(MoveDisk(num - 1, disks[num - 1], from, to));
        }
        else
        {
            yield return StartCoroutine(Hanoi(num - 1, from, to, via));
            yield return StartCoroutine(MoveDisk(num - 1, disks[num - 1], from, to));
            yield return StartCoroutine(Hanoi(num - 1, via, from, to));
        }
    }

    private IEnumerator MoveDisk(int num, GameObject disk, GameObject from, GameObject to)
    {
        disk.transform.position = new Vector3(to.transform.position.x, -num - 3.5f, -2);
        yield return new WaitForSeconds(0.5f);
    }
}
