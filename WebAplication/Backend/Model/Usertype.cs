namespace WebAplicacion.Model
{
    public class Usertype
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required bool IsDeleted { get; set; }
        public const string Cliente = "Cliente";
        public const string Admin = "Admin";

    }
}
