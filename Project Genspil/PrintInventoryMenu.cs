

namespace Project_Genspil
{
    public class PrintInventoryMenu(List<string> gameLibrary)
    {
        // Reference til den fælles spildatabase

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("\u001b[33m--- Lagerliste over tilgængelige spil ---\u001b[0m\n");

            if (gameLibrary.Count == 0)
            {
                Console.WriteLine("📭 Ingen spil er registreret i systemet endnu.");
            }
            else
            {
                foreach (var spil in gameLibrary)
                {
                    Console.WriteLine($"📌 {spil}");
                }
            }

            Console.WriteLine("\nTryk på en tast for at vende tilbage til menuen...");
            Console.ReadKey();
        }
    }
}