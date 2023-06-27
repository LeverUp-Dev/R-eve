namespace Test
{
    class Student
    {
        public string Name { get; set; }
        public double Score { get; set; }

        public Student(string name, double score)
        {
            Name = name;
            Score = score;
        }

        public override string ToString()
        {
            return this.Name +":" + this.Score;
        }
    }

    class Students //리스트를 만들고 넣거나 출력 가능
    {
        List<Student> listStudent = new List<Student>();

        public delegate void PrintMethod(Student sty);

        public void Add(Student student)
        {
            listStudent.Add(student);
        }

        public void Print()
        {
            Print( (study) => { Console.WriteLine(study); });
        }

        public void Print(PrintMethod pm)
        {
            foreach (Student item in listStudent)
            {
                //Console.WriteLine(item.Name + ":" + item.Score);
                pm(item);
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Students students = new Students();
            students.Add(new Student("doyoung", 90.1));
            students.Add(new Student("jangwu", 97.2));

            students.Print();
            students.Print((study) =>
            {
                Console.WriteLine();
                Console.WriteLine(study.Name);
                Console.WriteLine(study.Score);
            });
        }
    }
}