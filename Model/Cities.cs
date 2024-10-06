using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Model
{
    public class Date
    {
        public int Id { get; set; }
        public required string Client_Id { get; set; }
        public string Vehicle_Id { get; set; }
        public DateTime Data_Time { get; set; }
        public string Motivated { get; set; }
    }
}
