using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiWallet.Migrations.ApplicationDb
{
    public partial class ANALisis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnalisisId",
                table: "Recibos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnalisisId",
                table: "Letras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnalisisId",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarteraId",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Analisis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    te_anual = table.Column<double>(type: "float", nullable: false),
                    num_dias = table.Column<int>(type: "int", nullable: false),
                    tefectiva = table.Column<double>(type: "float", nullable: false),
                    tasadescontada = table.Column<double>(type: "float", nullable: false),
                    descuento = table.Column<float>(type: "real", nullable: false),
                    retencion = table.Column<float>(type: "real", nullable: false),
                    costesiniciales = table.Column<float>(type: "real", nullable: false),
                    valorneto = table.Column<float>(type: "real", nullable: false),
                    valortotalrecibir = table.Column<float>(type: "real", nullable: false),
                    costesfinales = table.Column<float>(type: "real", nullable: false),
                    valortotalentregar = table.Column<float>(type: "real", nullable: false),
                    tce_anual = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analisis", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_AnalisisId",
                table: "Recibos",
                column: "AnalisisId");

            migrationBuilder.CreateIndex(
                name: "IX_Letras_AnalisisId",
                table: "Letras",
                column: "AnalisisId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_AnalisisId",
                table: "Facturas",
                column: "AnalisisId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CarteraId",
                table: "Empresas",
                column: "CarteraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Carteras_CarteraId",
                table: "Empresas",
                column: "CarteraId",
                principalTable: "Carteras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Analisis_AnalisisId",
                table: "Facturas",
                column: "AnalisisId",
                principalTable: "Analisis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Letras_Analisis_AnalisisId",
                table: "Letras",
                column: "AnalisisId",
                principalTable: "Analisis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recibos_Analisis_AnalisisId",
                table: "Recibos",
                column: "AnalisisId",
                principalTable: "Analisis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Carteras_CarteraId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Analisis_AnalisisId",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Letras_Analisis_AnalisisId",
                table: "Letras");

            migrationBuilder.DropForeignKey(
                name: "FK_Recibos_Analisis_AnalisisId",
                table: "Recibos");

            migrationBuilder.DropTable(
                name: "Analisis");

            migrationBuilder.DropIndex(
                name: "IX_Recibos_AnalisisId",
                table: "Recibos");

            migrationBuilder.DropIndex(
                name: "IX_Letras_AnalisisId",
                table: "Letras");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_AnalisisId",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_CarteraId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "AnalisisId",
                table: "Recibos");

            migrationBuilder.DropColumn(
                name: "AnalisisId",
                table: "Letras");

            migrationBuilder.DropColumn(
                name: "AnalisisId",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "CarteraId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Empresas");
        }
    }
}
