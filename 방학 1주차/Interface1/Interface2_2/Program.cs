namespace TestInterFace
{

    internal class Program
    {
        class Student
        {
            public int ID;
            public int score;
        }

        private static void Main(string[] args)
        {
            List<Student> numbers = new List<Student>()
            {
                new Student() {ID=7, score=63},
                new Student() {ID=1, score=99},
                new Student() {ID=3, score=73},
                new Student() {ID=9, score=81}
            };
            numbers.Sort();

            foreach(Student num in numbers)
            {
                Console.WriteLine(num);
            }

        }
    }
}
