using ApiWeb.Infrastructure;
using ApiWeb.Model;
using ApiWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ProductosDbContext _bd;

        public ProveedorRepository(ProductosDbContext bd)
        {
            _bd = bd;
        }

        public int CreateProveedor(Proveedor DatosProveedor)
        {
            throw new NotImplementedException();
        }

        public ICollection<int> CreateProveedores(ICollection<Proveedor> DatosProveedores)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProveedor(int Id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteProveedor(string Nombre)
        {
            throw new NotImplementedException();
        }

        public Proveedor GetProveedor(int Id)
        {
            throw new NotImplementedException();
        }

        public Proveedor UpdateProveedor(Proveedor DatosProveedor)
        {
            throw new NotImplementedException();
        }

        public ICollection<Proveedor> UpdateProveedores(ICollection<Proveedor> DatosProveedores)
        {
            throw new NotImplementedException();
        }
    }
}
