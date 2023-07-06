namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] array = { "가", "나", "다" };
            int input = int.Parse(Console.ReadLine());

            if (input < array.Length)
                Console.WriteLine("입력위치는 " + array[input] + " 입니다.");
            else
                Console.WriteLine("인덱스 범위를 벗어났습니다.");
        }
    }
}