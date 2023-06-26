using System.IO;
using System.Runtime.CompilerServices;

namespace TestInterFace
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //StreamReader는 지정한 txt를 한줄씩 읽는다
            /*
            using (StreamReader reader = new StreamReader(@"C:\Users\ododo\Desktop\test.txt"))
            {
                string read = reader.ReadLine();
                Console.WriteLine(read);
            }*/

            //여러줄 읽을 때
            using (StreamReader reader = new StreamReader(@"C:\Users\ododo\Desktop\test.txt"))
            {
                string read;
                while ((read = reader.ReadLine()) != null)
                    Console.WriteLine(read);
            }
        }
    }
}