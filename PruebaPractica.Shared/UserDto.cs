using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaPractica.Shared
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre Obligatorio")]
        public string UserName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
        public int Pass { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
