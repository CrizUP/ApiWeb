using ApiWeb.Infrastructure;
using ApiWeb.Model;
using ApiWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly ProductosDbContext _db;

        public ContactoRepository(ProductosDbContext db)
        {
            _db = db;
        }

        public int CreateContacto(Contacto DatosContacto)
        {
            throw new NotImplementedException();
        }

        public ICollection<int> CreateContactos(ICollection<Contacto> DatosContactos)
        {
            throw new NotImplementedException();
        }

        public bool DeleteContacto(int Id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteContacto(string Nombre)
        {
            throw new NotImplementedException();
        }

        public Contacto GetContacto(int Id)
        {
            throw new NotImplementedException();
        }

        public Contacto UpdateContacto(Contacto DatosContacto)
        {
            throw new NotImplementedException();
        }

        public ICollection<Contacto> UpdateContactos(ICollection<Contacto> DatosContactos)
        {
            throw new NotImplementedException();
        }
    }
}
