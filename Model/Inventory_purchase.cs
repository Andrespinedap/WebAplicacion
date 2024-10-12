namespace WebAplicacion.Model
{
    public class Inventory_purchase
    {
        public int Id { get; set; }
        public int Buys_Id { get; set; }
        public string Inventory { get; set; }
        public int Amount { get; set; }
        public int Unit_price { get; set; }
        public Inventory Inventories { get; set; }
        public Buys Buy { get; set; }
        //public ICollection<Buys> Buys { get; } = new List<Buys>();
    }
}
