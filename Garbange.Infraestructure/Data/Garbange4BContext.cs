using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Garbange.Domain.Entities;

#nullable disable

namespace Garbange.Infraestructure.Data
{
    public partial class Garbange4BContext : DbContext
    {
        public Garbange4BContext()
        {
        }

        public Garbange4BContext(DbContextOptions<Garbange4BContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Denuncium> Denuncia { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }

        
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Garbange4B.mssql.somee.com;Initial Catalog=Garbange4B;Persist Security Info=False;User ID=SamuelBrekMS_SQLLogin_2;Password=x7c25ir7pn");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Denuncium>(entity =>
            {
                entity.HasKey(e => e.IdDenuncia)
                    .HasName("PK_Denuncia");

                entity.Property(e => e.ColoniaDenuncia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coloniaDenuncia");

                entity.Property(e => e.DescripcionDenuncia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcionDenuncia");

                entity.Property(e => e.FechaDenuncia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fechaDenuncia");

                entity.Property(e => e.IdDenuncia)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idDenuncia");

                entity.Property(e => e.ImagenDenuncia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imagenDenuncia");

                entity.Property(e => e.MotivoDenuncia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("motivoDenuncia");

                entity.Property(e => e.UbicacionDenuncia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ubicacionDenuncia");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PK_Evento");

                entity.ToTable("Evento");

                entity.Property(e => e.DescripcionEvento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionEvento");

                entity.Property(e => e.FechaEvento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fechaEvento");

                entity.Property(e => e.HoraEvento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("horaEvento");

                entity.Property(e => e.IdEvento)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEvento");

                entity.Property(e => e.ImagenEvento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imagenEvento");

                entity.Property(e => e.NombreEvento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreEvento");

                entity.Property(e => e.PersonasEvento).HasColumnName("personasEvento");

                entity.Property(e => e.UbicacionEvento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ubicacionEvento");
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.HasKey(e => e.IdRegistro)
                    .HasName("PK_REGISTRO");

                entity.ToTable("REGISTRO");

                entity.Property(e => e.ApellidoUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidoUsuario");

                entity.Property(e => e.ContrasenaUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contrasenaUsuario");

                entity.Property(e => e.CorreoUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correoUsuario");

                entity.Property(e => e.FechanacUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fechanacUsuario");

                entity.Property(e => e.IdRegistro)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idRegistro");

                entity.Property(e => e.NicknameUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nicknameUsuario");

                entity.Property(e => e.NivelUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nivelUsuario");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreUsuario");

                entity.Property(e => e.TelefonoUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefonoUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
