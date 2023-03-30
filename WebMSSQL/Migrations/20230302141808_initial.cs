using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMSSQL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories_new",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories_new", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "resourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "categories_new",
                columns: new[] { "Id", "Article", "Description", "Key", "Name" },
                values: new object[,]
                {
                    { 1, "ddd", "Твердое вещество ", 1, "Metal" },
                    { 2, "hjv,jjkjkh", "Красивый камушек", 2, "Brilliant" }
                });

            migrationBuilder.InsertData(
                table: "resourses",
                columns: new[] { "Id", "CategoryId", "description", "name", "path" },
                values: new object[,]
                {
                    { 1, 1, "Palladium is a chemical element with the symbol Pd and atomic number 46. It is a rare and lustrous silvery-white metal discovered in 1803 by the English chemist William Hyde Wollaston. He named it after the asteroid Pallas, which was itself named after the epithet of the Greek goddess Athena, acquired by her when she slew Pallas. Palladium, platinum, rhodium, ruthenium, iridium and osmium form a group of elements referred to as the platinum group metals (PGMs). They have similar chemical properties, but palladium has the lowest melting point and is the least dense of them.", "Yrilski Palalladiy", "palaldium" },
                    { 12, 1, "Gold is a chemical element with the symbol Au (from Latin: aurum) and atomic number 79, making it one of the higher atomic number elements that occur naturally. It is a bright, slightly orange-yellow, dense, soft, malleable, and ductile metal in a pure form. Chemically, gold is a transition metal and a group 11 element. It is one of the least reactive chemical elements and is solid under standard conditions. Gold often occurs in free elemental (native) form, as nuggets or grains, in rocks, veins, and alluvial deposits.", "Russian gold", "gold" },
                    { 13, 0, "Silver is a chemical element with the symbol Ag (from the Latin argentum, derived from the Proto-Indo-European h₂erǵ: shiny or white) and atomic number 47. A soft, white, lustrous transition metal, it exhibits the highest electrical conductivity, thermal conductivity, and reflectivity of any metal.[4] The metal is found in the Earth's crust in the pure, free elemental form (native silver), as an alloy with gold and other metals, and in minerals such as argentite and chlorargyrite. ", "Silver", "silver" },
                    { 14, 1, "Copper is a chemical element with the symbol Cu (from Latin: cuprum) and atomic number 29. It is a soft, malleable, and ductile metal with very high thermal and electrical conductivity. A freshly exposed surface of pure copper has a pinkish-orange color. Copper is used as a conductor of heat and electricity, as a building material, and as a constituent of various metal alloys, such as sterling silver used in jewelry, cupronickel used to make marine hardware and coins, and constantan used in strain gauges and thermocouples for temperature measurement.", "Copper", "copper" },
                    { 16, 2, "Type Ia diamonds make up about 95% of all natural diamonds. The nitrogen impurities, up to 0.3% (3000 ppm), are clustered within the carbon lattice, and are relatively widespread. The absorption spectrum of the nitrogen clusters can cause the diamond to absorb blue light, making it appear pale yellow or almost colorless. Most Ia diamonds are a mixture of IaA and IaB material; these diamonds belong to the Cape series, named after the diamond-rich region formerly known as Cape Province in South Africa, whose deposits are largely Type Ia.", "Type Ia", "typeIa" },
                    { 17, 2, "Type Ib make up about 0.1% of all natural diamonds. They contain up to 0.05% (500 ppm) of nitrogen, but the impurities are more diffuse, the atoms are dispersed throughout the crystal in isolated sites. Type Ib diamonds absorb green light in addition to blue, and have a more intense or darker yellow or brown colour than Type Ia diamonds. The stones have an intense yellow or occasionally brown tint; the rare canary diamonds belong to this type, which represents only 0.1% of known natural diamonds. The visible absorption spectrum is gradual, without sharp absorption bands.[4] Almost all HPHT synthetic diamonds are of Type Ib.", "Type IB", "typeIB" },
                    { 18, 2, "Type IIa diamonds make up 1–2% of all natural diamonds (1.8% of gem diamonds). These diamonds are almost or entirely devoid of impurities, and consequently are usually colourless and have the highest thermal conductivity. They are very transparent in ultraviolet, down to 230 nm. Occasionally, while Type IIa diamonds are being extruded towards the surface of the Earth, the pressure and tension can cause structural anomalies arising through plastic deformation during the growth of the tetrahedral crystal structure, leading to imperfections. These imperfections can confer a yellow, brown, orange, pink, red, or purple colour to the gem. Type IIa diamonds can have their structural deformations repaired via a high-pressure high-temperature (HPHT) process, removing much or all of the diamond's color.[6] Type IIa diamonds constitute a great percentage of Australian production. Many famous large diamonds, like the Cullinan, Koh-i-Noor, and Lesedi La Rona, are Type IIa. Synthetic diamonds grown using the CVD process typically also belong to this type.", "Type IIa", "typeIIa" },
                    { 19, 0, "Type IIb diamonds make up about 0.1% of all natural diamonds, making them one of the rarest natural diamonds and very valuable. In addition to having very low levels of nitrogen impurities comparable to Type IIa diamonds, Type IIb diamonds contain significant boron impurities. The absorption spectrum of boron causes these gems to absorb red, orange, and yellow light, lending Type IIb diamonds a light blue or grey color, though examples with low levels of boron impurities can also be colorless.", "Type IIb", "typeIIb" },
                    { 25, 1, "Cobalt is a chemical element with the symbol Co and atomic number 27. As with nickel, cobalt is found in the Earth's crust only in a chemically combined form, save for small deposits found in alloys of natural meteoric iron. The free element, produced by reductive smelting, is a hard, lustrous, silver-gray metal.", "Cobalt", "cobalt" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories_new");

            migrationBuilder.DropTable(
                name: "chatMessages");

            migrationBuilder.DropTable(
                name: "resourses");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
