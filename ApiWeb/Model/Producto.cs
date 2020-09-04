using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Model
{
    [Table(name:"Producto", Schema = "Cat")]
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Costo { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }
        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }
        [Required]
        [ForeignKey("Grupo")]
        public int IdGrupo { get; set; }
        public Grupo Grupo { get; set; }
        [Required]
        [ForeignKey("Proveedor")]
        public int IdProveedor { get; set; }
        public Proveedor Proveedor { get; set; }
        [Required]
        [ForeignKey("UnidadMedida")]
        public string IdUnidadMedida { get; set; }
        public UnidadMedida UnidadMedida { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime FechaCreo { get; set; }
        public DateTime? FechaModifico { get; set; }
    }
}
