namespace WebAplicacion.Model
{
    //tabla compra
    public class Buys
    {
        public int Id { get; set; }
        public int Supplier_Id { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public Inventory_purchase Inventory_Purchase { get; set; }
        public Suppliers Suppliers { get; set; }
        public ICollection<Inventory_purchase> InventoryXpurchase { get; } = new List<Inventory_purchase>();
    }
}
