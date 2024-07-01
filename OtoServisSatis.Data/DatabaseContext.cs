using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<BilgiAl> BilgiAls { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=OtoServisSatis;  integrated security=True; MultipleActiveResultSets=True; ");
            base.OnConfiguring(optionsBuilder);
        }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<Marka>().Property(x => x.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(x => x.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id =1,
                Adi ="Admin"
            });

            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id = 1,
                Ad ="Admin",
                AktifMi = true,
                EklenmeTarihi = DateTime.Now,
                Email ="CemErenOtoServis@hotmail.com",
                KullaniciAdi="admin",
                Sifre="123456",
                //Rol = new Rol { Id = 1,},
                RolId =1,
                Soyad="admin",
                Telefon ="08504543423"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
