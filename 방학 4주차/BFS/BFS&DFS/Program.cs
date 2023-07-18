using BFS_DFS;

internal class Program
{
    private static void Main(string[] args)
    {
        Graph graph = new Graph(6); //Vertex
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);

        Console.WriteLine("BFS 탐색 결과:");
        graph.BFS(0);

        Console.WriteLine("\nDFS 탐색 결과:");
        graph.DFS(0);
    }
}