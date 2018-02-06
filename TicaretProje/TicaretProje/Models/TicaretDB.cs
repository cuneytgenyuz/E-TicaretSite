namespace TicaretProje.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TicaretDB : DbContext
    {
        public TicaretDB()
            : base("name=TicaretDB")
        {
        }

        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Resim> Resims { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Urun> Uruns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resim>()
                .HasMany(e => e.Uruns)
                .WithOptional(e => e.Resim)
                .HasForeignKey(e => e.resimID);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.Resims)
                .WithOptional(e => e.Urun)
                .HasForeignKey(e => e.urunID);
        }
    }
}
