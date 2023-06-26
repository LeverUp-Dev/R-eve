using System.IO;

namespace TestInterFace
{
    internal class Program
    {
        private static void Main(string[] args)//StreamWriter는 여러 줄을 쓸 파일을 만들 때 용이하다
        {
            using(StreamWriter writer = new StreamWriter(@"C:\Users\ododo\Desktop\test.txt"))
            {
                writer.WriteLine("안녕");
                writer.WriteLine("StreamWriter 클래스를 사용해보자!");
                writer.WriteLine("글자를 여러 줄 입력할 때 용이하다.");

                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine("숫자체크 -" + i);
                }
            }

            Console.WriteLine(File.ReadAllText(@"C:\Users\ododo\Desktop\test.txt"));
        }
    }
}