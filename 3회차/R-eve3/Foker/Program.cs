using Foker;

internal class Program
{
    private static void Main(string[] args)
    {
        Cards cards = new Cards();
        //cards.Shuffle();
        cards.ShowCards();

        //ConsoleKeyInfo cki;
        //do
        //{
        //    cards.Distribute(5);
        //    cki = Console.ReadKey();

        //    cards.Shuffle();
        //    Console.Clear();
        //}
        //while (cki.Key != ConsoleKey.Escape);
    }
}