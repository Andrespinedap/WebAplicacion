namespace WebAplicacion.Model
{
    public class Maintenance_History
    {
        public int Id { get; set; }
        public int Vehicle_Id { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set;}
        public Order Order { get; set; }
        public ComentariosClientes ComentariosClientes { get; set; }
        public Vehicle Vehicle { get; set; }
        //public ICollection<ComentariosClientes> ComentariosXcliente { get; } = new List<ComentariosClientes>();
    }
}