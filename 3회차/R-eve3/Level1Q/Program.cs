internal class Program
{
    private static void Main(string[] args)
    {
        int[,] sizes = { { 60, 50}, { 30, 70},
            { 60, 30}, { 80, 40} };

        int ans = solution(sizes);
        Console.WriteLine(ans);
    }

    private static int solution(int[,] sizes)
    {
        List<int> large = new List<int>();
        List<int> small = new List<int>();

        int len = sizes.GetLength(0) - 1;

        for (int i = 0; i <= len; i++)
        {
            if (sizes[i, 1] = sizes)
        }
    }
}