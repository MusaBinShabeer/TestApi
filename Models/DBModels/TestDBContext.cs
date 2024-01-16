using Microsoft.EntityFrameworkCore;
using TestApi.Models.DBModels.DBTables;

namespace TestApi.Models.DBModels
{
    public class TestDBContext : DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<tbl_user> tbl_users { get; set; }
    }
}
