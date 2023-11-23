using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaPractica.Shared
{
    public class PersonDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre Obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email Obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Apellido Obligatorio")]
        public string LastName { get; set; }
        public string IdType { get; set; }

        public string IdentificationNumber { get; set; }

        public string? ConcatenateName { get; set; }

        public string? ConcatenateID { get; set; }

        public DateTime CreationDate { get; set; }

        public String concatenate(String one , string two)
        {
            return one+'-'+two;
        }
    }
}
