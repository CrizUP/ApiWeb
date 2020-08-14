using ApiWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository.IRepository
{
    public interface IContactoRepository
    {
        int CreateContacto(Contacto DatosContacto);
        ICollection<int> CreateContactos(ICollection<Contacto> DatosContactos);
        bool ExisteContacto(string Nombre);
        Contacto GetContacto(int Id);
        bool DeleteContacto(int Id);
        Contacto UpdateContacto(Contacto DatosContacto);
        ICollection<Contacto> UpdateContactos(ICollection<Contacto> DatosContactos);
    }
}
