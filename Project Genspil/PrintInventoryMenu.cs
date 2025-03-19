

namespace Project_Genspil
{
    public class PrintInventoryMenu
    {
        private List<string> _gameLibrary; // Reference til den fælles spildatabase

        public PrintInventoryMenu(List<string> gameLibrary)
        {
            this._gameLibrary = gameLibrary;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("\u001b[33m--- Lagerliste over tilgængelige spil ---\u001b[0m\n");

            if (_gameLibrary.Count == 0)
            {
                Console.WriteLine("📭 Ingen spil er registreret i systemet endnu.");
            }
            else
            {
                foreach (var spil in _gameLibrary)
                {
                    Console.WriteLine($"📌 {spil}");
                }
            }

            Console.WriteLine("\nTryk på en tast for at vende tilbage til menuen...");
            Console.ReadKey();
        }
    }
}