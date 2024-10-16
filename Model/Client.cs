namespace WebAplicacion.Model
{
    public class Client
    {
        public int Id { get; set; }

        /// <summary>
        /// Id del Cliente
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string? Direccion { get; set; }

        /// <summary>
        /// Direccion
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Telefono
        /// </summary>
        public int Telefono { get; set; }

        public ComentariosClientes? ComentariosCliente { get; set; }

        public Cities? Cities { get; set; }

        public ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();

        public ICollection<ComentariosClientes> ComentariosXcliente { get; } = new List<ComentariosClientes>();
    }
}