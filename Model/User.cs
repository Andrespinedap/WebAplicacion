namespace WebAplicacion.Model
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public required DateTime Date { get; set; }
        public required string Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
