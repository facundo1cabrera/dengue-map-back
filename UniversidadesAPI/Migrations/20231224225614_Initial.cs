using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversidadesAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadisticaEntidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExigenciaAcademica = table.Column<int>(type: "int", nullable: false),
                    RelacionCalidadPrecio = table.Column<int>(type: "int", nullable: false),
                    Politizacion = table.Column<int>(type: "int", nullable: false),
                    CalidadAdministrativa = table.Column<int>(type: "int", nullable: false),
                    DisponibilidadDeHorarios = table.Column<int>(type: "int", nullable: false),
                    CalidadDeProfesores = table.Column<int>(type: "int", nullable: false),
                    DificultadIngreso = table.Column<int>(type: "int", nullable: false),
                    BolsaDeTrabajo = table.Column<int>(type: "int", nullable: false),
                    SalidaLaboral = table.Column<int>(type: "int", nullable: false),
                    Infraestructura = table.Column<int>(type: "int", nullable: false),
                    SatisfaccionProfesion = table.Column<int>(type: "int", nullable: false),
                    CalidadUniversidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadisticaEntidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsPublica = table.Column<bool>(type: "bit", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaginaWeb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieneCursoIngreso = table.Column<bool>(type: "bit", nullable: true),
                    EstadisticaEntidadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Universidades_EstadisticaEntidades_EstadisticaEntidadId",
                        column: x => x.EstadisticaEntidadId,
                        principalTable: "EstadisticaEntidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Facultades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publica = table.Column<bool>(type: "bit", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaginaWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversidadId = table.Column<int>(type: "int", nullable: true),
                    EstadisticaEntidadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facultades_EstadisticaEntidades_EstadisticaEntidadId",
                        column: x => x.EstadisticaEntidadId,
                        principalTable: "EstadisticaEntidades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facultades_Universidades_UniversidadId",
                        column: x => x.UniversidadId,
                        principalTable: "Universidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publica = table.Column<bool>(type: "bit", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDeEstudiosUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioCuota = table.Column<int>(type: "int", nullable: true),
                    CargaHorarioSemanal = table.Column<int>(type: "int", nullable: true),
                    TiempoPromedioFinalizacion = table.Column<int>(type: "int", nullable: true),
                    PorcentajeDesercion = table.Column<int>(type: "int", nullable: true),
                    FacultadId = table.Column<int>(type: "int", nullable: true),
                    EstadisticaEntidadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carreras_EstadisticaEntidades_EstadisticaEntidadId",
                        column: x => x.EstadisticaEntidadId,
                        principalTable: "EstadisticaEntidades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carreras_Facultades_FacultadId",
                        column: x => x.FacultadId,
                        principalTable: "Facultades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Opiniones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExigenciaAcademica = table.Column<int>(type: "int", nullable: true),
                    RelacionCalidadPrecio = table.Column<int>(type: "int", nullable: true),
                    Politizacion = table.Column<int>(type: "int", nullable: true),
                    CalidadAdministrativa = table.Column<int>(type: "int", nullable: true),
                    DisponibilidadDeHorarios = table.Column<int>(type: "int", nullable: true),
                    CalidadDeProfesores = table.Column<int>(type: "int", nullable: true),
                    DificultadIngreso = table.Column<int>(type: "int", nullable: true),
                    BolsaDeTrabajo = table.Column<int>(type: "int", nullable: true),
                    SalidaLaboral = table.Column<int>(type: "int", nullable: true),
                    Infraestructura = table.Column<int>(type: "int", nullable: true),
                    SatisfaccionProfesion = table.Column<int>(type: "int", nullable: true),
                    CalidadUniversidad = table.Column<int>(type: "int", nullable: true),
                    VolveriasAEstudiarLoMismo = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CarreraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opiniones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opiniones_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opiniones_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carreras_EstadisticaEntidadId",
                table: "Carreras",
                column: "EstadisticaEntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Carreras_FacultadId",
                table: "Carreras",
                column: "FacultadId");

            migrationBuilder.CreateIndex(
                name: "IX_Facultades_EstadisticaEntidadId",
                table: "Facultades",
                column: "EstadisticaEntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Facultades_UniversidadId",
                table: "Facultades",
                column: "UniversidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Opiniones_CarreraId",
                table: "Opiniones",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Opiniones_UserId",
                table: "Opiniones",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Universidades_EstadisticaEntidadId",
                table: "Universidades",
                column: "EstadisticaEntidadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opiniones");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Facultades");

            migrationBuilder.DropTable(
                name: "Universidades");

            migrationBuilder.DropTable(
                name: "EstadisticaEntidades");
        }
    }
}
