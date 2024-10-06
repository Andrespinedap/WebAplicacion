namespace WebAplicacion.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Vehicle_Id { get; set; }
        public String Employee_Id { get; set; }
        public DateTime Date { get; set;}
        public string State { get; set;}
        public Payments Payments { get; set;}
        public Services_Orders Services_Orders{ get; set;}
        public Maintenance_History Maintenance_History { get; set;}
        public Vehicle Vehicle { get; set;}
        public Inventory_Orders Inventory_Orders { get; set;}
        public Employee Employee { get; set;}
    }
}
