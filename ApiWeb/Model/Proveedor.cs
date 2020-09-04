using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Model
{
    [Table(name: "Proveedor", Schema = "Cat")]
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(320)]
        public string Correo { get; set; }
        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(50)]
        public string Pais { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime FechaCreo { get; set; }
        public DateTime? FechaModifico { get; set; }
        public ICollection<Contacto> Contactos { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
