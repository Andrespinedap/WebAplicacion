namespace WebAplicacion.Model
{
    public class Services_Orders
    {
        public int Id { get; set; } 
        public string Order_Id { get; set; }
        public string Services_Id { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
        //public Services Services { get; set; }
        public List<Services> Service { get; set; } = new List<Services>();
    }
}
