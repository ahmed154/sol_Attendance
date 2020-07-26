﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pro_API.Data;

namespace pro_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200726002614_Update-IO-EmpId-DeviceId")]
    partial class UpdateIOEmpIdDeviceId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("pro_Models.Models.Depart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departs");
                });

            modelBuilder.Entity("pro_Models.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Port")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("pro_Models.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartId")
                        .HasColumnType("int");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SecId")
                        .HasColumnType("int");

                    b.Property<int?>("WorksysId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartId");

                    b.HasIndex("DeviceId");

                    b.HasIndex("SecId");

                    b.HasIndex("WorksysId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("pro_Models.Models.IO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("Event")
                        .HasColumnType("int");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Priority")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("IOs");
                });

            modelBuilder.Entity("pro_Models.Models.IOEdit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeviceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("Event")
                        .HasColumnType("int");

                    b.Property<string>("Index")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IOEdits");
                });

            modelBuilder.Entity("pro_Models.Models.Sec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Secs");
                });

            modelBuilder.Entity("pro_Models.Models.Worksys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AttEarly")
                        .HasColumnType("bit");

                    b.Property<bool>("BonusCheck")
                        .HasColumnType("bit");

                    b.Property<int>("Day_Hours")
                        .HasColumnType("int");

                    b.Property<int>("Day_Min")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("First_ae")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("First_as")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("First_le")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("First_ls")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("LateCheck")
                        .HasColumnType("bit");

                    b.Property<bool>("LeaveEarly")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Second_ae")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Second_as")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Second_le")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Second_ls")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("frBonus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("frPeriod_Hours")
                        .HasColumnType("datetime2");

                    b.Property<bool>("frType")
                        .HasColumnType("bit");

                    b.Property<bool>("frf")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("frfa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("frfe")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("frfs")
                        .HasColumnType("datetime2");

                    b.Property<bool>("frh")
                        .HasColumnType("bit");

                    b.Property<bool>("frs")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("frsa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("frse")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("frss")
                        .HasColumnType("datetime2");

                    b.Property<bool>("moBonus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("moPeriod_Hours")
                        .HasColumnType("datetime2");

                    b.Property<bool>("moType")
                        .HasColumnType("bit");

                    b.Property<bool>("mof")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("mofa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("mofe")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("mofs")
                        .HasColumnType("datetime2");

                    b.Property<bool>("moh")
                        .HasColumnType("bit");

                    b.Property<bool>("mos")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("mosa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("mose")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("moss")
                        .HasColumnType("datetime2");

                    b.Property<bool>("saBonus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("saPeriod_Hours")
                        .HasColumnType("datetime2");

                    b.Property<bool>("saType")
                        .HasColumnType("bit");

                    b.Property<bool>("saf")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("safa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("safe")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("safs")
                        .HasColumnType("datetime2");

                    b.Property<bool>("sah")
                        .HasColumnType("bit");

                    b.Property<bool>("sas")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("sasa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("sase")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("sass")
                        .HasColumnType("datetime2");

                    b.Property<bool>("suBonus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("suPeriod_Hours")
                        .HasColumnType("datetime2");

                    b.Property<bool>("suType")
                        .HasColumnType("bit");

                    b.Property<bool>("suf")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("sufa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("sufe")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("sufs")
                        .HasColumnType("datetime2");

                    b.Property<bool>("suh")
                        .HasColumnType("bit");

                    b.Property<bool>("sus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("susa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("suse")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("suss")
                        .HasColumnType("datetime2");

                    b.Property<bool>("thBonus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("thPeriod_Hours")
                        .HasColumnType("datetime2");

                    b.Property<bool>("thType")
                        .HasColumnType("bit");

                    b.Property<bool>("thf")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("thfa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("thfe")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("thfs")
                        .HasColumnType("datetime2");

                    b.Property<bool>("thh")
                        .HasColumnType("bit");

                    b.Property<bool>("ths")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("thsa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("thse")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("thss")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ti")
                        .HasColumnType("bit");

                    b.Property<bool>("tuBonus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("tuPeriod_Hours")
                        .HasColumnType("datetime2");

                    b.Property<bool>("tuType")
                        .HasColumnType("bit");

                    b.Property<bool>("tuf")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("tufa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("tufe")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("tufs")
                        .HasColumnType("datetime2");

                    b.Property<bool>("tuh")
                        .HasColumnType("bit");

                    b.Property<bool>("tus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("tusa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("tuse")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("tuss")
                        .HasColumnType("datetime2");

                    b.Property<bool>("weBonus")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("wePeriod_Hours")
                        .HasColumnType("datetime2");

                    b.Property<bool>("weType")
                        .HasColumnType("bit");

                    b.Property<bool>("wef")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("wefa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("wefe")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("wefs")
                        .HasColumnType("datetime2");

                    b.Property<bool>("weh")
                        .HasColumnType("bit");

                    b.Property<bool>("wes")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("wesa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("wese")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("wess")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Worksyss");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("pro_Models.Models.Employee", b =>
                {
                    b.HasOne("pro_Models.Models.Depart", "Depart")
                        .WithMany()
                        .HasForeignKey("DepartId");

                    b.HasOne("pro_Models.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId");

                    b.HasOne("pro_Models.Models.Sec", "Sec")
                        .WithMany()
                        .HasForeignKey("SecId");

                    b.HasOne("pro_Models.Models.Worksys", "Worksys")
                        .WithMany()
                        .HasForeignKey("WorksysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
