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
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutDetail> AboutDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AdressInfo> AdressInfos { get; set; }

        public DbSet<Subscribe> Subscribes { get; set; }
    }
}
