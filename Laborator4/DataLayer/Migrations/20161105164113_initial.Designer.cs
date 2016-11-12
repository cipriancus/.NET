using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Laborator4;

namespace DataLayer.Migrations
{
    [DbContext(typeof(ProductManagement))]
    [Migration("20161105164113_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Laborator4.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categorii");
                });

            modelBuilder.Entity("Laborator4.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Clienti");
                });

            modelBuilder.Entity("Laborator4.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoryId");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Price");

                    b.Property<DateTime>("StardDate");

                    b.Property<double>("Vat");

                    b.Property<string>("description");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Produse");
                });

            modelBuilder.Entity("Laborator4.Product", b =>
                {
                    b.HasOne("Laborator4.Category")
                        .WithMany("allProductsInCategory")
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
