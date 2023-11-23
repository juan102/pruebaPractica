using Microsoft.EntityFrameworkCore;
using PruebaPractica.Server.Models;

namespace PruebaPractica.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Agregar los modelos
        public DbSet<User> Users { get; set; }

        public DbSet<Person> Person { get; set; }
    }
}
