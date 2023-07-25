using UserManagementApi.Models.DBModels.DBTables;
using Microsoft.EntityFrameworkCore;

namespace UserManagementApi.Models.DBModels
{
    public class DBManagementContext : DbContext
    {
        public DBManagementContext(DbContextOptions<DBManagementContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            #region Has Data
            var adminUserType = new tbl_user_type()
            {
                type_id = Guid.NewGuid(),
                is_active = true,
                type_name = "Administrator",
            };
            modelBuilder.Entity<tbl_user_type>().HasData(adminUserType);
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
                fk_user_type= adminUserType.type_id
            };
            modelBuilder.Entity<tbl_user>().HasData(user);
            #endregion
            #region has RelationShip
            modelBuilder.Entity<tbl_user>()
               .HasOne(p => p.user_type)
               .WithMany(b => b.users)
               .HasForeignKey(p => p.fk_user_type);
            #endregion
        }
        public DbSet<tbl_user> tbl_users { get; set; }
        public DbSet<tbl_user_type> tbl_user_types { get; set; }
    }
}
