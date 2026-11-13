using Microsoft.EntityFrameworkCore;
using My_Core_Proje_Api.DAL.Entity;

namespace My_Core_Proje_Api.DAL.ApiContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
