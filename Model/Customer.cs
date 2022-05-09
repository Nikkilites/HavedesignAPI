namespace Havedesign_Web_API.Model
{
    public class Customer
    {
        public Customer(int id, string? name, int? phone, string? address, string? email)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
            Email = email;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
