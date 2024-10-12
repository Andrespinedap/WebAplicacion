namespace WebAplicacion.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int Vehicle_Id { get; set; }
        public int Employee_Id { get; set; }
        public DateTime Date { get; set;}
        public string State { get; set;}
        public Payments Payments { get; set;}
        public Maintenance_History Maintenance_History { get; set;}
        public Vehicle Vehicle { get; set;}
        public Inventory_Orders Inventory_Orders { get; set;}
        public Employee Employee { get; set;}
        public Services Services { get; set; }
        
    }
}
