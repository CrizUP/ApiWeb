using ApiWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository.IRepository
{
    public interface IProveedorRepository
    {
        int CreateProveedor(Proveedor DatosProveedor);
        ICollection<int> CreateProveedores(ICollection<Proveedor> DatosProveedores);
        bool ExisteProveedor(string Nombre);
        Proveedor GetProveedor(int Id);
        bool DeleteProveedor(int Id);
        Proveedor UpdateProveedor(Proveedor DatosProveedor);
        ICollection<Proveedor> UpdateProveedores(ICollection<Proveedor> DatosProveedores);
    }
}
