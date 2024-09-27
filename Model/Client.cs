namespace WebAplicacion.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; } 

        public ComentariosClientes ComentariosCliente { get; set; }
        public Dates Cities { get; set; }
    }
}
