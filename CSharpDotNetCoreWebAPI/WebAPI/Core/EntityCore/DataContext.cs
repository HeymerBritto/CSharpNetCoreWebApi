using Microsoft.EntityFrameworkCore;
using Models.Authentication;
using System.Collections.Generic;

namespace WebAPI.Core.EntityCore
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
