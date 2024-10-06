using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Model
{
    public class Cities
    {
        [Key]
        public int Id { get; set; }
        public required string Client_Id { get; set; }
        public string Vehicle_Id { get; set; }
        public string Data_Time { get; set; }
        public string Motivated { get; set; }
        public Client Client { get; set; }  
        public Vehicle Vehicle { get; set; }
    }
}
