namespace Test
{
    delegate void MyDel(int a, int b);

    internal class Program
    {
        private static void Main(string[] args)
        {
            MyDel myDel1, mydel2;

            myDel1 = (a, b) => { Console.WriteLine(a + b); };
            mydel2 = (a, b) => { Console.WriteLine(a - b); };

            myDel1 = myDel1 + mydel2;
            myDel1 = myDel1 - mydel2;

            myDel1(5, 3);
        }
    }
}