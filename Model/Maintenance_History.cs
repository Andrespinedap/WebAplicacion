namespace WebAplicacion.Model
{
    public class Maintenance_History
    {
        public int Id { get; set; }
        public string Vehicle_Id { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public Comentari_Client Comentari_Client { get; set;}
    public Order Order { get; set; }
        public Vehicle Vehicle { get; internal set; }
    }
}
