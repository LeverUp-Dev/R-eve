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
            //1.메서드의 매개변수로 메서드를 전달하는 방법
            List<Product> products = new List<Product>()
            {
                new Product() {Name = "감자", Price = 1000},
                new Product() {Name = "사과", Price = 1200},
                new Product() {Name = "고구마", Price = 700},
                new Product() {Name = "배추", Price = 900}
            };

            products.Sort(SortWithPrice);

            foreach (Product item in products)
            {
                Console.WriteLine(item.Name + ":" + item.Price + "원");
            }
        }

        private static int SortWithPrice(Product x, Product y)
        {
            return x.Price .CompareTo(y.Price);
        }
    }
}
