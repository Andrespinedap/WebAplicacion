namespace WebAplicacion.Model
{
    public class Inventory_Orders
    {
        public int Id { get; set; }
        public string Order_Id { get; set;}
        public string Inventory_Id { get; set;}  
        public int Amount { get; set; }
        public Order Order { get; set; }
    }
}
