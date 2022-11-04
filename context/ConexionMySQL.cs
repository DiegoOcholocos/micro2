using micro2.Models;
using Microsoft.EntityFrameworkCore;

namespace micro2.Context
{
    public class ConexionMySQL:DbContext
    {
        public ConexionMySQL(DbContextOptions<ConexionMySQL> options) : base(options)
        {
        }
        public DbSet<blacklist_on> blacklist_on { get; set; }
    }
}