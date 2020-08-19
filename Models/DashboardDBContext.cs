using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudMVCCore.Models
{
    public partial class DashboardDBContext : DbContext
    {
        public DashboardDBContext()
        {
        }

        public DashboardDBContext(DbContextOptions<DashboardDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beacons> Beacons { get; set; }
        public virtual DbSet<Gateways> Gateways { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }


        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=localhost;Database=DashboardDB;Trusted_Connection=True;");
        //            }
        //        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beacons>(entity =>
            {
                entity.Property(e => e.Date).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Rssi1).HasColumnName("rssi1");

                entity.Property(e => e.Rssi2).HasColumnName("rssi2");

                entity.Property(e => e.Rssi3).HasColumnName("rssi3");

                entity.Property(e => e.Rssi4).HasColumnName("rssi4");

                entity.Property(e => e.Type).HasMaxLength(100);
            });

            modelBuilder.Entity<Gateways>(entity =>
            {
                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(100);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
