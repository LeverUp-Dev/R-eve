namespace TestInterFace
{
    interface ICallable
    {
        void Call();
    }

    class AndroidPhone : ICallable
    {
        void ICallable.Call()
        {
            Console.WriteLine("And Call");
        }
    }

    class ApplePhone : ICallable
    {
        public void Call()
        {
            Console.WriteLine("Apple Call");
        }
    }

    class PayPhone : ICallable
    {
        public void Call()
        {
            Console.WriteLine("Pay Call");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<ICallable> phoneList = new List<ICallable>();

            ICallable and = new AndroidPhone();
            ICallable apple = new ApplePhone();
            ICallable pay = new PayPhone();

            phoneList.Add(and);
            phoneList.Add(apple);
            phoneList.Add(pay);

            foreach(ICallable phone in phoneList)
            {
                phone.Call();
            }

        }
    }
}
