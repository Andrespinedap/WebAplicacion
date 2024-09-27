namespace WebAplicacion.Model
{
    public class Maintenance_History
    {
        public int Id { get; set; }
        public string Vehicle_Id { get; set; }
        public DateTime Date { get; set; }
        public String Details { get; set;}
        public Order Order { get; set; }
        public ComentariosClientes ComentariosClientes { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
