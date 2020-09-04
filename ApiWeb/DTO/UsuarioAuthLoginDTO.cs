using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.DTO
{
    public class UsuarioAuthLoginDTO
    {
        [Required]
        public string ClientId { get; set; }
        [Required]
        [StringLength(320, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
