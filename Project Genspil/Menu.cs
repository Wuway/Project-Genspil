using System;
using System.Collections.Generic;

namespace Project_Genspil
{
    internal class Menu
    {
        private List<string> menuOptions = new List<string>
        {
            "Opret Spil", "Søg Spil", "Udskriv Lagerliste", "Håndter Forespørgsler", "Administrer Kunder", "Afslut"
        };

        public void Show()
        {
            bool running = true; // Variabel til at holde menuen kørende i en løkke
            int option = 0; // Holder styr på hvilken menuoption der er valgt
            Console.CursorVisible = false;

            while (running) // Sørger for, at menuen genstarter efter en handling er udført
            {
                Console.Clear();
                Console.WriteLine("\u001b[33m--- System Genspil Menu ---\u001b[0m");

                // Udskriv menuen med farvet markør ved den valgte mulighed
                for (int i = 0; i < menuOptions.Count; i++)
                {
                    if (i == option)
                        Console.WriteLine($"\n✅ \u001b[32m{menuOptions[i]}\u001b[0m");
                    else
                        Console.WriteLine($"   {menuOptions[i]}");
                }

                var key = Console.ReadKey(true).Key; // Læs tastetryk uden at vise det i konsollen

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option + 1) % menuOptions.Count; // Gå ned i menuen (loop tilbage til toppen)
                        break;
                    case ConsoleKey.UpArrow:
                        option = (option - 1 + menuOptions.Count) % menuOptions.Count; // Gå op i menuen (loop til bunden)
                        break;
                    case ConsoleKey.Enter:
                        HandleSelection(option); // Kald den valgte funktion
                        break;
                    case ConsoleKey.Escape:
                        running = false; // Luk programmet, hvis brugeren trykker "Escape"
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
                    OpretSpil();
                    break;
                case 1:
                    SøgSpil();
                    break;
                case 2:
                    UdskrivLagerliste();
                    break;
                case 3:
                    HåndterForespørgsler();
                    break;
                case 4:
                    AdministrerKunder();
                    break;
                case 5:
                    Console.WriteLine("Afslutter program...");
                    Environment.Exit(0); // Afslutter programmet korrekt
                    break;
            }

            // **Tilføjet:** Gør det muligt at vende tilbage til menuen
            Console.WriteLine("\nTryk på en tast for at vende tilbage til menuen...");
            Console.ReadKey(); // Venter på input før menuen vises igen
        }

        private void OpretSpil()
        {
            var opretSpilMenu = new CreateGameMenu();
            opretSpilMenu.Show();
        }

        private void SøgSpil()
        {
            var searchMenu = new SearchGameMenu(new List<string> 
            {
                "Spil1",
                "Spil2",
                "Spil3",
                "Spil4"
            });

            searchMenu.Show();
        }


        private void UdskrivLagerliste()
        {
            var printInventoryMenu = new PrintInventoryMenu(new List<string> 
            {
                "Spil1",
                "Spil2",
                "Spil3",
                "Spil4"
            });

            printInventoryMenu.Show();
        }

        private void HåndterForespørgsler()
        {
            var requestMenu = new HandleRequestsMenu(new List<string> 
            {
                "Reservation af 'Catan' fra Mads Andersen",
                "Forespørgsel om pris på 'Carcassonne' fra Louise Jensen",
                "Købsanmodning på 'Ticket to Ride' fra Tariq Hassan"
            });

            requestMenu.Show();
        }


        private void AdministrerKunder()
        {
            var manageCustomersMenu = new ManageCustomersMenu(new List<string> 
            {
                "Mads Andersen",
                "Louise Jensen",
                "Tariq Hassan"
            });

            manageCustomersMenu.Show();
        }
    }
}
