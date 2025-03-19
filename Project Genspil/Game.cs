namespace Project_Genspil
{
    internal class Game(string title, string edition, string genre, string condition, double price)
    {
        private string Title { get; set; } = title;
        private string Edition { get; set; } = edition;
        private string Genre { get; set; } = genre;
        private string Condition { get; set; } = condition;

        private double Price { get; set; } = price;
        /*public int Players { private get; set; }
        public int MinAge { private get; set; }*/

        /*int players, int minAge*/
        /*Players = players;
            MinAge = minAge;*/

        public override string ToString()
        {
            return $"{Title} ({Edition}) - {Genre} | {Condition} | {Price} kr.";
        }
    }
}