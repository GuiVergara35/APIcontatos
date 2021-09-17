﻿// <auto-generated />
using System;
using ContactListAPI.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactListAPI.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("ContactListAPI.Domain.Entities.Campaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CampaignName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<Guid?>("IdUser")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("ContactListAPI.Domain.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<Guid?>("IdUser")
                        .HasColumnType("char(36)");

                    b.Property<int>("Niche")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ContactListAPI.Domain.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<Guid?>("IdUser")
                        .HasColumnType("char(36)");

                    b.Property<int>("Niche")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ContactListAPI.Domain.Entities.MessageSending", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdCampaign")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdContact")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdGroup")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Sent")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("IdCampaign");

                    b.HasIndex("IdContact");

                    b.HasIndex("IdGroup");

                    b.ToTable("MessageSendings");
                });

            modelBuilder.Entity("ContactListAPI.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ContactListAPI.Domain.Entities.Campaign", b =>
                {
                    b.HasOne("ContactListAPI.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ContactListAPI.Domain.Entities.Contact", b =>
                {
                    b.HasOne("ContactListAPI.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ContactListAPI.Domain.Entities.Group", b =>
                {
                    b.HasOne("ContactListAPI.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ContactListAPI.Domain.Entities.MessageSending", b =>
                {
                    b.HasOne("ContactListAPI.Domain.Entities.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("IdCampaign");

                    b.HasOne("ContactListAPI.Domain.Entities.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("IdContact");

                    b.HasOne("ContactListAPI.Domain.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("IdGroup");

                    b.Navigation("Campaign");

                    b.Navigation("Contact");

                    b.Navigation("Group");
                });
#pragma warning restore 612, 618
        }
    }
}
