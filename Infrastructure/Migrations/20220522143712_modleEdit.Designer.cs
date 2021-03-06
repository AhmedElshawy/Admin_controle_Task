// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220522143712_modleEdit")]
    partial class modleEdit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategotyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategotyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategotyId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Core.Models.CategoryProp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BrandName")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Color")
                        .HasColumnType("bit");

                    b.Property<bool>("Height")
                        .HasColumnType("bit");

                    b.Property<bool>("Length")
                        .HasColumnType("bit");

                    b.Property<bool>("ScreenReslution")
                        .HasColumnType("bit");

                    b.Property<bool>("SkinType")
                        .HasColumnType("bit");

                    b.Property<bool>("Volume")
                        .HasColumnType("bit");

                    b.Property<bool>("Weight")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId")
                        .IsUnique();

                    b.ToTable("CategoryProp");
                });

            modelBuilder.Entity("Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Core.Models.ProductPropValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("Length")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ScreenReslution")
                        .HasColumnType("int");

                    b.Property<string>("SkinType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Volume")
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPropValues");
                });

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.HasOne("Core.Models.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategotyId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Core.Models.CategoryProp", b =>
                {
                    b.HasOne("Core.Models.Category", "Category")
                        .WithOne("CategoryProp")
                        .HasForeignKey("Core.Models.CategoryProp", "CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.Models.Product", b =>
                {
                    b.HasOne("Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.Models.ProductPropValues", b =>
                {
                    b.HasOne("Core.Models.Product", "Product")
                        .WithMany("ProductPropValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Core.Models.Category", b =>
                {
                    b.Navigation("CategoryProp");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Core.Models.Product", b =>
                {
                    b.Navigation("ProductPropValues");
                });
#pragma warning restore 612, 618
        }
    }
}
