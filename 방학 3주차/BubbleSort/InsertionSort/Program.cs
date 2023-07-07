internal class Program
{
    private static void Main(string[] args)
    {
        Random r = new Random();
        int[] list = new int[10];

        //배열의 중복 제거 후 출력
        DedupePrint(list, r);
        //삽입정렬 후 출력하기
        InsertionSortPrint(list);
    }

    //중복제거
    static void DedupePrint(int[] list, Random r)
    {
        for (int i = 0; i < list.Length; i++)
        {
            int rand = r.Next(99);
            for (int j = 0; j < i; j++)
            {
                list[i] = rand;
                if (list[i] == list[j])
                    i--;
            }
        }

        Print(list);
    }

    //리스트 출력
    static void Print(int[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Console.Write($"{list[i]} ");
        }
    }

    static void InsertionSortPrint(int[] list)
    {
        int key;

        for (int i = 1; i < list.Length; i++)
        {
            key = list[i];
            for (int j = 0; j < i; j++)
            {
                if (list[j] > key)
                {
                    list[i] = list[j];
                    list[j] = key;
                }
            }
        }

        Console.WriteLine("\n정렬 후");
        Print(list);
    }
}