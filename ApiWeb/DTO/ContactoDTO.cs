using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.DTO
{
    public class ContactoDTO
    {
        public int IdContacto { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int IdProveedor { get; set; }
        public ProveedorDTO Proveedor { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreo { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
