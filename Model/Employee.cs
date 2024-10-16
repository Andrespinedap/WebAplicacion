namespace WebAplicacion.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public Order Order { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();

    }
}