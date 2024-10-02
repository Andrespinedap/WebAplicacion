namespace WebAplicacion.Model
{
    public class Inventory_Orders
    {
        public int Id { get; set; }
        public int Order_Id { get; set;}
        public int Inventory_Id { get; set;}  
        public int Amount { get; set; }
    }
}
