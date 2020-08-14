using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.DTO
{
    public class GrupoDTO
    {
        public int IdGrupo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreo { get; set; }
        public DateTime FechaModifico { get; set; }
        public ICollection<ProductoDTO> Productos { get; set; }
    }
}
