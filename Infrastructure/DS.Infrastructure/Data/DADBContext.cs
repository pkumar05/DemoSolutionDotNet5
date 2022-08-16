using DS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DS.Infrastructure.SQL.Data
{
    public class DADBContext : DbContext
    {
        public DADBContext(DbContextOptions<DADBContext> options) : base(options)
        {

        }

        public virtual DbSet<Departments> CustomerOrders { get; set; }
        public virtual DbSet<Employees> Customers { get; set; }
        public virtual DbSet<EmployeeProfile> Orders { get; set; }
        public virtual DbSet<Profile> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            #region Commented Codes
            //modelBuilder.Entity<AD_AIRCRAFTS>(entity =>
            //{
            //    //entity.ToTable("IM_GROUPS_PROFILES", "IM");
            //    entity.HasOne(d => d.AircraftType)
            //         .WithMany(p => p.AdAircraft)
            //         .HasForeignKey(d => d.AIRCRAFTTYPE_ID);

            //    entity.HasOne(d => d.AircraftFamily)
            //        .WithMany(p => p.AdAircraft)
            //        .HasForeignKey(d => d.AIRCRAFTFAMILY_ID);


            //});

            #endregion

        }

    }


    public class ApplicationConfiguration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {

        }
    }
}
