using CRUD_APP.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_APP.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Superhero> Superheroes { get; set; }
    }
}
