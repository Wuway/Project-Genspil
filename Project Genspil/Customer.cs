namespace Project_Genspil
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Name}, {Address}, Tlf: {PhoneNumber}";
        }
    }
}