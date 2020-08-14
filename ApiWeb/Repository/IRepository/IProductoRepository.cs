using ApiWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository.IRepository
{
    public interface IProductoRepository
    {
        int CreateProducto(Producto DatosProducto);
        ICollection<int> CreateProductos(ICollection<Producto> DatosGrupos);
        bool ExisteProducto(string Nombre);
        Producto GetProducto(int Id);
        bool DeleteProducto(int Id);
        Producto UpdateProducto(Producto DatosProducto);
        ICollection<Producto> UpdateProductos(ICollection<Producto> DatosProductos);
    }
}
