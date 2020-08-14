using ApiWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository.IRepository
{
    public interface IUnidadMedidaRepository
    {
        int CreateProveedor(UnidadMedida DatosUnidadMedida);
        ICollection<int> CreateProveedores(ICollection<UnidadMedida> DatosUnidadMedidas);
        bool ExisteProveedor(string Nombre);
        UnidadMedida GetUnidadMedida(int Id);
        bool DeleteUnidadMedida(int Id);
        UnidadMedida UpdateUnidadMedida(UnidadMedida DatosUnidadMedida);
        ICollection<UnidadMedida> UpdateUnidadMedidas(ICollection<UnidadMedida> DatosUnidadMedidas);
    }
}
