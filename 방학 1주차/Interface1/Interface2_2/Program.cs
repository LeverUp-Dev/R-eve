namespace TestInterFace
{

    internal class Program
    {
        class Student : IComparable
        {
            public int ID;
            public int score;

            public override string ToString()
            {
                return ID + ":" + score;
            }

            public int CompareTo(object obj)
            {
                //방법1
                return ((obj as Student).score.CompareTo(this.score)); //정렬 순서를 바꾸고 싶으면 this와 obj를 서로 바꿔주면 됨

                /* 방법2
                if(this.score > (obj as Student).score) //ID로 정렬하고 싶으면 score을 ID로 바꾸면 됨
                {
                    return -1;
                }else
                {
                    return 1;
                }// 싶으면 return값을 서로 바뀌주면 된 */
            }
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
