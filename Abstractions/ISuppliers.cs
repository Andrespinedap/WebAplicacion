using WebAplicacion.Model;

namespace WebAplicacion.Abstractions
{
    public interface ISuppliers
    {
        ICollection<Suppliers> GetSuppliers();
    }
}
