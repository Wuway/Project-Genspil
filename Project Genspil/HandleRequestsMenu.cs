using System;
using System.Collections.Generic;

namespace Project_Genspil
{
    public class HandleRequestsMenu
    {
        private List<string> requests; // Liste over forespørgsler

        public HandleRequestsMenu(List<string> requests)
        {
            this.requests = requests;
        }

        public void Show()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("\u001b[33m--- Håndter Forespørgsler ---\u001b[0m\n");

                if (requests.Count == 0)
                {
                    Console.WriteLine("📭 Ingen kundeforespørgsler i systemet.");
                }
                else
                {
                    for (int i = 0; i < requests.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {requests[i]}");
                    }

                    Console.WriteLine("\nVælg en forespørgsel at håndtere (indtast nummer) eller tryk 0 for at gå tilbage:");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int index) && index > 0 && index <= requests.Count)
                    {
                        HandleRequest(index - 1);
                    }
                    else if (index == 0)
                    {
                        running = false;
                    }
                    else
                    {
                        Console.WriteLine("❌ Ugyldigt valg. Prøv igen.");
                        Console.ReadKey();
                    }
                }

                Console.WriteLine("\nTryk på en tast for at fortsætte...");
                Console.ReadKey();
            }
        }

        private void HandleRequest(int index)
        {
            Console.Clear();
            Console.WriteLine($"🔹 Håndterer forespørgsel: {requests[index]}\n");

            Console.WriteLine("1. Accepter forespørgsel");
            Console.WriteLine("2. Afvis forespørgsel");
            Console.WriteLine("3. Slet forespørgsel");
            Console.Write("\nVælg en handling: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine($"✅ Forespørgslen \"{requests[index]}\" er accepteret.");
                    requests.RemoveAt(index);
                    break;
                case "2":
                    Console.WriteLine($"❌ Forespørgslen \"{requests[index]}\" er afvist.");
                    requests.RemoveAt(index);
                    break;
                case "3":
                    Console.WriteLine($"🗑️ Forespørgslen \"{requests[index]}\" er slettet.");
                    requests.RemoveAt(index);
                    break;
                default:
                    Console.WriteLine("❌ Ugyldigt valg. Ingen ændringer foretaget.");
                    break;
            }
        }
    }
}
