using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Model
{
    public class Cities
    {
        public int Id { get; set; }
        public int Client_Id { get; set; }
        public int Vehicle_Id { get; set; }
        public DateTime Date { get; set; }
        public string Motive { get; set; }
        public Client Client { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}