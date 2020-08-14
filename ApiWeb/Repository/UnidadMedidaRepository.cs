using ApiWeb.Infrastructure;
using ApiWeb.Model;
using ApiWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        private readonly ProductosDbContext _bd;

        public UnidadMedidaRepository(ProductosDbContext bd)
        {
            _bd = bd;
        }

        public int CreateProveedor(UnidadMedida DatosUnidadMedida)
        {
            throw new NotImplementedException();
        }

        public ICollection<int> CreateProveedores(ICollection<UnidadMedida> DatosUnidadMedidas)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUnidadMedida(int Id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteProveedor(string Nombre)
        {
            throw new NotImplementedException();
        }

        public UnidadMedida GetUnidadMedida(int Id)
        {
            throw new NotImplementedException();
        }

        public UnidadMedida UpdateUnidadMedida(UnidadMedida DatosUnidadMedida)
        {
            throw new NotImplementedException();
        }

        public ICollection<UnidadMedida> UpdateUnidadMedidas(ICollection<UnidadMedida> DatosUnidadMedidas)
        {
            throw new NotImplementedException();
        }
    }
}
