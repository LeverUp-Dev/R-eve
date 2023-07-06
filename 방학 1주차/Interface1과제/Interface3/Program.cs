using System.IO;

namespace TestInterFace
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            File.WriteAllText(@"C:\Users\ododo\Desktop\test.txt", "Good!!");//파일 생성
            Console.WriteLine(File.ReadAllText(@"C:\Users\ododo\Desktop\test.txt"));//설정한 경로에 파일을 불러오고 내용을 출력해라
        }
    }
}
