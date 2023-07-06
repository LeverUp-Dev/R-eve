namespace TestInterFace
{
    interface ICar
    {
        void Translate();
        void Rotate();
    }

    class Hyundai : ICar//ICar 인터페이스를 상속 받았기 때문에 무조건 ICar의 기본 기능을 구현해야 됨
    {
        public String name = "Avante";

        public void Rotate()
        {
            Console.WriteLine("Rotate");
        }

        public void Translate()
        {
            Console.WriteLine("Move");
        }
    }

    class Telsa : ICar //ICar 인터페이스를 상속 받았기 때문에 무조건 ICar의 기본 기능을 구현해야 됨
    {
        public String name = "Model3";

        public void Rotate()
        {
            Console.WriteLine("Rotate");
        }

        public void Translate()
        {
            Console.WriteLine("Move");
        }

        public void SelfDriving()
        {
            Console.WriteLine("FSD");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Hyundai myCar1Avante = new Hyundai();
            Telsa myCar2Model3 = new Telsa();
            Telsa myCar3ModelX = new Telsa();

            //Translate(), Rotate()는 ICar 인터페이스가 정해준 기본 기능(무조건 구현해야되는 기능)
            //SelfDriving()는 Tesla에서 만든 독자적인 추가 기능
            myCar1Avante.Translate();
            myCar1Avante.Rotate();
            myCar2Model3.Translate();
            myCar2Model3.Rotate();
            myCar3ModelX.Translate();
            myCar3ModelX.Rotate();
            myCar3ModelX.SelfDriving();

        }
    }
}
