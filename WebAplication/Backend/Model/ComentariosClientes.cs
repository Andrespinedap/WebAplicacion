namespace WebAplicacion.Model
{
    public class ComentariosClientes
    {
        /// <summary>
        /// Id de la entidad
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id de la orden
        /// </summary>
        public int Order_Id { get; set; }
        /// <summary>
        /// Id de la Cliente
        /// </summary>
        public int Client_Id { get; set; }
        /// <summary>
        /// Comentarios
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Calificación
        /// </summary>
        public string Qualification { get; set; }
        /// <summary>
        /// Propiedad de navegación con la entidad ordenes
        /// </summary>
        public Maintenance_History MaintenanceHistory { get; set; }
        /// <summary>
        /// Propiedad de navegación con la entidad Cliente
        /// </summary>
        public Client Client { get; set; }
    }
}
