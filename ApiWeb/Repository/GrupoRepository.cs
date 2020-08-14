using ApiWeb.Infrastructure;
using ApiWeb.Model;
using ApiWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository
{
    public class GrupoRepository : IGrupoRepository
    {
        private readonly ProductosDbContext _bd;

        public GrupoRepository(ProductosDbContext bd)
        {
            _bd = bd;
        }

        public int CreateGrupo(Grupo DatosGrupo)
        {
            throw new NotImplementedException();
        }

        public ICollection<int> CreateGrupos(ICollection<Grupo> DatosGrupos)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGrupo(int Id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteGrupo(string Nombre)
        {
            throw new NotImplementedException();
        }

        public Grupo GetGrupo(int Id)
        {
            throw new NotImplementedException();
        }

        public Grupo UpdateGrupo(Grupo DatosGrupo)
        {
            throw new NotImplementedException();
        }

        public ICollection<Grupo> UpdateGrupos(ICollection<Grupo> DatosGrupos)
        {
            throw new NotImplementedException();
        }
    }
}
