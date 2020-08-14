using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.DTO
{
    public class ProveedorDTO
    {
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreo { get; set; }
        public DateTime FechaModifico { get; set; }
        public ICollection<ContactoDTO> Contactos { get; set; }
        public ICollection<ProductoDTO> Productos { get; set; }
    }
}
