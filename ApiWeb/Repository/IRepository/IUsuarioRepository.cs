using ApiWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int IdUsuario);
        bool ExisteUsuario(string UsuarioClientId);
        Usuario Login(string Usuario, string Password);
        int Registrar(Usuario Usuario, string Password);
    }
}
