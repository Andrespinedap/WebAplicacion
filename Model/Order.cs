namespace WebAplicacion.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Vehicle_Id { get; set; }
        public string Employee_Id { get; set; }
        public DateTime DateCreated { get; set;}
        public bool State { get; set;}
        public ComentariosClientes  ComentarioCliente { get; set;}
        public Employee Employee { get; set;}
        public Payments Payments { get; set;}
        public Services_Orders ServicesOrders { get; set;}
        public Maintenance_History MaintenanceHistory { get; set;}
        public Vehicle Vehicle { get; set;}
        public Inventory_Orders InventoryOrders { get; set;}
    }
}
