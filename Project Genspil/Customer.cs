namespace Project_Genspil
{
    internal class Customer(string name, string address, string phoneNumber)
    {
        private string Name { get; set; } = name;
        private string Address { get; set; } = address;
        private string PhoneNumber { get; set; } = phoneNumber;

        public override string ToString()
        {
            return $"{Name}, {Address}, Tlf: {PhoneNumber}";
        }
    }
}