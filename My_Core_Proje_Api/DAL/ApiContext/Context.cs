using Microsoft.EntityFrameworkCore;
using My_Core_Proje_Api.DAL.Entity;

namespace My_Core_Proje_Api.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-1IHFPICF;database=CoreProject;trusted_connection=true;multipleactiveresultsets=true;trustservercertificate=true");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
