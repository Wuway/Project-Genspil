using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_Genspil
{
    class Game
    {
        private string titleGame;
        private string versionGame;
        private string genreGame;
        private int participantGame;
        private int agePlayerGame;
        private char conditionGame;
        private double priceGame;
        private int amountGame;

        public string Title
        {
            get { return titleGame; }
            set { titleGame = value; }
        }
        public string Version
        {
            get { return versionGame; }
            set { versionGame = value; }
        }
        public string Genre
        {
            get { return genreGame; }
            set { genreGame = value; }
        }
        public int ParticipantGame
        {
            get { return participantGame; }
            set { participantGame = value; }
        }
        public int AgePlayerGame
        {
            get { return agePlayerGame; }
            set { agePlayerGame = value; }
        }
        public char ConditionGame
        {
            get { return conditionGame; }
            set { conditionGame = value; }
        }
        public double PriceGame
        {
            get { return priceGame; }
            set { priceGame = value; }
        }
        public int AmountGame
        {
            get { return amountGame; }
            set { amountGame = value; }
        }

        private static List<Game> games = new List<Game>();
        public static void InitializedPredefinedGames()
        {
            //tilføjer foruddefinerede spil
            Console.Clear();
            games.Add(new Game { titleGame = "Trivial Pursuit", versionGame = "Disney", genreGame = "Børn", participantGame = 2, agePlayerGame = 8, conditionGame = 'C', priceGame = 109, amountGame = 2 });
            games.Add(new Game { titleGame = "Sequence", versionGame = "Jubilæum", genreGame = "Voksne", participantGame = 4, agePlayerGame = 18, conditionGame = 'A', priceGame = 199, amountGame = 1 });
            games.Add(new Game { titleGame = "Bad People", versionGame = "Original", genreGame = "Strategi", participantGame = 2, agePlayerGame = 8, conditionGame = 'B', priceGame = 149, amountGame = 0 });
            games.Add(new Game { titleGame = "Ticket To Ride", versionGame = "Junior", genreGame = "Børn", participantGame = 4, agePlayerGame = 6, conditionGame = 'B', priceGame = 109, amountGame = 1 });
        }
        public Game() { }
        public Game(string titleGame, string versionGame, string genreGame, int participantGame, int agePlayerGame, char conditionGame, double priceGame, int amountGame)
        {
            Title = titleGame;
            Version = versionGame;
            Genre = genreGame;
            ParticipantGame = participantGame;
            AgePlayerGame = agePlayerGame;
            ConditionGame = conditionGame;
            PriceGame = priceGame;
            AmountGame = amountGame;
        }
        public bool AddGame()
        {
            Console.Clear();
            Console.WriteLine("Du har valgt at oprette et spil i lageret. Tilføj følgende oplysninger:\n-----------------------------------------------------------------------");
            Console.WriteLine("Spillets navn: ");
            string titleGame = Console.ReadLine();
            Console.WriteLine("Udgave: ");
            string versionGame = Console.ReadLine();
            Console.WriteLine("Spillets genre: ");
            string genreGame = Console.ReadLine();
            Console.WriteLine("Max antal spillere: ");
            int participantGame = int.Parse(Console.ReadLine());
            Console.WriteLine("Spillets aldersgrænse (min. alder): ");
            int agePlayerGame = int.Parse(Console.ReadLine());
            Console.WriteLine("Spillets stand nyt (A), god men brugt (B), slidt (C) og reperation (D): ");
            char conditionGame = char.Parse(Console.ReadLine());
            char upperConditionGame = char.ToUpper(conditionGame);
            Console.WriteLine("Spillets pris: ");
            double priceGame = double.Parse(Console.ReadLine());
            Console.WriteLine("Tilføj antal: ");
            int amountGame = int.Parse(Console.ReadLine());
            Console.WriteLine("Vil du gemme ? (Ja / Nej)");
            string saveGame = Console.ReadLine();
            string upperSaveGame = saveGame.ToUpper();

            if (upperSaveGame == "JA")
            {
                Console.Clear();
                Game newGame = new Game(titleGame, versionGame, genreGame, participantGame, agePlayerGame, conditionGame, priceGame, amountGame);
                games.Add(newGame);
                Console.WriteLine($"Spil: {titleGame}\nUdgave: {versionGame}\nGenre: {genreGame}\nMax antal spillere: {participantGame}\nMin. aldersgrænse: {agePlayerGame}\nStand: {conditionGame}\nPris: {priceGame}\nAntal: {amountGame}\n");
                Console.WriteLine("Spillet er gemt. Indtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Spillet er ikke gemt. Indtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                Console.ReadLine();
            }
            return false; // Return false for at bryde loopet i Menuchoice.cs
        }
        public static List<Game> GetGames()
    {
        return games;
    }
        public static void DeleteGame()
        {
            Console.Clear();
            Console.WriteLine("Du har valgt, at du vil slette et spil. Vælg mellem følgende:\n\n");
            Console.WriteLine("Lagerliste sorteret efter titel:\n--------------------------------");
            var sortedGenre = games.OrderBy(g => g.genreGame).ToList();
            foreach (var g in sortedGenre)
            {
                Console.WriteLine($"Spil: {g.titleGame}\nUdgave: {g.versionGame}\nGenre: {g.genreGame}\nMax antal spillere: {g.participantGame}\nMin. aldersgrænse: {g.agePlayerGame}\nStand: {g.conditionGame}\nPris: {g.priceGame}\nAntal: {g.amountGame}");
                Console.WriteLine("-----------------------------------\n");
            }
            Console.WriteLine("Indtast spillets navn du ønsker slettet: ");
            string deleteGame = Console.ReadLine().ToUpper();
            var game = games.FirstOrDefault(g => g.titleGame.ToUpper() == deleteGame);
            if (game != null)
            {
                Console.WriteLine("Indtast det antal du ønsker slettet: ");
                int deleteAmount = int.Parse(Console.ReadLine());
                if (game.amountGame >= deleteAmount)
                {
                    game.amountGame -= deleteAmount;
                    if (game.amountGame == 0)
                    {
                        games.Remove(game);
                        Console.Clear();
                        Console.WriteLine("Spillet er slettet fra lagerlisten.\n\nIndtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Spillet er slettet. Antallet af spil '{deleteGame}' er reduceret med {deleteAmount}.\n\nOpdateret lagerstatus for det valgte spil er nu: {game.amountGame}.\n\nIndtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                        Console.ReadLine();
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Der er ikke nok spil på lager til at slette det ønskede antal.\n\nIndtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                    Console.ReadLine();
                    return;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Spillet findes ikke på lagerlisten. Indtast vilkårlig tast for at blive sendt til hovedmenuen.\n");
                Console.ReadLine();
                return;
            }
        }
    }
}
