namespace WebAplicacion.Model
{
    public class Comentari_Client
    {
        /// <summary>
        /// se crean los campos de cada tabla
        /// </summary>
        public int Id { get; set; }
        public int Client_Id { get; set; }
        public int Order_Id { get; set; }
        public string Comment { get; set; }
        public string Qualification { get; set; }
    }
}
