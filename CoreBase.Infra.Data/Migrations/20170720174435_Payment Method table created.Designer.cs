using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreBase.Infra.Data.Context;

namespace CoreBase.Infra.Data.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20170720174435_Payment Method table created")]
    partial class PaymentMethodtablecreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("CoreBase.Domain.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CoreBase.Domain.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("CoreBase.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("PaymentMethodID");

                    b.Property<decimal>("Price");

                    b.HasKey("ID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PaymentMethodID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CoreBase.Domain.Entities.Product", b =>
                {
                    b.HasOne("CoreBase.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CoreBase.Domain.Entities.PaymentMethod")
                        .WithMany("Products")
                        .HasForeignKey("PaymentMethodID");
                });
        }
    }
}
