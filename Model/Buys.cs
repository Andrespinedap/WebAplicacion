namespace WebAplicacion.Model
{
    //tabla compra
    public class Buys
    {
        public int Id { get; set; }
        public string supplier_Id { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
        public Inventory_purchase Inventory_Purchase { get; set; }
        public Suppliers Suppliers { get; set; }
    }
}
