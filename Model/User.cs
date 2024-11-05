using System.ComponentModel.DataAnnotations;

namespace WebAplicacion.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required int PhoneNumber { get; set; }
        public required DateTime Date { get; set; }
        public required bool IsDeleted { get; set; }
        public required string Modified { get; set; }
        public required string ModifiedBy { get; set; }
        public virtual required Usertype Usertype { get; set; }


    }
}
