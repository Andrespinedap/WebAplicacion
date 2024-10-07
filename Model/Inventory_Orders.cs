namespace WebAplicacion.Model
{
    public class Inventory_Orders
    {
        public int Id { get; set; }
        public int Order_Id { get; set;}
        public int Inventory_Id { get; set;}  
        public int Amount { get; set; }
        public Order Order { get; set; }
        public required Inventory Inventory { get; set; }
        //public List<Inventory> Inventory { get; set; } = [];
    }
}
