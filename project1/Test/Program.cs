using System.ComponentModel.Design.Serialization;

internal class Program
{
    public static float Root(int a)
    {
        float c = 1.0f;
        while (true)
        {
            c = c + 0.01f;
            if ((c * c) >= a)
                break;
        }
        return (int)(c * 100) / 100.0f; ;
    }
    private static void Main(string[] args)
    {
        float value;
        value = Root(10);
        Console.WriteLine("결과");
        Console.WriteLine(value);
    }
}