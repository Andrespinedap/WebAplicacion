namespace WebAplicacion.Model
{
    //tabla compra
    public class Buys
    {
        public int Id { get; set; }
        public int supplier_Id { get; set; }
        public DateTime Date { get; set; }
        public int Total { get; set; }
    }
}
