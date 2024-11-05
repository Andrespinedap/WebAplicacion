namespace WebAplicacion.Model
{
    public class Suppliers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contacts { get; set; }
        public string Address { get; set;}
        public Buys Buys { get; set; }
        public ICollection<Buys> Buy { get; } = new List<Buys>();
    }
}