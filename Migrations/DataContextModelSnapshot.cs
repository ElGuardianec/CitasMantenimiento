// <auto-generated />
using System;
using CitasMantenimiento.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CitasMantenimiento.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CitasMantenimiento.Data.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AppointmentTimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int?>("statusVehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentTimeId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("statusVehicleId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("CitasMantenimiento.Data.Entities.AppointmentTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Time")
                        .IsUnique();

                    b.ToTable("AppointmentTimes");
                });

            modelBuilder.Entity("CitasMantenimiento.Data.Entities.StatusVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Status")
                        .IsUnique();

                    b.ToTable("StatusVehicles");
                });

            modelBuilder.Entity("CitasMantenimiento.Data.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Plaque")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("Id");

                    b.HasIndex("Plaque")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CitasMantenimiento.Data.Entities.Appointment", b =>
                {
                    b.HasOne("CitasMantenimiento.Data.Entities.AppointmentTime", "AppointmentTime")
                        .WithMany()
                        .HasForeignKey("AppointmentTimeId");

                    b.HasOne("CitasMantenimiento.Data.Entities.Vehicle", "Vehicle")
                        .WithMany("Appointments")
                        .HasForeignKey("VehicleId");

                    b.HasOne("CitasMantenimiento.Data.Entities.StatusVehicle", "statusVehicle")
                        .WithMany()
                        .HasForeignKey("statusVehicleId");

                    b.Navigation("AppointmentTime");

                    b.Navigation("Vehicle");

                    b.Navigation("statusVehicle");
                });

            modelBuilder.Entity("CitasMantenimiento.Data.Entities.Vehicle", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
