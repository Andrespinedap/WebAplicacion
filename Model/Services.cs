using System.Diagnostics.Contracts;

namespace WebAplicacion.Model
{
    public class Services
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Services_Orders ServiceOrders { get; set; }
        //public List<Services_Orders> ServiceOrder { get; set; } = new List<Services_Orders>();
    }
}
