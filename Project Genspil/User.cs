namespace Project_Genspil
{
    internal class User(string name)
    {
        private string Name { get; set; } = name;

        public override string ToString()
        {
            return $"Bruger: {Name}";
        }
    }
}