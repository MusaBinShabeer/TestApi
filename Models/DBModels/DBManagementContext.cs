using MeteringManagementApi.Models.DBModels.DBTables;
using Microsoft.EntityFrameworkCore;

namespace MeteringManagementApi.Models.DBModels
{
    public class DBManagementContext : DbContext
    {
        public DBManagementContext(DbContextOptions<DBManagementContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            #region Has Data
            var user = new tbl_user
            {
                password="Enexol@123",
                token="",
                user_email_address="admin@metering.com",
                user_first_name="Administrator",
                user_last_name="Metering",
                user_name="Admin",
                user_phone_no="",
                is_active=true,
            };
            modelBuilder.Entity<tbl_user>().HasData(user);
            #endregion
        }
        public DbSet<tbl_user> tbl_users { get; set; }
    }
}
