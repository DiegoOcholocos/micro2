using micro2.Models;
using Microsoft.EntityFrameworkCore;

namespace micro2.Context
{
    public class ConexionSQLServer:DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options) : base(options)
        {
        }
        public DbSet<blacklist_on> blacklist_on { get; set; }
    }
}
