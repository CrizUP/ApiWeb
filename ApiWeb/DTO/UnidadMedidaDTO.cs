using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.DTO
{
    public class UnidadMedidaDTO
    {
        public string IdUnidadMedida { get; set; }
        public int Descripcion { get; set; }
        public DateTime FechaModifico { get; set; }
        public ICollection<ProductoDTO> Productos { get; set; }
    }
}
