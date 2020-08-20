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

        public virtual DbSet<Graphics> Graphics { get; set; }

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

            modelBuilder.Entity<Graphics>(entity =>
            {
                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Rssi).HasColumnName("rssi");
            });

            modelBuilder.Entity<Locations>().HasData(
                 new Locations { Id = 1, Name = "Ofis-1" },
                 new Locations { Id = 2, Name = "Ofis-2" },
                 new Locations { Id = 3, Name = "Ofis-3" },
                 new Locations { Id = 4, Name = "Ofis-4" },
                 new Locations { Id = 5, Name = "Açık Ofis" }
                );
            modelBuilder.Entity<Beacons>().HasData(
                 new Beacons { Id = 1, Mac = 12525006 ,Name = "Aykut", Type = "ibeacon", Location = "Ofis-1",Date= "2020/08/20 - 17:20",Rssi1= -10,Rssi2= -35, Rssi3= -40, Rssi4= -80 },
                 new Beacons { Id = 2, Mac = 12525009, Name = "Sanem", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -10, Rssi2 = -55, Rssi3 = -63, Rssi4 = -10 },
                 new Beacons { Id = 3, Mac = 12525008, Name = "İbrahim", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -10, Rssi2 = -35, Rssi3 = -40, Rssi4 = -90 },
                 new Beacons { Id = 4, Mac = 12525016, Name = "Mert", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -10, Rssi2 = -35, Rssi3 = -40, Rssi4 = -40 },
                 new Beacons { Id = 5, Mac = 12525024, Name = "Göknur", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -10, Rssi2 = -35, Rssi3 = -40, Rssi4 = -60 },
                 new Beacons { Id = 6, Mac = 12525006, Name = "Said", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -10, Rssi2 = -35, Rssi3 = -40, Rssi4 = -80 },
                 new Beacons { Id = 7, Mac = 12525037, Name = "Delal", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -10, Rssi2 = -35, Rssi3 = -63, Rssi4 = -10 },
                 new Beacons { Id = 8, Mac = 12525228, Name = "Betül", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -16, Rssi2 = -34, Rssi3 = -40, Rssi4 = -80 },
                 new Beacons { Id = 9, Mac = 12525013, Name = "Hakkı", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -12, Rssi2 = -35, Rssi3 = -40, Rssi4 = -40 },
                 new Beacons { Id = 10, Mac = 12525114, Name = "Ayşe", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -11, Rssi2 = -40, Rssi3 = -60, Rssi4 = -90 },
                 new Beacons { Id = 1, Mac = 12525006, Name = "Ziyaretçi-1", Type = "ibeacon", Location = "Ofis-2", Date = "2020/08/20 - 17:20", Rssi1 = -50, Rssi2 = -35, Rssi3 = -40, Rssi4 = -10 },
                 new Beacons { Id = 2, Mac = 12526009, Name = "Ziyaretçi-2", Type = "ibeacon", Location = "Ofis-2", Date = "2020/08/20 - 17:20", Rssi1 = -60, Rssi2 = -55, Rssi3 = -63, Rssi4 = -40 },
                 new Beacons { Id = 3, Mac = 12526008, Name = "Ziyaretçi-3", Type = "ibeacon", Location = "Ofis-2", Date = "2020/08/20 - 17:20", Rssi1 = -70, Rssi2 = -35, Rssi3 = -40, Rssi4 = -60 },
                 new Beacons { Id = 4, Mac = 12526011, Name = "Ziyaretçi-4", Type = "ibeacon", Location = "Ofis-2", Date = "2020/08/20 - 17:20", Rssi1 = -30, Rssi2 = -35, Rssi3 = -30, Rssi4 = -70 },
                 new Beacons { Id = 5, Mac = 12526021, Name = "Ziyaretçi-5", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -50, Rssi2 = -35, Rssi3 = -30, Rssi4 = -50 },
                 new Beacons { Id = 6, Mac = 12526001, Name = "Ziyaretçi-6", Type = "ibeacon", Location = "Ofis-2", Date = "2020/08/20 - 17:20", Rssi1 = -30, Rssi2 = -35, Rssi3 = -20, Rssi4 = -70 },
                 new Beacons { Id = 7, Mac = 12526031, Name = "Ziyaretçi-7", Type = "ibeacon", Location = "Ofis-2", Date = "2020/08/20 - 17:20", Rssi1 = -30, Rssi2 = -35, Rssi3 = -23, Rssi4 = -20 },
                 new Beacons { Id = 8, Mac = 12526228, Name = "Ziyaretçi-8", Type = "ibeacon", Location = "Ofis-2", Date = "2020/08/20 - 17:20", Rssi1 = -50, Rssi2 = -34, Rssi3 = -20, Rssi4 = -10 },
                 new Beacons { Id = 9, Mac = 12526013, Name = "Ziyaretçi-9", Type = "ibeacon", Location = "Ofis-2", Date = "2020/08/20 - 17:20", Rssi1 = -10, Rssi2 = -35, Rssi3 = -40, Rssi4 = -10 },
                 new Beacons { Id = 10, Mac = 12526112, Name = "Ziyaretçi-10", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -11, Rssi2 = -40, Rssi3 = -60, Rssi4 = -20 },
                 new Beacons { Id = 11, Mac = 12524006, Name = "Personel-1", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -50, Rssi2 = -35, Rssi3 = -40, Rssi4 = -10 },
                 new Beacons { Id = 12, Mac = 12524009, Name = "Personel-2", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -60, Rssi2 = -55, Rssi3 = -63, Rssi4 = -20 },
                 new Beacons { Id = 13, Mac = 12524008, Name = "Personel-3", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -70, Rssi2 = -35, Rssi3 = -40, Rssi4 = -30 },
                 new Beacons { Id = 14, Mac = 12524011, Name = "Personel-4", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -30, Rssi2 = -35, Rssi3 = -30, Rssi4 = -10 },
                 new Beacons { Id = 15, Mac = 12524021, Name = "Personel-5", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -50, Rssi2 = -35, Rssi3 = -30, Rssi4 = -20 },
                 new Beacons { Id = 16, Mac = 12524001, Name = "Personel-6", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -30, Rssi2 = -35, Rssi3 = -20, Rssi4 = -35 },
                 new Beacons { Id = 17, Mac = 12524031, Name = "Personel-7", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -30, Rssi2 = -35, Rssi3 = -23, Rssi4 = -63 },
                 new Beacons { Id = 18, Mac = 12524228, Name = "Personel-8", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -50, Rssi2 = -34, Rssi3 = -20, Rssi4 = -20 },
                 new Beacons { Id = 19, Mac = 12524013, Name = "Personel-9", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -10, Rssi2 = -35, Rssi3 = -40, Rssi4 = -10 },
                 new Beacons { Id = 20, Mac = 12524112, Name = "Personel-10", Type = "ibeacon", Location = "Ofis-1", Date = "2020/08/20 - 17:20", Rssi1 = -11, Rssi2 = -40, Rssi3 = -60, Rssi4 = -20 }
                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}