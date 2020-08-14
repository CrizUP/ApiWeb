using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public string Codigo { get; set; }
        public int IdGrupo { get; set; }
        public GrupoDTO Grupo { get; set; }
        public int IdProveedor { get; set; }
        public ProveedorDTO Proveedor { get; set; }
        public string IdUnidadMedida { get; set; }
        public UnidadMedidaDTO UnidadMedida { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreo { get; set; }
        public DateTime FechaModifico { get; set; }
    }
}
