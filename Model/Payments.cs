namespace WebAplicacion.Model
{
    public class Payments
    {
        public int Id { get; set; }
        public string Order_Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Payment_Method { get; set; }
          public Order Order { get; set; }
    }
}
