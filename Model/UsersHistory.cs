namespace WebAplicacion.Model
{
    public class UsersHistory
    {
        public int Id { get; set; }
        public required User User { get; set; }
        public required DateTime Datecreate { get; set; }
        public required string Modified { get; set; }
        public required string ModifiedBy { get; set; }
        public required DateTime Datemodified { get; set; }
    }
}
