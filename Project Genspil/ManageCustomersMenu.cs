
namespace Project_Genspil
{
    public class ManageCustomersMenu
    {
        private List<string> _customers; // Liste over registrerede kunder

        public ManageCustomersMenu(List<string> customers)
        {
            this._customers = customers;
        }

        public void Show()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("\u001b[33m--- Administrer Kunder ---\u001b[0m\n");

                Console.WriteLine("1. Tilføj ny kunde");
                Console.WriteLine("2. Se eksisterende kunder");
                Console.WriteLine("3. Rediger kunde");
                Console.WriteLine("4. Slet kunde");
                Console.WriteLine("5. Tilbage til hovedmenuen");
                Console.Write("\nVælg en handling: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TilføjNyKunde();
                        break;
                    case "2":
                        SeEksisterendeKunder();
                        break;
                    case "3":
                        RedigerKunde();
                        break;
                    case "4":
                        SletKunde();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("❌ Ugyldigt valg. Prøv igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void TilføjNyKunde()
        {
            Console.Clear();
            Console.Write("\nIndtast kundens navn: ");
            string? navn = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(navn))
            {
                _customers.Add(navn);
                Console.WriteLine($"✅ Kunden '{navn}' er tilføjet.");
            }
            else
            {
                Console.WriteLine("❌ Ugyldigt navn. Kunden blev ikke tilføjet.");
            }

            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }

        private void SeEksisterendeKunder()
        {
            Console.Clear();
            Console.WriteLine("\u001b[33m--- Eksisterende Kunder ---\u001b[0m\n");

            if (_customers.Count == 0)
            {
                Console.WriteLine("📭 Ingen kunder registreret.");
            }
            else
            {
                for (int i = 0; i < _customers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_customers[i]}");
                }
            }

            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }

        private void RedigerKunde()
        {
            if (_customers.Count == 0)
            {
                Console.WriteLine("Der er ingen kunder at redigere.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Vælg en kunde at redigere:");
            for (int i = 0; i < _customers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_customers[i]}");
            }

            Console.Write("\nIndtast nummeret på kunden: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _customers.Count)
            {
                Console.Write("Indtast det nye navn for kunden: ");
                string? nytNavn = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nytNavn))
                {
                    _customers[index - 1] = nytNavn;
                    Console.WriteLine("✅ Kunden er blevet opdateret.");
                }
                else
                {
                    Console.WriteLine("❌ Ugyldigt input. Kunden blev ikke ændret.");
                }
            }
            else
            {
                Console.WriteLine("❌ Ugyldigt valg.");
            }

            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }

        private void SletKunde()
        {
            if (_customers.Count == 0)
            {
                Console.WriteLine("Der er ingen kunder at slette.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Vælg en kunde at slette:");
            for (int i = 0; i < _customers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_customers[i]}");
            }

            Console.Write("\nIndtast nummeret på kunden du vil slette: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _customers.Count)
            {
                Console.WriteLine($"🗑️ Kunden '{_customers[index - 1]}' er blevet slettet.");
                _customers.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("❌ Ugyldigt valg.");
            }

            Console.WriteLine("\nTryk på en tast for at fortsætte...");
            Console.ReadKey();
        }
    }
}
