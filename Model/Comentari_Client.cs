namespace WebAplicacion.Model
{
    public class Comentari_Client
    {
        /// <summary>
        /// se cambio el nobre de la tabla Cliente a Comentario cliente
        /// </summary>
        public int Id { get; set; }
        public string Client_Id { get; set; }
        public string Order_Id { get; set; }
        public string Comment { get; set; }
        public string Qualification { get; set; }

        public Client Client { get; set; }
        public Maintenance_History Maintenance_History { get; set; }
    }
}
