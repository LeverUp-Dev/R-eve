
namespace Point
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Point dot1 = new Point(5.1f, 9.2f);
            Point dot2 = new Point(6.3f, 5.2f);

            Point dot3 = dot1.Add(dot2);
            dot3.Print();
        }

    }
}
