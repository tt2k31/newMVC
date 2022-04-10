using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace M01.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //thiết lập thêm khi tạo ra

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // foreach (var e in modelBuilder.Model.GetEntityTypes())
            // {
            //     var tableName = e.GetTableName();
            //     if (tableName.StartsWith("AspNet"))
            //     {
            //         e.SetTableName(tableName.Substring(6));
            //     }
            // }
        }
    }
}