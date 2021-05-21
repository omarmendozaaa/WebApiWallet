using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiWallet.Migrations.ApplicationDb
{
    public partial class TablesCores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carteras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TCEA = table.Column<float>(type: "real", nullable: false),
                    TIR = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Costos_Gastos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total_cg_ini = table.Column<double>(type: "float", nullable: false),
                    total_cg_fin = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costos_Gastos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dias_ano = table.Column<int>(type: "int", nullable: false),
                    plazo_tasa = table.Column<int>(type: "int", nullable: false),
                    tasa_efectiva = table.Column<float>(type: "real", nullable: false),
                    fecha_descuento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Contrasenya = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Costes_fins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false),
                    Costos_gastosId = table.Column<int>(type: "int", nullable: true),
                    Costos_gastos_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costes_fins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Costes_fins_Costos_Gastos_Costos_gastosId",
                        column: x => x.Costos_gastosId,
                        principalTable: "Costos_Gastos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Costes_inis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo_valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false),
                    Costos_gastosId = table.Column<int>(type: "int", nullable: true),
                    Costos_gastos_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costes_inis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Costes_inis_Costos_Gastos_Costos_gastosId",
                        column: x => x.Costos_gastosId,
                        principalTable: "Costos_Gastos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_emision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_facturado = table.Column<double>(type: "float", nullable: false),
                    retencion = table.Column<double>(type: "float", nullable: false),
                    CarteraId = table.Column<int>(type: "int", nullable: false),
                    TasaId = table.Column<int>(type: "int", nullable: false),
                    Costos_gastosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Carteras_CarteraId",
                        column: x => x.CarteraId,
                        principalTable: "Carteras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_Costos_Gastos_Costos_gastosId",
                        column: x => x.Costos_gastosId,
                        principalTable: "Costos_Gastos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_Tasas_TasaId",
                        column: x => x.TasaId,
                        principalTable: "Tasas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Letras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_giro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_vencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor_Nom = table.Column<double>(type: "float", nullable: false),
                    retencion = table.Column<double>(type: "float", nullable: false),
                    CarteraId = table.Column<int>(type: "int", nullable: false),
                    TasaId = table.Column<int>(type: "int", nullable: false),
                    Costos_gastosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Letras_Carteras_CarteraId",
                        column: x => x.CarteraId,
                        principalTable: "Carteras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Letras_Costos_Gastos_Costos_gastosId",
                        column: x => x.Costos_gastosId,
                        principalTable: "Costos_Gastos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Letras_Tasas_TasaId",
                        column: x => x.TasaId,
                        principalTable: "Tasas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_emision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total_recibir = table.Column<double>(type: "float", nullable: false),
                    retencion = table.Column<double>(type: "float", nullable: false),
                    CarteraId = table.Column<int>(type: "int", nullable: false),
                    TasaId = table.Column<int>(type: "int", nullable: false),
                    Costos_gastosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recibos_Carteras_CarteraId",
                        column: x => x.CarteraId,
                        principalTable: "Carteras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recibos_Costos_Gastos_Costos_gastosId",
                        column: x => x.Costos_gastosId,
                        principalTable: "Costos_Gastos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recibos_Tasas_TasaId",
                        column: x => x.TasaId,
                        principalTable: "Tasas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ruc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    razonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    distrito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costes_fins_Costos_gastosId",
                table: "Costes_fins",
                column: "Costos_gastosId");

            migrationBuilder.CreateIndex(
                name: "IX_Costes_inis_Costos_gastosId",
                table: "Costes_inis",
                column: "Costos_gastosId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_UsuarioId",
                table: "Empresas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_CarteraId",
                table: "Facturas",
                column: "CarteraId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Costos_gastosId",
                table: "Facturas",
                column: "Costos_gastosId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_TasaId",
                table: "Facturas",
                column: "TasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Letras_CarteraId",
                table: "Letras",
                column: "CarteraId");

            migrationBuilder.CreateIndex(
                name: "IX_Letras_Costos_gastosId",
                table: "Letras",
                column: "Costos_gastosId");

            migrationBuilder.CreateIndex(
                name: "IX_Letras_TasaId",
                table: "Letras",
                column: "TasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_CarteraId",
                table: "Recibos",
                column: "CarteraId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_Costos_gastosId",
                table: "Recibos",
                column: "Costos_gastosId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_TasaId",
                table: "Recibos",
                column: "TasaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Costes_fins");

            migrationBuilder.DropTable(
                name: "Costes_inis");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Letras");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Carteras");

            migrationBuilder.DropTable(
                name: "Costos_Gastos");

            migrationBuilder.DropTable(
                name: "Tasas");
        }
    }
}
