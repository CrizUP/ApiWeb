using ApiWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository.IRepository
{
    public interface IUnidadMedidaRepository
    {
        string CreateUnidadMedida(UnidadMedida DatosUnidadMedida);
        ICollection<string> CreateUnidadesMedida(ICollection<UnidadMedida> DatosUnidadMedidas);
        bool ExisteUnidadMedida(string Nombre);
        UnidadMedida GetUnidadMedida(string Id);
        ICollection<UnidadMedida> GetUnidadMedidas();
        bool DeleteUnidadMedida(string Id);
        UnidadMedida UpdateUnidadMedida(UnidadMedida DatosUnidadMedida);
        ICollection<UnidadMedida> UpdateUnidadMedidas(ICollection<UnidadMedida> DatosUnidadMedidas);
    }
}
