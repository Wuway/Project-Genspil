using System;
using System.Collections.Generic;

namespace Project_Genspil
{
    public class CreateGameMenu
    {
        private List<string> menuOptions = new List<string>
        {
            "Tilbage", "Tilføj nyt spil", "Se eksisterende spil", "Rediger spil", "Slet spil", "Afslut"
        };

        private List<string> gameLibrary = new List<string>(); // Liste over spil

        public void Show()
        {
            bool running = true;
            int option = 0;
            Console.CursorVisible = false;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("\u001b[33m--- Opret Spil Menu ---\u001b[0m");

                for (int i = 0; i < menuOptions.Count; i++)
                {
                    if (i == option)
                        Console.WriteLine($"\n✅ \u001b[32m{menuOptions[i]}\u001b[0m");
                    else
                        Console.WriteLine($"   {menuOptions[i]}");
                }

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option + 1) % menuOptions.Count;
                        break;
                    case ConsoleKey.UpArrow:
                        option = (option - 1 + menuOptions.Count) % menuOptions.Count;
                        break;
                    case ConsoleKey.Enter:
                        HandleSelection(option);
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }
        }

        private void HandleSelection(int option)
        {
            Console.Clear();
            Console.WriteLine($"Du valgte: {menuOptions[option]}\n");

            switch (option)
            {
                case 0:
                    Back();
                    break;
                case 1:
                    TilføjNytSpil();
                    break;
                case 2:
                    SeEksisterendeSpil();
                    break;
                case 3:
                    RedigerSpil();
                    break;
                case 4:
                    SletSpil();
                    break;
                case 5:
                    Console.WriteLine("Afslutter program...");
                    Environment.Exit(0);
                    break;
            }

            Console.WriteLine("\nTryk på en tast for at vende tilbage til menuen...");
            Console.ReadKey();
        }

        private void Back()
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void TilføjNytSpil()
        {
            Console.Write("Indtast navnet på det nye spil: ");
            string nytSpil = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nytSpil))
            {
                gameLibrary.Add(nytSpil);
                Console.WriteLine($"Spillet '{nytSpil}' er blevet tilføjet!");
            }
            else
            {
                Console.WriteLine("Ugyldigt input. Spillet blev ikke tilføjet.");
            }
        }

        private void SeEksisterendeSpil()
        {
            Console.WriteLine("Eksisterende spil i systemet:");

            if (gameLibrary.Count == 0)
            {
                Console.WriteLine("Ingen spil er registreret endnu.");
            }
            else
            {
                foreach (var spil in gameLibrary)
                {
                    Console.WriteLine($"- {spil}");
                }
            }
        }

        private void RedigerSpil()
        {
            if (gameLibrary.Count == 0)
            {
                Console.WriteLine("Der er ingen spil at redigere.");
                return;
            }

            Console.WriteLine("Vælg et spil at redigere:");
            for (int i = 0; i < gameLibrary.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {gameLibrary[i]}");
            }

            Console.Write("Indtast nummeret på spillet du vil redigere: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= gameLibrary.Count)
            {
                Console.Write("Indtast det nye navn for spillet: ");
                string nytNavn = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nytNavn))
                {
                    gameLibrary[index - 1] = nytNavn;
                    Console.WriteLine("Spillet er blevet opdateret.");
                }
                else
                {
                    Console.WriteLine("Ugyldigt input. Spillet blev ikke ændret.");
                }
            }
            else
            {
                Console.WriteLine("Ugyldigt valg.");
            }
        }

        private void SletSpil()
        {
            if (gameLibrary.Count == 0)
            {
                Console.WriteLine("Der er ingen spil at slette.");
                return;
            }

            Console.WriteLine("Vælg et spil at slette:");
            for (int i = 0; i < gameLibrary.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {gameLibrary[i]}");
            }

            Console.Write("Indtast nummeret på spillet du vil slette: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= gameLibrary.Count)
            {
                Console.WriteLine($"Spillet '{gameLibrary[index - 1]}' er blevet slettet.");
                gameLibrary.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Ugyldigt valg.");
            }
        }
    }
}
