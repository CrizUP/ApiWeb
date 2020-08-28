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

        public string CreateUnidadMedida(UnidadMedida DatosUnidadMedida)
        {
            _bd.UnidadMedidas.Add(DatosUnidadMedida);
            int rowsAffected = _bd.SaveChanges();
            return DatosUnidadMedida.IdUnidadMedida;
        }

        public ICollection<string> CreateUnidadesMedida(ICollection<UnidadMedida> DatosUnidadMedidas)
        {
            _bd.UnidadMedidas.AddRange(DatosUnidadMedidas);

            _bd.SaveChanges();
            return DatosUnidadMedidas.Select(i => i.IdUnidadMedida).ToList();
        }

        public bool DeleteUnidadMedida(string Id)
        {
            var item= _bd.UnidadMedidas.Where(x => x.IdUnidadMedida == Id).FirstOrDefault();
            _bd.UnidadMedidas.Remove(item);
            int rowsChanged = _bd.SaveChanges();
            return rowsChanged > 0 ? true : false;
        }

        public bool ExisteUnidadMedida(string Nombre)
        {
            return _bd.UnidadMedidas.Any(x => x.Descripcion == Nombre);
        }

        public UnidadMedida GetUnidadMedida(string Id)
        {
            return _bd.UnidadMedidas.Where(x => x.IdUnidadMedida == Id).FirstOrDefault();
        }

        public ICollection<UnidadMedida> GetUnidadMedidas()
        {
            var item = _bd.UnidadMedidas.ToList();
            return item;
        }

        public UnidadMedida UpdateUnidadMedida(UnidadMedida DatosUnidadMedida)
        {
            var item = _bd.UnidadMedidas.Where(x => x.IdUnidadMedida == DatosUnidadMedida.IdUnidadMedida).FirstOrDefault();
            item.Descripcion = DatosUnidadMedida.Descripcion;
            item.FechaModifico = DatosUnidadMedida.FechaModifico;
            _bd.SaveChanges();
            return item;
        }

        public ICollection<UnidadMedida> UpdateUnidadMedidas(ICollection<UnidadMedida> DatosUnidadMedidas)
        {
            var LstItem = _bd.UnidadMedidas.Where(x => DatosUnidadMedidas.Select(i => i.IdUnidadMedida).ToList().Contains(x.IdUnidadMedida)).ToList();

            LstItem.ForEach(u =>
            {
                u.Descripcion = DatosUnidadMedidas.Where(i => i.IdUnidadMedida == u.IdUnidadMedida).Select(n => n.Descripcion).FirstOrDefault();
                u.FechaModifico = DatosUnidadMedidas.Where(i => i.IdUnidadMedida == u.IdUnidadMedida).Select(n => n.FechaModifico).FirstOrDefault();
            });
            _bd.SaveChanges();

            return DatosUnidadMedidas;
        }
    }
}
