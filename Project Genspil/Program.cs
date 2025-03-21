using System.Net.Http.Headers;

namespace Project_Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*string retry = "No";
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Print list");
            Console.WriteLine("2. Search Games");
            Console.WriteLine("3. Choose whatever\n");*/
            //Game Matador = new Game("Matador", "Eventyr", 4, 8, 49.99, 'B', true, 2);

            List<Game> games = new List<Game>(); // == var game = new List<Game>();
            games.Add(new Game("Matador", "Eventyr", 4, 8, 49.99, 'B', true, 2));
            games.Add(new Game("Matador", "Eventyr", 4, 8, 49.99, 'B', true, 2));
            for (int i = 0; i < )
            {

            }

            /*Console.WriteLine(Matador.Name);
            Matador.getData();
            Matador.setName("monopoli");
            Matador.getData();*/


                /*
                //do
                while (retry != "No") ;
                {
                    Console.Write("Your number: ");
                    int menu = int.Parse(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Console.WriteLine("You chose: Print List");
                            break;
                        case 2:
                            Console.WriteLine("You chose: Search Games");
                            break;
                        case 3:
                            Console.WriteLine("You chose: Choose whatever");
                            break;
                        default:
                            Console.WriteLine("Du har tastet forkert.");
                            Console.WriteLine("Vil du prøve igen?");
                            retry = Console.ReadLine();
                            break;
                    }
                }
                //while (retry != "No");
                */
            Console.ReadKey();
        }
    }
}
