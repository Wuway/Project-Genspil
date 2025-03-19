using System;
using System.Collections.Generic;

namespace Project_Genspil
{
    public class SearchGameMenu
    {
        private List<string> gameLibrary; // Reference til den fælles spildatabase

        public SearchGameMenu(List<string> gameLibrary)
        {
            this.gameLibrary = gameLibrary;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("\u001b[33m--- Søg efter et spil ---\u001b[0m");
            Console.Write("\nIndtast navnet på spillet du vil søge efter: ");
            
            string searchQuery = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                Console.WriteLine("\nUgyldigt input. Prøv igen.");
            }
            else
            {
                List<string> searchResults = gameLibrary.FindAll(spil => spil.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0);

                if (searchResults.Count > 0)
                {
                    Console.WriteLine("\n🔍 Spil fundet:\n");
                    foreach (var spil in searchResults)
                    {
                        Console.WriteLine($"- {spil}");
                    }
                }
                else
                {
                    Console.WriteLine("\n❌ Ingen spil fundet med det søgekriterie.");
                }
            }

            Console.WriteLine("\nTryk på en tast for at vende tilbage til menuen...");
            Console.ReadKey();
        }
    }
}