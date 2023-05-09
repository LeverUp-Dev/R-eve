namespace CatBreeding
{
    internal class Cat
    {
        public string Name;
        public int Age;
        private int Hapiness;

        public Cat (string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Hapiness = 60;
        }

        public void GetBoard()
        {
            Hapiness -= 10;
            if (Hapiness < 0)
                Hapiness = 0;
        }

        public void Play()
        {
            Hapiness += 10;
            if (Hapiness > 100)
                Hapiness = 100;
        }

        public void Eat()
        {
            Hapiness += 20;
            if (Hapiness > 100)
                Hapiness = 100;
        }

        public void Express()
        {
            string message = "";
            if (Hapiness >= 80)
                message = "I'm very happy";
            else if (Hapiness >= 60)
                message = "I'm happy";
            else if (Hapiness >= 40)
                message = "I'm so so";
            else if (Hapiness >= 30)
                message = "I'm gloomy";
            else
                message = "I'm sad";

            System.Console.WriteLine(this.Name + ":" + message);
        }
    }
}