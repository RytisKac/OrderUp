using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderUp.Models
{
    public partial class restaurant_dbContext : IdentityDbContext<Klientas>
    {
        public restaurant_dbContext()
        {
        }

        public restaurant_dbContext(DbContextOptions<restaurant_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredientai> Ingredientai { get; set; }
        public virtual DbSet<IngredientoTipas> IngredientoTipas { get; set; }
        public virtual DbSet<Klientas> Klientas { get; set; }
        public virtual DbSet<Padas> Padas { get; set; }
        public virtual DbSet<Pica> Pica { get; set; }
        public virtual DbSet<PicosIngredientai> PicosIngredientai { get; set; }
        public virtual DbSet<PicosTipas> PicosTipas { get; set; }
        public virtual DbSet<PristatymoBudas> PristatymoBudas { get; set; }
        public virtual DbSet<Uzsakymas> Uzsakymas { get; set; }
        public virtual DbSet<UzsakymoPreke> UzsakymoPreke { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Nauja> Nauja { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost; port=3306; user=root; password= ; database=OrderUp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ingredientai>(entity =>
            {
                entity.ToTable("ingredientai");

                entity.HasIndex(e => e.Tipas)
                    .HasName("tipas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kaina)
                    .HasColumnName("kaina")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Matas)
                    .HasColumnName("matas")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tipas)
                    .HasColumnName("tipas")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.TipasNavigation)
                    .WithMany(p => p.Ingredientai)
                    .HasForeignKey(d => d.Tipas)
                    .HasConstraintName("ingredientai_ibfk_1");
            });

            modelBuilder.Entity<IngredientoTipas>(entity =>
            {
                entity.ToTable("ingrediento_tipas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(8)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Klientas>(entity =>
            {
                entity.ToTable("klientas");

                entity.Property(e => e.Adresas)
                    .HasColumnName("adresas")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

            });

            modelBuilder.Entity<Padas>(entity =>
            {
                entity.ToTable("padas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pica>(entity =>
            {
                entity.ToTable("pica");

                entity.HasIndex(e => e.Padas)
                    .HasName("padas");

                entity.HasIndex(e => e.Tipas)
                    .HasName("tipas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aprasymas)
                    .HasColumnName("aprasymas")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Kaina)
                    .HasColumnName("kaina")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Padas)
                    .HasColumnName("padas")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");
                entity.Property(e => e.Klientas)
                    .HasColumnName("Fk_klientas")
                    .HasColumnType("varchar(767)")
                    .HasDefaultValue("NULL");

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Tipas)
                    .HasColumnName("tipas")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.PadasNavigation)
                    .WithMany(p => p.Pica)
                    .HasForeignKey(d => d.Padas)
                    .HasConstraintName("pica_ibfk_1");

                entity.HasOne(d => d.TipasNavigation)
                    .WithMany(p => p.Pica)
                    .HasForeignKey(d => d.Tipas)
                    .HasConstraintName("pica_ibfk_2");

                entity.HasOne(d => d.KlientasNavigation)
                    .WithMany(p => p.Pica)
                    .HasForeignKey(d => d.Klientas)
                    .HasConstraintName("picos_klientas");
            });


            modelBuilder.Entity<PicosIngredientai>(entity =>
            {
                entity.ToTable("picos_ingredientai");

                entity.HasIndex(e => e.FkIngredientaiid)
                    .HasName("fk_Ingredientaiid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkIngredientaiid)
                    .HasColumnName("fk_Ingredientaiid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kiekis)
                    .HasColumnName("kiekis")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkIngredientai)
                    .WithMany(p => p.PicosIngredientai)
                    .HasForeignKey(d => d.FkIngredientaiid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("picos_ingredientai_ibfk_1");
            });

            modelBuilder.Entity<PicosTipas>(entity =>
            {
                entity.ToTable("picos_tipas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<PristatymoBudas>(entity =>
            {
                entity.ToTable("pristatymo_budas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Uzsakymas>(entity =>
            {
                entity.ToTable("uzsakymas");

                entity.HasIndex(e => e.FkKlientasid)
                    .HasName("fk_Klientasid");

                entity.HasIndex(e => e.PristatymoBudas)
                    .HasName("pristatymo_budas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VardasPavarde)
                    .HasColumnName("vardas_pavarde")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FkKlientasid)
                    .HasColumnName("fk_Klientasid")
                    .HasColumnType("varchar(767)");

                entity.Property(e => e.Kaina)
                    .HasColumnName("kaina")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PrekiuKiekis)
                    .HasColumnName("prekiu_kiekis")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.PristatymoBudas)
                    .HasColumnName("pristatymo_budas")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UzsakymoData)
                    .HasColumnName("uzsakymo_data")
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Adresas)
                    .HasColumnName("adresas")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Telefonas)
                   .HasColumnName("telefonas")
                   .HasColumnType("int(9)");

                entity.HasOne(d => d.FkKlientas)
                    .WithMany(p => p.Uzsakymas)
                    .HasForeignKey(d => d.FkKlientasid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uzsakymas_ibfk_2");

                entity.HasOne(d => d.PristatymoBudasNavigation)
                    .WithMany(p => p.Uzsakymas)
                    .HasForeignKey(d => d.PristatymoBudas)
                    .HasConstraintName("uzsakymas_ibfk_1");
            });

            modelBuilder.Entity<UzsakymoPreke>(entity =>
            {
                entity.ToTable("uzsakymo_preke");

                entity.HasIndex(e => e.FkPicaid)
                    .HasName("fk_Picaid");

                entity.HasIndex(e => e.FkUzsakymasid)
                    .HasName("fk_Uzsakymasid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPicaid)
                    .HasColumnName("fk_Picaid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkUzsakymasid)
                    .HasColumnName("fk_Uzsakymasid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kiekis)
                    .HasColumnName("kiekis")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkPica)
                    .WithMany(p => p.UzsakymoPreke)
                    .HasForeignKey(d => d.FkPicaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uzsakymo_preke_ibfk_1");

                entity.HasOne(d => d.FkUzsakymas)
                    .WithMany(p => p.UzsakymoPreke)
                    .HasForeignKey(d => d.FkUzsakymasid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uzsakymo_preke_ibfk_3");
            });
            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("shopping_cart");

                entity.HasIndex(e => e.FkPicaid)
                    .HasName("fk_Picaid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPicaid)
                    .HasColumnName("fk_Picaid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kiekis)
                    .HasColumnName("kiekis")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql(null);

                entity.HasOne(d => d.FkPica)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.FkPicaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shopping_cart_ibfk_1");

                entity.HasOne(d => d.FkKlientas)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.FkKlientasid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("shopping_cart_ibfk_3");
            });

            modelBuilder.Entity<Nauja>(entity =>
            {
                entity.ToTable("nauja");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)");

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
