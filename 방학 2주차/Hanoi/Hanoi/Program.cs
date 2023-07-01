using System.Text;

internal class Program
{
    class HanoiTop
    {
        public static StringBuilder sb = new StringBuilder();

        public static void Hanoi(int n, string start, string assist, string target)
        {
            if(n == 1)
            {
                sb.Append($"{n}번 디스크는 {start}기둥에서 {target}기둥으로 이동\n");
            }
            else
            {
                Hanoi(n - 1, start, target, assist);
                sb.Append($"{n}번 디스크는 {start}기둥에서 {target}기둥으로 이동\n");
                Hanoi(n - 1, assist, start, target);
            }
        }

    }
    private static void Main(string[] args)
    {
        Console.Write("디스크 갯수 입력:");
        int diskNum = int.Parse(Console.ReadLine());

        HanoiTop.Hanoi(diskNum, "A", "B", "C");

        Console.WriteLine(HanoiTop.sb);
    }
}