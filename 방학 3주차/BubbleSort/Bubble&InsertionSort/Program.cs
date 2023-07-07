using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Random r = new Random();
        int[] list = new int[10];

        //배열의 중복 제거 후 출력
        DedupePrint(list, r);
        //버블정렬 후 출력하기
        BubbleSortPrint(list);
    }

    //중복제거
    static void DedupePrint(int[] list, Random r)
    {
        for(int i=0; i<list.Length; i++)
        {
            int rand =  r.Next(99);
            for(int j =0; j<i; j++)
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

    static void BubbleSortPrint(int[] list)
    {
        int temp;

        for (int i=list.Length-1; i>0; i--)
        {
            for (int j=0; j<i; j++)
            {
                if (list[j] > list[j + 1])
                {
                    temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("\n정렬 후");
        Print(list);
    }
}