using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPatientCareSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CabinetId = table.Column<int>(type: "int", nullable: true),
                    SpecializationId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Cabinets_CabinetId",
                        column: x => x.CabinetId,
                        principalTable: "Cabinets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CabinetId",
                table: "Doctors",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DistrictId",
                table: "Doctors",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DistrictId",
                table: "Patients",
                column: "DistrictId");

            migrationBuilder.InsertData(
            table: "Cabinets",
            columns: new[] { "Id", "Number" },
            values: new object[,]
            {
                        { 1, "101-A" },
                        { 2, "101-B" },
                        { 3, "27Y" },
                        { 4, "223-N" }
            });

            migrationBuilder.InsertData(
            table: "Districts",
            columns: new[] { "Id", "Number" },
            values: new object[,]
            {
                        { 1, "Liv. 22" },
                        { 2, "Liv. 23" },
                        { 3, "Uvd. 17" },
                        { 4, "Uvd. 18" }
            });

            migrationBuilder.InsertData(
            table: "Specializations",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                        { 1, "Therapist" },
                        { 2, "Psychiatrist" },
                        { 3, "Surgeon" },
                        { 4, "Pathologist" }
            });

            migrationBuilder.InsertData(
            table: "Patients",
            columns: new[] { "Id", "Firstname", "Lastname", "Patronymic", "Address", "Birthday", "Gender", "DistrictId" },
            values: new object[,]
            {
                        { 1, "Ivanov", "Andrey", "Ivanovich", "Russian Federation, Moscow, Biryulevskaya st., bld. 2//10, appt. 42", DateTime.Parse("2001-01-21"), 0, 1 },
                        { 2, "Smirnov", "Oleg", "Alexeevich", "Russian Federation, Moscow, Altufievskoe Shosse, bld. 93/К. 1, appt. 27", DateTime.Parse("2000-06-17"), 0, 1 },
                        { 3, "Kuznetsov", "Ivan", "Petrovich", "Russian Federation, Irkutsk, Tsentralnyy mkrn, bld. 14, appt. 235" , DateTime.Parse("2003-04-17"), 0, 2},
                        { 4, "Popov", "Vladislav", "Ignatievich", "Russian Federation, Tyumen, Gastello, bld. 67, appt. 78", DateTime.Parse("1986-12-25"), 0, 3 },
                        { 5, "Petrov", "Pavel", "Gennadievich", "Russian Federation, Stavropol, Obiezdnaya st., bld. 8, appt. 205", DateTime.Parse("1993-04-08"), 0, 4  },
                        { 6, "Pavlov", "Andrey", "Stepanovich", "Russian Federation, Stavropol, Obiezdnaya st., bld. 8, appt. 206", DateTime.Parse("1993-04-09"), 0, 4  },
                        { 7, "Zacseva", "Polina", "Fedorovna", "Russian Federation, Tyumen, Gastello, bld. 67, appt. 76", DateTime.Parse("1998-05-17"), 1, 3 },
                        { 8, "Volkov", "Evgeniy", "Stepanovich", "Russian Federation, Tyumen, Gastello, bld. 23, appt. 12", DateTime.Parse("1944-03-03"), 0, 3 },
                        { 9, "Asadchaya", "Albina", "Igorevna", "Russian Federation, Irkutsk, Tsentralnyy mkrn, bld. 1, appt. 4", DateTime.Parse("2006-01-29"), 1, 2 },
                        { 10, "Golovach", "Elena", "Evgenievna", "Russian Federation, Irkutsk, Tsentralnyy mkrn, bld. 14, appt. 239" , DateTime.Parse("2003-04-17"), 0, 2},
            });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Fullname", "CabinetId", "SpecializationId", "DistrictId" },
                values: new object[,]
                {
                        { 1, "Andreev Ivan Ivanovich", 1, 1, 1 },
                        { 2, "Alexeev Oleg Damirovich", 2, 2, 1 },
                        { 3, "Sokolov Semen Stepanovich", 3, 3, 2},
                        { 4, "Fedorov Yan Mironovich", 4, 4, 2 },
                        { 5, "Tkachev Vladislav Sergeevich", 1, 1, 3 },
                        { 6, "Zevin Adam Silvestrovich", 4, 2, 3 },
                        { 7, "Carev Ignat Valdemarovich", 1, 3, 4 },
                        { 8, "Igorev Taras Kirillovich", 2, 4, 4 },
                        { 9, "Adamov Vladimir Vladimirovich", 4, 3, 4 },
                        { 10, "Tuzova Evangelina Stepanovna", 3, 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
