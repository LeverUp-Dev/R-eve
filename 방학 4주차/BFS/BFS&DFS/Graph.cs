using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS
{
    internal class Graph
    {
        private int vertex; // 그래프의 정점 갯수
        private List<int>[] adj; //인접리스트로 그래프를 구현할 것이기에 int형 리스트 선언

        public Graph(int v)
        {
            //속성 초기화
            vertex = v;
            adj = new List<int>[v];//초기화 및 리스트크기 설정
            for (int i = 0; i < v; i++)
                adj[i] = new List<int>();//리스트 초기화
        }

        //그래프에서 정점과 정점을 연결하는 함수
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w); //v에서 w로 가는 선을 추가
        }

        //너비우선검색(BFS)
        public void BFS(int startVertex)
        {
            bool[] visited = new bool[vertex];//bool형 배열의 크기를 정점의 갯수만큼 할당
            Queue<int> queue = new Queue<int>();//큐를 이용하여 검색할 것이기에 큐를 선언

            visited[startVertex] = true; //탐색을 시작할 정점을 true로 초기화(방문하였기에)
            queue.Enqueue(startVertex); //시작점을 초기화

            while (queue.Count != 0) //큐의 길이가 0이 아닐때만 반복
            {
                startVertex = queue.Dequeue(); //탐색 시작 위치를 변경
                Console.Write(startVertex + " ");//탐색 순서를 출력

                foreach (int i in adj[startVertex])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }
        }

        //깊이우선검색(DFS)
        public void DFS(int startVertex)
        {
            bool[] visited = new bool[vertex];//bool형 배열의 크기를 정점의 갯수만큼 할당
            Stack<int> stack = new Stack<int>();//DFS는 스택을 이용하여 구현

            visited[startVertex] = true; //탐색을 시작할 정점을 true로 초기화(방문하였기에)
            stack.Push(startVertex); //시작점을 초기화

            while (stack.Count != 0) //스택의 길이가 0이 아닐때만 반복
            {
                startVertex = stack.Pop(); //탐색 시작 위치를 변경
                Console.Write(startVertex + " ");//탐색 순서를 출력

                foreach (int i in adj[startVertex])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }
    }
}
