namespace WebAplicacion.Model
{
    public class Services_Orders
    {
        public int Id { get; set; } 
        public int Oreder_Id { get; set; }
        public int Services_Id { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }



    }
}
