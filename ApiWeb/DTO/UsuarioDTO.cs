using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string ClientId { get; set; }
        public byte[] HashPassword { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreo { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
