namespace WebAplicacion.Model
{
    public class UsersHistory
    {
        public int Id { get; set; }
        public string User { get; set; }
        public required DateTime Datecreate { get; set; }
        public required DateTime Datemodified { get; set; }
    }
}