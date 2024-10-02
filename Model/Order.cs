namespace WebAplicacion.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int Vehicle_Id { get; set; }
        public int Employee_Id { get; set; }
        public DateTime Date { get; set;}
        public string State { get; set;}

    }
}
