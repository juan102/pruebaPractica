using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaPractica.Server.Models
{
    public class User
    {
        [Key]   
        public int Id {  get; set; }

        public string UserName { get; set; }
       
        public int Pass { get; set; } 

        public DateTime CreationDate { get; set; }   
        

    }
}
