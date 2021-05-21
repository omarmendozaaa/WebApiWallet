﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiWallet.Contexts;

namespace WebApiWallet.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.3.21201.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiWallet.Entities.Analisis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("costesfinales")
                        .HasColumnType("real");

                    b.Property<float>("costesiniciales")
                        .HasColumnType("real");

                    b.Property<float>("descuento")
                        .HasColumnType("real");

                    b.Property<int>("num_dias")
                        .HasColumnType("int");

                    b.Property<float>("retencion")
                        .HasColumnType("real");

                    b.Property<double>("tasadescontada")
                        .HasColumnType("float");

                    b.Property<double>("tce_anual")
                        .HasColumnType("float");

                    b.Property<double>("te_anual")
                        .HasColumnType("float");

                    b.Property<double>("tefectiva")
                        .HasColumnType("float");

                    b.Property<float>("valorneto")
                        .HasColumnType("real");

                    b.Property<float>("valortotalentregar")
                        .HasColumnType("real");

                    b.Property<float>("valortotalrecibir")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Analisis");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Cartera", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("TCEA")
                        .HasColumnType("real");

                    b.Property<float>("TIR")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Carteras");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Costes_fin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Costos_gastosId")
                        .HasColumnType("int");

                    b.Property<int>("Costos_gastos_id")
                        .HasColumnType("int");

                    b.Property<string>("motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo_valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Costos_gastosId");

                    b.ToTable("Costes_fins");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Costes_ini", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Costos_gastosId")
                        .HasColumnType("int");

                    b.Property<int>("Costos_gastos_id")
                        .HasColumnType("int");

                    b.Property<string>("motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo_valor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Costos_gastosId");

                    b.ToTable("Costes_inis");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Costos_gastos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("total_cg_fin")
                        .HasColumnType("float");

                    b.Property<double>("total_cg_ini")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Costos_Gastos");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarteraId")
                        .HasColumnType("int");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("distrito")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("razonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ruc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarteraId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnalisisId")
                        .HasColumnType("int");

                    b.Property<int>("CarteraId")
                        .HasColumnType("int");

                    b.Property<int>("Costos_gastosId")
                        .HasColumnType("int");

                    b.Property<int>("TasaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_emision")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_pago")
                        .HasColumnType("datetime2");

                    b.Property<double>("retencion")
                        .HasColumnType("float");

                    b.Property<double>("total_facturado")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AnalisisId");

                    b.HasIndex("CarteraId");

                    b.HasIndex("Costos_gastosId");

                    b.HasIndex("TasaId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Letra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnalisisId")
                        .HasColumnType("int");

                    b.Property<int>("CarteraId")
                        .HasColumnType("int");

                    b.Property<int>("Costos_gastosId")
                        .HasColumnType("int");

                    b.Property<int>("TasaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_giro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_vencimiento")
                        .HasColumnType("datetime2");

                    b.Property<double>("retencion")
                        .HasColumnType("float");

                    b.Property<double>("valor_Nom")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AnalisisId");

                    b.HasIndex("CarteraId");

                    b.HasIndex("Costos_gastosId");

                    b.HasIndex("TasaId");

                    b.ToTable("Letras");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Recibo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnalisisId")
                        .HasColumnType("int");

                    b.Property<int>("CarteraId")
                        .HasColumnType("int");

                    b.Property<int>("Costos_gastosId")
                        .HasColumnType("int");

                    b.Property<int>("TasaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_emision")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_pago")
                        .HasColumnType("datetime2");

                    b.Property<double>("retencion")
                        .HasColumnType("float");

                    b.Property<double>("total_recibir")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AnalisisId");

                    b.HasIndex("CarteraId");

                    b.HasIndex("Costos_gastosId");

                    b.HasIndex("TasaId");

                    b.ToTable("Recibos");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Tasa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("dias_ano")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_descuento")
                        .HasColumnType("datetime2");

                    b.Property<int>("plazo_tasa")
                        .HasColumnType("int");

                    b.Property<float>("tasa_efectiva")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Tasas");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contrasenya")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Costes_fin", b =>
                {
                    b.HasOne("WebApiWallet.Entities.Costos_gastos", "Costos_gastos")
                        .WithMany("Costes_fin")
                        .HasForeignKey("Costos_gastosId");

                    b.Navigation("Costos_gastos");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Costes_ini", b =>
                {
                    b.HasOne("WebApiWallet.Entities.Costos_gastos", "Costos_gastos")
                        .WithMany("Costes_ini")
                        .HasForeignKey("Costos_gastosId");

                    b.Navigation("Costos_gastos");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Empresa", b =>
                {
                    b.HasOne("WebApiWallet.Entities.Cartera", "Cartera")
                        .WithMany()
                        .HasForeignKey("CarteraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiWallet.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cartera");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Factura", b =>
                {
                    b.HasOne("WebApiWallet.Entities.Analisis", "Analisis")
                        .WithMany()
                        .HasForeignKey("AnalisisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiWallet.Entities.Cartera", "Cartera")
                        .WithMany("Facturas")
                        .HasForeignKey("CarteraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiWallet.Entities.Costos_gastos", "Costos_gastos")
                        .WithMany()
                        .HasForeignKey("Costos_gastosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiWallet.Entities.Tasa", "Tasa")
                        .WithMany()
                        .HasForeignKey("TasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Analisis");

                    b.Navigation("Cartera");

                    b.Navigation("Costos_gastos");

                    b.Navigation("Tasa");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Letra", b =>
                {
                    b.HasOne("WebApiWallet.Entities.Analisis", "Analisis")
                        .WithMany()
                        .HasForeignKey("AnalisisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiWallet.Entities.Cartera", "Cartera")
                        .WithMany("Letras")
                        .HasForeignKey("CarteraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiWallet.Entities.Costos_gastos", "Costos_gastos")
                        .WithMany()
                        .HasForeignKey("Costos_gastosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiWallet.Entities.Tasa", "Tasa")
                        .WithMany()
                        .HasForeignKey("TasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Analisis");

                    b.Navigation("Cartera");

                    b.Navigation("Costos_gastos");

                    b.Navigation("Tasa");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Recibo", b =>
                {
                    b.HasOne("WebApiWallet.Entities.Analisis", "Analisis")
                        .WithMany()
                        .HasForeignKey("AnalisisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiWallet.Entities.Cartera", "Cartera")
                        .WithMany("Recibos")
                        .HasForeignKey("CarteraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiWallet.Entities.Costos_gastos", "Costos_gastos")
                        .WithMany()
                        .HasForeignKey("Costos_gastosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiWallet.Entities.Tasa", "Tasa")
                        .WithMany()
                        .HasForeignKey("TasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Analisis");

                    b.Navigation("Cartera");

                    b.Navigation("Costos_gastos");

                    b.Navigation("Tasa");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Cartera", b =>
                {
                    b.Navigation("Facturas");

                    b.Navigation("Letras");

                    b.Navigation("Recibos");
                });

            modelBuilder.Entity("WebApiWallet.Entities.Costos_gastos", b =>
                {
                    b.Navigation("Costes_fin");

                    b.Navigation("Costes_ini");
                });
#pragma warning restore 612, 618
        }
    }
}
