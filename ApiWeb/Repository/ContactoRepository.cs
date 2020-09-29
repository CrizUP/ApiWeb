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
            _db.Contactos.Add(DatosContacto);
            int rowsAffected = _db.SaveChanges();
            return DatosContacto.IdContacto;
        }

        public ICollection<int> CreateContactos(ICollection<Contacto> DatosContactos)
        {
            _db.Contactos.AddRange(DatosContactos);

            _db.SaveChanges();
            return DatosContactos.Select(i => i.IdContacto).ToList();
        }

        public bool DeleteContacto(int Id)
        {
            var item = _db.Contactos.Where(x => x.IdContacto == Id).FirstOrDefault();
            _db.Contactos.Remove(item);
            int rowsChanged = _db.SaveChanges();
            return rowsChanged > 0 ? true : false;
        }

        public bool ExisteContacto(string Nombre)
        {
            return _db.Contactos.Any(x => x.Nombre == Nombre);
        }

        public Contacto GetContacto(int Id)
        {
            return _db.Contactos.Where(x => x.IdContacto == Id).FirstOrDefault();
        }

        public Contacto UpdateContacto(Contacto DatosContacto)
        {
            var item = _db.Contactos.Where(X => X.IdContacto == DatosContacto.IdContacto).FirstOrDefault();
            item.FechaModifico = DatosContacto.FechaModifico;
            item.Activo = DatosContacto.Activo;
            item.Nombre = DatosContacto.Nombre;
            item.Numero = DatosContacto.Numero;
            item.Telefono = DatosContacto.Telefono;
            _db.SaveChanges();
            return item;
        }

        public ICollection<Contacto> UpdateContactos(ICollection<Contacto> DatosContactos)
        {
            var listItems = _db.Contactos.Where(x => DatosContactos.Select(i => i.IdContacto).ToList().Contains(x.IdContacto)).ToList();
            listItems.ForEach(e =>
            {
                e.FechaModifico = DatosContactos.Where(x => x.IdContacto == e.IdContacto).FirstOrDefault().FechaModifico;
                e.Activo = DatosContactos.Where(x => x.IdContacto == e.IdContacto).FirstOrDefault().Activo;
                e.Nombre = DatosContactos.Where(x => x.IdContacto == e.IdContacto).FirstOrDefault().Nombre;
                e.Numero = DatosContactos.Where(x => x.IdContacto == e.IdContacto).FirstOrDefault().Numero;
                e.Telefono = DatosContactos.Where(x => x.IdContacto == e.IdContacto).FirstOrDefault().Telefono;
            });
            _db.SaveChanges();
            return DatosContactos;
        }
    }
}
