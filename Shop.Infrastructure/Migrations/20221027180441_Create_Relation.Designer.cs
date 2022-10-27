﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Infrastructure;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20221027180441_Create_Relation")]
    partial class Create_Relation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shop.Domain.CategoryAgg.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Category", "Category");
                });

            modelBuilder.Entity("Shop.Domain.CommentAgg.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Comment", "Comment");
                });

            modelBuilder.Entity("Shop.Domain.Entities.SiteEntities.BannerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BannerPosition")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("Shop.Domain.Entities.SiteEntities.SliderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Shop.Domain.OrderAgg.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Orders", "Order");
                });

            modelBuilder.Entity("Shop.Domain.ProductAgg.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("SecondarySubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)");

                    b.Property<Guid>("SubCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Product", "Product");
                });

            modelBuilder.Entity("Shop.Domain.RoleAgg.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role", "Role");
                });

            modelBuilder.Entity("Shop.Domain.SellerAgg.Seller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NationalCode")
                        .IsUnique();

                    b.ToTable("Seller", "Seller");
                });

            modelBuilder.Entity("Shop.Domain.UserAgg.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("User", "User");
                });

            modelBuilder.Entity("Shop.Domain.CategoryAgg.Category", b =>
                {
                    b.HasOne("Shop.Domain.CategoryAgg.Category", null)
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");

                    b.OwnsOne("Common.Domain.ValueObjects.SeoData", "SeoData", b1 =>
                        {
                            b1.Property<Guid>("CategoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Canonical")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("Canonical");

                            b1.Property<bool>("IndexPage")
                                .HasColumnType("bit")
                                .HasColumnName("IndexPage");

                            b1.Property<string>("MetaDescription")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaDescription");

                            b1.Property<string>("MetaKeyWords")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaKeyWords");

                            b1.Property<string>("MetaTitle")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaTitle");

                            b1.Property<string>("Schema")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Schema");

                            b1.HasKey("CategoryId");

                            b1.ToTable("Category", "Category");

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });

                    b.Navigation("SeoData")
                        .IsRequired();
                });

            modelBuilder.Entity("Shop.Domain.OrderAgg.Order", b =>
                {
                    b.OwnsOne("Shop.Domain.OrderAgg.OrderAddress", "Address", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Family")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("NationalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(12)
                                .HasColumnType("nvarchar(12)");

                            b1.Property<string>("PostalAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<string>("Shire")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderId")
                                .IsUnique();

                            b1.ToTable("Addresses", "Order");

                            b1.WithOwner("Order")
                                .HasForeignKey("OrderId");

                            b1.Navigation("Order");
                        });

                    b.OwnsMany("Shop.Domain.OrderAgg.OrderItem", "Items", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Count")
                                .HasColumnType("int");

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("InventoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Price")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("InventoryId");

                            b1.HasIndex("OrderId");

                            b1.ToTable("Items", "Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("Shop.Domain.OrderAgg.ValueObjects.OrderDiscount", "Discount", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("DiscountAmount")
                                .HasColumnType("int");

                            b1.Property<string>("DiscountTitle")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("Shop.Domain.OrderAgg.ValueObjects.OrderShippingMethod", "OrderShipping", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("ShippingCost")
                                .HasColumnType("int");

                            b1.Property<string>("ShippingType")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders", "Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Discount");

                    b.Navigation("Items");

                    b.Navigation("OrderShipping");
                });

            modelBuilder.Entity("Shop.Domain.ProductAgg.Product", b =>
                {
                    b.OwnsOne("Common.Domain.ValueObjects.SeoData", "SeoData", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Canonical")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("Canonical");

                            b1.Property<bool>("IndexPage")
                                .HasColumnType("bit")
                                .HasColumnName("IndexPage");

                            b1.Property<string>("MetaDescription")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaDescription");

                            b1.Property<string>("MetaKeyWords")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaKeyWords");

                            b1.Property<string>("MetaTitle")
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("MetaTitle");

                            b1.Property<string>("Schema")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Schema");

                            b1.HasKey("ProductId");

                            b1.ToTable("Product", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsMany("Shop.Domain.ProductAgg.ProductImage", "Images", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ImageName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Sequence")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("ProductId");

                            b1.ToTable("Images", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsMany("Shop.Domain.ProductAgg.ProductSpecification", "Specifications", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Key")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("ProductId", "Id");

                            b1.ToTable("Specifications", "Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Images");

                    b.Navigation("SeoData")
                        .IsRequired();

                    b.Navigation("Specifications");
                });

            modelBuilder.Entity("Shop.Domain.RoleAgg.Role", b =>
                {
                    b.OwnsMany("Shop.Domain.RoleAgg.RolePermission", "Permissions", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("datetime2");

                            b1.Property<int>("Permission")
                                .HasColumnType("int");

                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("RoleId");

                            b1.ToTable("RolePermission", "Role");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Shop.Domain.SellerAgg.Seller", b =>
                {
                    b.OwnsMany("Shop.Domain.SellerAgg.SellerInventory", "Inventories", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Count")
                                .HasColumnType("int");

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("datetime2");

                            b1.Property<int?>("DiscountPercentage")
                                .HasColumnType("int");

                            b1.Property<int>("Price")
                                .HasColumnType("int");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("SellerId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("ProductId");

                            b1.HasIndex("SellerId");

                            b1.ToTable("Inventories", "Seller");

                            b1.WithOwner()
                                .HasForeignKey("SellerId");
                        });

                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("Shop.Domain.UserAgg.User", b =>
                {
                    b.OwnsMany("Shop.Domain.UserAgg.UserAddress", "Addresses", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("ActiveAddress")
                                .HasColumnType("bit");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Family")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("PostalAddress")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)");

                            b1.Property<string>("Shire")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Addresses", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("Common.Domain.ValueObjects.NationalCode", "NationalCode", b2 =>
                                {
                                    b2.Property<Guid>("UserAddressId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(10)
                                        .HasColumnType("nvarchar(10)")
                                        .HasColumnName("NationalCode");

                                    b2.HasKey("UserAddressId");

                                    b2.ToTable("Addresses", "User");

                                    b2.WithOwner()
                                        .HasForeignKey("UserAddressId");
                                });

                            b1.OwnsOne("Common.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b2 =>
                                {
                                    b2.Property<Guid>("UserAddressId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Value")
                                        .IsRequired()
                                        .HasMaxLength(11)
                                        .HasColumnType("nvarchar(11)")
                                        .HasColumnName("PhoneNumber");

                                    b2.HasKey("UserAddressId");

                                    b2.ToTable("Addresses", "User");

                                    b2.WithOwner()
                                        .HasForeignKey("UserAddressId");
                                });

                            b1.Navigation("NationalCode")
                                .IsRequired();

                            b1.Navigation("PhoneNumber")
                                .IsRequired();
                        });

                    b.OwnsMany("Shop.Domain.UserAgg.UserRole", "Roles", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("RoleId");

                            b1.HasIndex("UserId");

                            b1.ToTable("Roles", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("Shop.Domain.UserAgg.UserWallet", "Wallets", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("nvarchar(1000)");

                            b1.Property<DateTime?>("FinallyDate")
                                .HasColumnType("datetime2");

                            b1.Property<bool>("IsFinally")
                                .HasColumnType("bit");

                            b1.Property<int>("Price")
                                .HasColumnType("int");

                            b1.Property<int>("Type")
                                .HasColumnType("int");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("Wallets", "User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Addresses");

                    b.Navigation("Roles");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("Shop.Domain.CategoryAgg.Category", b =>
                {
                    b.Navigation("Childs");
                });
#pragma warning restore 612, 618
        }
    }
}
