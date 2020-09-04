using ApiWeb.Infrastructure;
using ApiWeb.Model;
using ApiWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ProductosDbContext _bd;

        public UsuarioRepository(ProductosDbContext bdCatalogo)
        {
            _bd = bdCatalogo;
        }

        public bool ExisteUsuario(string UsuarioClientId)
        {
            return _bd.Usuarios.Any(x => x.ClientId == UsuarioClientId);
        }

        public Usuario GetUsuario(int IdUsuario)
        {
            var item = _bd.Usuarios.Where(x => x.IdUsuario == IdUsuario).FirstOrDefault();
            return item;
        }

        public ICollection<Usuario> GetUsuarios()
        {
            var lstUsuarios = _bd.Usuarios.ToList();
            return lstUsuarios;
        }

        public Usuario Login(string Usuario, string Password)
        {
            var usuarioCredencial = _bd.Usuarios.Where(x => x.ClientId == Usuario).FirstOrDefault();
            if (usuarioCredencial == null)
            {
                return null;
            }

            if (!Criptography.ValidacionPassword(Password, usuarioCredencial.HashPassword, usuarioCredencial.SaltPassword))
            {
                return null;
            }
            return usuarioCredencial;
        }

        public int Registrar(Usuario Usuario, string Password)
        {
            byte[] HashPassword, SaltPassword;

            Criptography.CrearPasswordEnCriptado(Password, out HashPassword, out SaltPassword);

            Usuario.HashPassword = HashPassword;
            Usuario.SaltPassword = SaltPassword;

            _bd.Usuarios.Add(Usuario);
            _bd.SaveChanges();

            return Usuario.IdUsuario;
        }
    }
}
