namespace WebAplicacion.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public Inventory_purchase Inventory_Purchase { get; set; }
        public Inventory_Orders Inventory_Orders { get; set; }
        //public List<Inventory_Orders> InventoryOrders { get; set; } = [];
    }
}