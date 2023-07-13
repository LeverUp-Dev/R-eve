using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

internal class Program
{
    public static bool Palindrome(string str)
    {
        //대문자를 모두 소문자로 변경
        //문자열 중에 한글과 영문을 제외한 모든문자를 삭제(공백도 삭제)
        string result = Regex.Replace(str.ToLower() , @"[^a-zA-Z0-9가-힣]", "");

        bool isPalindrome = true;
        //입력받은 문자열이 홀수 일 때
        if (result.Length%2 == 1)
        {
            int low = 0, high = result.Length-1;
            for (int i = 0; i < result.Length/2; i++)
            {
                if(result[low] != result[high])
                {
                    isPalindrome = false;
                }
                low++;
                high--;
            }
        }

        //입력받은 문자열이 짝수 일 때
        else if (result.Length % 2 == 0)
        {
            int low = 0, high = result.Length - 1;
            for (int i = 0; i < (result.Length / 2 )+1; i++)
            {
                if (result[low] != result[high])
                {
                    isPalindrome = false;
                }
                low++;
                high--;
            }
        }
        return isPalindrome;
    }

    public static bool Palindrome2(string str)
    {
        Queue<char> queue = new Queue<char>();
        Stack<char> stack = new Stack<char>();

        string result = Regex.Replace(str.ToLower(), @"[^a-zA-Z0-9가-힣]", "");

        for (int i = 0; i < result.Length; i++)
        {
            stack.Push(result[i]);
            queue.Enqueue(result[i]);
        }

        while (queue.Count != 0)
        {
            string q = queue.Dequeue().ToString();
            string s = stack.Pop().ToString();

            if(q != s)
            {
                return false;
            }
        }
        return true;
    }

    private static void Main(string[] args) 
    {
        Console.WriteLine("Exit를 입력시 종료");
        string input = null;
        while (input != "Exit")
        {   
            input = Console.ReadLine();
            Console.Write("회문인가? ");
            //Console.WriteLine(Palindrome(input));
            Console.WriteLine(Palindrome2(input));
        }
    }
}