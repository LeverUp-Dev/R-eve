using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{    
    public GameObject disk;
    public Transform towersTr;
    public Transform spawnPoint;

    // 원반의 이동 과정을 저장할 리스트
    List<(int start,int end)> list = new List<(int, int)>();
    public int numDisk;
    int moveCount = 0;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        // 블럭을 Disk수 만큼 만들어 spawnPoint에 배치
        for (int i = 0; i < numDisk; i++)
        {
            GameObject instance = Instantiate(disk, spawnPoint);
            instance.name = (i + 1).ToString();
            instance.transform.parent = spawnPoint;
            instance.transform.localScale = new Vector3(3f - (i * 0.3f), 0.1f, 3f - (i * 0.3f));
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        Hanoi(numDisk, 1, 3, 2); //start, end, middle
        if (Input.GetMouseButtonDown(0)) 
        {            
            StartCoroutine(Move());
        }
    }

    public void Hanoi(int n, int start, int end, int middle)
    {
        if (n == 1)
        {
            list.Add((start, end)); // 마지막 이동을 리스트에 저장
            return;
        }

        Hanoi(n - 1, start, middle, end);
        list.Add((start, end)); // 확정된 이동을 리스트에 저장
        Hanoi(n - 1, middle, end, start);
    }

    // 리스트에 저장된 이동 순서대로 하나씩 이동 
    public IEnumerator Move()
    {
        print(list.Count);
        for(int i = 0; i < list.Count; i++)
        {
            yield return new WaitForSeconds(1.5f);
            moveCount++;
            print(moveCount + $": {list[i].start}_Top" + "->" + $"{list[i].end}_Top");

            Transform srartTr = towersTr.Find($"{list[i].start}_Top").transform;
            Transform endTr = towersTr.Find($"{list[i].end}_Top").transform;

            int count = srartTr.childCount;
            srartTr.GetChild(count - 1).position = endTr.position;            
            srartTr.GetChild(count - 1).parent = endTr;
        }     
    }    
}
