namespace Project_Genspil
{
    internal class Game
    {
        public string Title { get; set; }
        public string Edition { get; set; }
        public string Genre { get; set; }
        public string Condition { get; set; }
        public double Price { get; set; }
        public int Players { get; set; }
        public int MinAge { get; set; }

        public Game(string title, string edition, string genre, string condition, double price, int players, int minAge)
        {
            Title = title;
            Edition = edition;
            Genre = genre;
            Condition = condition;
            Price = price;
            Players = players;
            MinAge = minAge;
        }

        public override string ToString()
        {
            return $"{Title} ({Edition}) - {Genre} | {Condition} | {Price} kr.";
        }
    }
}