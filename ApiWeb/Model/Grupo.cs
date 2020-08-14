using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Model
{
    [Table(name: "Grupo", Schema = "Cat")]
    public class Grupo
    {
        [Key]
        public int IdGrupo { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(300)]
        public string Descripcion { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime FechaCreo { get; set; }
        [Required]
        public DateTime FechaModifico { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
