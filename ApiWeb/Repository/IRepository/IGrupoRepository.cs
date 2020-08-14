using ApiWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository.IRepository
{
    public interface IGrupoRepository
    {
        int CreateGrupo(Grupo DatosGrupo);
        ICollection<int> CreateGrupos(ICollection<Grupo> DatosGrupos);
        bool ExisteGrupo(string Nombre);
        Grupo GetGrupo(int Id);
        bool DeleteGrupo(int Id);
        Grupo UpdateGrupo(Grupo DatosGrupo);
        ICollection<Grupo> UpdateGrupos(ICollection<Grupo> DatosGrupos);
    }
}
