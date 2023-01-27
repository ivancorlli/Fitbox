﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserContext.Infrastructure.src.Context;

#nullable disable

namespace UserContext.Infrastructure.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UserContext.Domain.src.Abstractions.IAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<sbyte>("EmailVerified")
                        .HasColumnType("tinyint");

                    b.Property<sbyte>("IsNew")
                        .HasColumnType("tinyint");

                    b.Property<sbyte>("PhoneVerified")
                        .HasColumnType("tinyint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);

                    b.HasDiscriminator<string>("UserType").HasValue("IAccount");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("UserContext.Domain.src.Entity.PersonProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PersonProfile");
                });

            modelBuilder.Entity("UserContext.Domain.src.Entity.Account.Person", b =>
                {
                    b.HasBaseType("UserContext.Domain.src.Abstractions.IAccount");

                    b.HasDiscriminator().HasValue("Person");
                });

            modelBuilder.Entity("UserContext.Domain.src.Entity.PersonProfile", b =>
                {
                    b.HasOne("UserContext.Domain.src.Entity.Account.Person", "Account")
                        .WithOne("Profile")
                        .HasForeignKey("UserContext.Domain.src.Entity.PersonProfile", "Id");

                    b.OwnsOne("UserContext.Domain.src.ValueObject.PersonName", "Name", b1 =>
                        {
                            b1.Property<Guid>("PersonProfileId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar");

                            b1.HasKey("PersonProfileId");

                            b1.ToTable("PersonProfile");

                            b1.WithOwner()
                                .HasForeignKey("PersonProfileId");
                        });

                    b.OwnsOne("SharedKernell.src.ValueObject.TimeStamps", "TimeStamps", b1 =>
                        {
                            b1.Property<Guid>("PersonProfileId")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("date");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("date");

                            b1.HasKey("PersonProfileId");

                            b1.ToTable("PersonProfile");

                            b1.WithOwner()
                                .HasForeignKey("PersonProfileId");
                        });

                    b.OwnsOne("UserContext.Domain.src.ValueObject.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PersonProfileId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar");

                            b1.Property<string>("Street")
                                .HasColumnType("longtext");

                            b1.Property<int?>("StreetNumber")
                                .HasColumnType("int");

                            b1.HasKey("PersonProfileId");

                            b1.ToTable("PersonProfile");

                            b1.WithOwner()
                                .HasForeignKey("PersonProfileId");

                            b1.OwnsOne("UserContext.Domain.src.ValueObject.ZipCode", "ZipCode", b2 =>
                                {
                                    b2.Property<Guid>("AddressPersonProfileId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(8)
                                        .HasColumnType("varchar");

                                    b2.HasKey("AddressPersonProfileId");

                                    b2.ToTable("PersonProfile");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressPersonProfileId");
                                });

                            b1.Navigation("ZipCode")
                                .IsRequired();
                        });

                    b.OwnsOne("UserContext.Domain.src.ValueObject.Bio", "Bio", b1 =>
                        {
                            b1.Property<Guid>("PersonProfileId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(300)
                                .HasColumnType("varchar");

                            b1.HasKey("PersonProfileId");

                            b1.ToTable("PersonProfile");

                            b1.WithOwner()
                                .HasForeignKey("PersonProfileId");
                        });

                    b.OwnsOne("UserContext.Domain.src.ValueObject.EmergencyContact", "EmergencyContact", b1 =>
                        {
                            b1.Property<Guid>("PersonProfileId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("RelationShip")
                                .HasColumnType("int");

                            b1.HasKey("PersonProfileId");

                            b1.ToTable("PersonProfile");

                            b1.WithOwner()
                                .HasForeignKey("PersonProfileId");

                            b1.OwnsOne("UserContext.Domain.src.ValueObject.ContactPhone", "Phone", b2 =>
                                {
                                    b2.Property<Guid>("EmergencyContactPersonProfileId")
                                        .HasColumnType("char(36)");

                                    b2.Property<int>("AreaCode")
                                        .HasColumnType("int");

                                    b2.Property<string>("CountryPrefix")
                                        .HasColumnType("longtext");

                                    b2.Property<long>("Number")
                                        .HasColumnType("bigint");

                                    b2.HasKey("EmergencyContactPersonProfileId");

                                    b2.ToTable("PersonProfile");

                                    b2.WithOwner()
                                        .HasForeignKey("EmergencyContactPersonProfileId");
                                });

                            b1.OwnsOne("UserContext.Domain.src.ValueObject.PersonName", "Name", b2 =>
                                {
                                    b2.Property<Guid>("EmergencyContactPersonProfileId")
                                        .HasColumnType("char(36)");

                                    b2.Property<string>("FirstName")
                                        .IsRequired()
                                        .HasMaxLength(15)
                                        .HasColumnType("varchar");

                                    b2.Property<string>("LastName")
                                        .IsRequired()
                                        .HasMaxLength(15)
                                        .HasColumnType("varchar");

                                    b2.HasKey("EmergencyContactPersonProfileId");

                                    b2.ToTable("PersonProfile");

                                    b2.WithOwner()
                                        .HasForeignKey("EmergencyContactPersonProfileId");
                                });

                            b1.Navigation("Name")
                                .IsRequired();

                            b1.Navigation("Phone")
                                .IsRequired();
                        });

                    b.OwnsOne("UserContext.Domain.src.ValueObject.MedicalInfo", "Medical", b1 =>
                        {
                            b1.Property<Guid>("PersonProfileId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Aptitude")
                                .HasMaxLength(50)
                                .HasColumnType("varchar");

                            b1.Property<string>("Disabilities")
                                .HasMaxLength(300)
                                .HasColumnType("varchar");

                            b1.HasKey("PersonProfileId");

                            b1.ToTable("PersonProfile");

                            b1.WithOwner()
                                .HasForeignKey("PersonProfileId");
                        });

                    b.Navigation("Account");

                    b.Navigation("Address");

                    b.Navigation("Bio");

                    b.Navigation("EmergencyContact");

                    b.Navigation("Medical");

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("TimeStamps")
                        .IsRequired();
                });

            modelBuilder.Entity("UserContext.Domain.src.Entity.Account.Person", b =>
                {
                    b.OwnsOne("SharedKernell.src.ValueObject.TimeStamps", "TimeStamps", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("char(36)");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("date");

                            b1.Property<DateTime>("UpdatedAt")
                                .HasColumnType("date");

                            b1.HasKey("PersonId");

                            b1.ToTable("Account");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.OwnsOne("UserContext.Domain.src.ValueObject.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("varchar");

                            b1.HasKey("PersonId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Account");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.OwnsOne("UserContext.Domain.src.ValueObject.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("varchar");

                            b1.HasKey("PersonId");

                            b1.ToTable("Account");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.OwnsOne("UserContext.Domain.src.ValueObject.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("char(36)");

                            b1.Property<short>("AreaCode")
                                .HasColumnType("smallint");

                            b1.Property<string>("CountryPrefix")
                                .HasColumnType("longtext");

                            b1.Property<long>("PhoneNumber")
                                .HasColumnType("bigint");

                            b1.HasKey("PersonId");

                            b1.HasIndex("PhoneNumber")
                                .IsUnique();

                            b1.ToTable("Account");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.OwnsOne("UserContext.Domain.src.ValueObject.Username", "Username", b1 =>
                        {
                            b1.Property<Guid>("PersonId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar");

                            b1.HasKey("PersonId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .IsDescending();

                            b1.ToTable("Account");

                            b1.WithOwner()
                                .HasForeignKey("PersonId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("Phone");

                    b.Navigation("TimeStamps")
                        .IsRequired();

                    b.Navigation("Username")
                        .IsRequired();
                });

            modelBuilder.Entity("UserContext.Domain.src.Entity.Account.Person", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
