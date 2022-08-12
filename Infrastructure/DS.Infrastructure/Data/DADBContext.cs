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
        public virtual DbSet<Employee> Customers { get; set; }
        public virtual DbSet<EmployeeProfile> Orders { get; set; }
        public virtual DbSet<Profile> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }


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

            #region Configure based on commented line
            //modelBuilder.Entity<IM_USERS_GROUPS>(entity =>
            //{
            //    entity.HasOne(d => d.Group)
            //          .WithMany(p => p.ImUsersGroups)
            //          .HasForeignKey(d => d.Group_ID);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.ImUsersGroups)
            //        .HasForeignKey(d => d.User_Name);
            //});

            //modelBuilder.Entity<IM_GROUPS_PERMISSIONS>(entity =>
            //{
            //    entity.HasOne(d => d.Group)
            //        .WithMany(p => p.ImRequestPermissions)
            //        .HasForeignKey(d => d.GROUP_ID);

            //    entity.HasOne(d => d.Permission)
            //        .WithMany(p => p.ImRequestPermissions)
            //        .HasForeignKey(d => d.PERMISSION_ID);

            //    entity.HasOne(d => d.ScreenAction)
            //        .WithMany(p => p.ImRequestPermissions)
            //        .HasForeignKey(d => d.SCREEN_ACTION_ID);

            //    entity.HasOne(d => d.Service)
            //        .WithMany(p => p.ImRequestPermissions)
            //        .HasForeignKey(d => d.SERVICE_ID);

            //    entity.HasOne(d => d.SubService)
            //        .WithMany(p => p.ImRequestPermissions)
            //        .HasForeignKey(d => d.SUB_SERVICE_ID);
            //});

            //modelBuilder.Entity<IM_SUB_SERVICES>(entity =>
            //{
            //    entity.HasOne(d => d.Service)
            //   .WithMany(p => p.ImSubServices)
            //   .HasForeignKey(d => d.Service_ID);
            //});

            //modelBuilder.Entity<IM_SCREEN_ACTIONS>(entity =>
            //{
            //    entity.HasOne(d => d.SubService)
            //    .WithMany(p => p.ImScreenActions)
            //    .HasForeignKey(d => d.Sub_Service_ID);
            //});

            //modelBuilder.Entity<IM_GROUPS_OU>(entity =>
            //{

            //    entity.HasOne(d => d.Group)
            //        .WithMany(p => p.ImGroupsOu)
            //        .HasForeignKey(d => d.GROUP_ID);

            //    entity.HasOne(d => d.Ou)
            //        .WithMany(p => p.ImGroupsOu)
            //        .HasForeignKey(d => d.OU_ID);
            //});

            //modelBuilder.Entity<IM_OU>(entity =>
            //{

            //    entity.HasOne(d => d.Company)
            //        .WithMany(p => p.ImOu)
            //        .HasForeignKey(d => d.Company_Id);

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
