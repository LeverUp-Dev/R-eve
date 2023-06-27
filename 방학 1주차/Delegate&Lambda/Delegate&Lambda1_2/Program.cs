namespace Test
{
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
    internal class Program
    {

        private static void Main(string[] args)
        {
            //2.무명 델리게이트 방식
            List<Product> products = new List<Product>()
            {
                new Product() {Name = "감자", Price = 1000},
                new Product() {Name = "사과", Price = 1200},
                new Product() {Name = "고구마", Price = 700},
                new Product() {Name = "배추", Price = 900}
            };

            products.Sort(delegate(Product a, Product b) // 또는 3.람다식 방식: (a, b) =>
            {
                return a.Name.CompareTo(b.Name);
            });

            foreach (Product item in products)
            {
                Console.WriteLine(item.Name + ":" + item.Price + "원");
            }
        }
    }
}
