using ApiWeb.Infrastructure;
using ApiWeb.Model;
using ApiWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductosDbContext _bdGrupo;

        public ProductoRepository(ProductosDbContext bdGrupo)
        {
            _bdGrupo = bdGrupo;
        }

        public int CreateProducto(Producto DatosProducto)
        {
            throw new NotImplementedException();
        }

        public ICollection<int> CreateProductos(ICollection<Producto> DatosGrupos)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProducto(int Id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteProducto(string Nombre)
        {
            throw new NotImplementedException();
        }

        public Producto GetProducto(int Id)
        {
            throw new NotImplementedException();
        }

        public Producto UpdateProducto(Producto DatosProducto)
        {
            throw new NotImplementedException();
        }

        public ICollection<Producto> UpdateProductos(ICollection<Producto> DatosProductos)
        {
            throw new NotImplementedException();
        }
    }
}
