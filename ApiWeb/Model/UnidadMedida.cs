using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Model
{
    [Table(name: "UnidadMedida", Schema = "Cat")]
    public class UnidadMedida
    {
        [Key]
        [Required]
        public string IdUnidadMedida { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Required]
        public DateTime FechaModifico { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
