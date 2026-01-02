using BakerApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakerApi.Context
{
    public class BakerContext : DbContext
    {
        //veri tabanı bağlantı adresini tutacak
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NFEPLMA\\SQLEXPRESS;Database=BakerDb; trust server certificate=true;integrated Security = true");

        }

        //coğul olan veri tabanı tablolarını temsil edecek, 
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Feature> Features { get; set; }
    }
}
