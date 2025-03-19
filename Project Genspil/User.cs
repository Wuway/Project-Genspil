namespace Project_Genspil
{
    internal class User
    {
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Bruger: {Name}";
        }
    }
}