namespace WebAplicacion.Model
{
    public class Inventory_purchase
    {
        public int Id { get; set; }
        public string Buys_Id { get; set; }
        public int Amount { get; set; }
        public int unit_price { get; set; }
    public Buys Buys { get; set; }
public Inventory Inventory {  get; set; }
    }
}
