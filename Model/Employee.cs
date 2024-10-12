namespace WebAplicacion.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string Position { get; set; }
        public int Phone { get; set; }
        public string email { get; set; }
        public Order Order { get; set; }

       
    }
}
