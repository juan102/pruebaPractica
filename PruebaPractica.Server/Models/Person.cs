using System.ComponentModel.DataAnnotations;

namespace PruebaPractica.Server.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string lastName { get; set; }
        public DateTime CreationDate { get; set; }

        public string IdType { get; set; }

        public string IdentificationNumber { get; set; }


        public string? ConcatenateName { get; set; } = null;

        public string? ConcatenateID { get; set; } = null;
    }
}
