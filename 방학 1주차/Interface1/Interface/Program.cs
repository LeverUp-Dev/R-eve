namespace TestInterFace
{
    interface ICar
    {
        void Translate();
        void Rotate();
    }

    class Hyundai : ICar
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

    class Telsa : ICar
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
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Hyundai myCar1Avante = new Hyundai();
            Telsa myCar2Model3 = new Telsa();
            Telsa myCar3ModelX = new Telsa();

            myCar1Avante.Translate();
            myCar1Avante.Rotate();
            myCar2Model3.Translate();
            myCar2Model3.Rotate();
            myCar3ModelX.Translate();
            myCar3ModelX.Rotate();

        }
    }
}
