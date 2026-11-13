using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<WriterUser,WriterRole,int>
    {
        // Program.cs içinde appsettings.json'daki "ConnectionStrings:DefaultConnection" ile atanır.
        // Projede "new Context()" ile oluşturulan yerler de bu değeri kullanır.
        public static string? ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (string.IsNullOrEmpty(ConnectionString))
                {
                    ConnectionString = ReadConnectionStringFromAppSettings();
                }
                if (string.IsNullOrEmpty(ConnectionString))
                {
                    throw new InvalidOperationException("Bağlantı dizesi bulunamadı. appsettings.json içinde ConnectionStrings:DefaultConnection değerini girin.");
                }
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        // Program.cs çalışmadan oluşturulduğunda (ör. "dotnet ef" DataAccessLayer üzerinden çalıştırılırsa)
        // web projesinin appsettings.json dosyasından okunur.
        private static string? ReadConnectionStringFromAppSettings()
        {
            string[] candidates =
            {
                Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"),
                Path.Combine(Directory.GetCurrentDirectory(), "..", "Core_Proje", "appsettings.json")
            };
            foreach (var path in candidates)
            {
                if (!File.Exists(path)) continue;
                using var doc = JsonDocument.Parse(File.ReadAllText(path), new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip });
                if (doc.RootElement.TryGetProperty("ConnectionStrings", out var cs) &&
                    cs.TryGetProperty("DefaultConnection", out var value))
                {
                    return value.GetString();
                }
            }
            return null;
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TestimOnial> TestimOnials { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
      
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Annoucement> Annoucements  { get; set; }
        public DbSet<WriterMessage> WriterMessages { get; set; }

    }
}
