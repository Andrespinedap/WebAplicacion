using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Model
{
    public class Cities
    {
        [Key]
        public int Id { get; set; }
        public required int Client_Id { get; set; }
        public int Vehicle_Id { get; set; }
        public string Data_Time { get; set; }
        public string Motivated { get; set; }
    }
}
