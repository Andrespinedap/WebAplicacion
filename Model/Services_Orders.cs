namespace WebAplicacion.Model
{
    public class Services_Orders
    {
        public int Id { get; set; } 
        public string Oreder_Id { get; set; }
        public string Services_Id { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }

    }
}
