using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    brand_description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("brand_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    category_name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("category_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: true),
                    address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    reward_points = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("customer_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    manager_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_pkey", x => x.id);
                    table.ForeignKey(
                        name: "employee_manager_id_fkey",
                        column: x => x.manager_id,
                        principalTable: "employee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "room_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    room_type_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    base_price = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("room_type_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("status_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    serial_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    sell_price = table.Column<decimal>(type: "money", nullable: true),
                    suggested_rental_price = table.Column<decimal>(type: "money", nullable: true),
                    brand_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("item_pkey", x => x.id);
                    table.ForeignKey(
                        name: "item_brand_id_fkey",
                        column: x => x.brand_id,
                        principalTable: "brand",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchase",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(type: "integer", nullable: true),
                    employee_id = table.Column<int>(type: "integer", nullable: true),
                    purchase_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("purchase_pkey", x => x.id);
                    table.ForeignKey(
                        name: "purchase_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "purchase_employee_id_fkey",
                        column: x => x.employee_id,
                        principalTable: "employee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "rental",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rental_date = table.Column<DateOnly>(type: "date", nullable: true),
                    customer_id = table.Column<int>(type: "integer", nullable: true),
                    employee_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rental_pkey", x => x.id);
                    table.ForeignKey(
                        name: "rental_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "rental_employee_id_fkey",
                        column: x => x.employee_id,
                        principalTable: "employee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    room_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    max_capacity = table.Column<int>(type: "integer", nullable: true),
                    room_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("room_pkey", x => x.id);
                    table.ForeignKey(
                        name: "room_room_type_id_fkey",
                        column: x => x.room_type_id,
                        principalTable: "room_type",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "item_category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_id = table.Column<int>(type: "integer", nullable: true),
                    category_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("item_category_pkey", x => x.id);
                    table.ForeignKey(
                        name: "item_category_category_id_fkey",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "item_category_item_id_fkey",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "item_image",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_id = table.Column<int>(type: "integer", nullable: true),
                    filepath = table.Column<string>(type: "text", nullable: true),
                    is_primary = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("item_image_pkey", x => x.id);
                    table.ForeignKey(
                        name: "item_image_item_id_fkey",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "item_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_id = table.Column<int>(type: "integer", nullable: true),
                    status_id = table.Column<int>(type: "integer", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: true),
                    is_rentable = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("item_status_pkey", x => x.id);
                    table.ForeignKey(
                        name: "item_status_item_id_fkey",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "item_status_status_id_fkey",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_id = table.Column<int>(type: "integer", nullable: true),
                    customer_id = table.Column<int>(type: "integer", nullable: true),
                    review_date = table.Column<DateOnly>(type: "date", nullable: true),
                    review_text = table.Column<string>(type: "text", nullable: true),
                    rating = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("review_pkey", x => x.id);
                    table.ForeignKey(
                        name: "review_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "review_item_id_fkey",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchase_item",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    purchase_id = table.Column<int>(type: "integer", nullable: true),
                    item_id = table.Column<int>(type: "integer", nullable: true),
                    final_price = table.Column<decimal>(type: "money", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("purchase_item_pkey", x => x.id);
                    table.ForeignKey(
                        name: "purchase_item_item_id_fkey",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "purchase_item_purchase_id_fkey",
                        column: x => x.purchase_id,
                        principalTable: "purchase",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "item_rental",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rental_id = table.Column<int>(type: "integer", nullable: true),
                    item_id = table.Column<int>(type: "integer", nullable: true),
                    final_rental_price = table.Column<decimal>(type: "money", nullable: true),
                    out_condition = table.Column<string>(type: "text", nullable: true),
                    return_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("item_rental_pkey", x => x.id);
                    table.ForeignKey(
                        name: "item_rental_item_id_fkey",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "item_rental_rental_id_fkey",
                        column: x => x.rental_id,
                        principalTable: "rental",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "room_rental",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rental_id = table.Column<int>(type: "integer", nullable: true),
                    room_id = table.Column<int>(type: "integer", nullable: true),
                    actual_price = table.Column<decimal>(type: "money", nullable: true),
                    start_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    end_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("room_rental_pkey", x => x.id);
                    table.ForeignKey(
                        name: "room_rental_rental_id_fkey",
                        column: x => x.rental_id,
                        principalTable: "rental",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "room_rental_room_id_fkey",
                        column: x => x.room_id,
                        principalTable: "room",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_manager_id",
                table: "employee",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_brand_id",
                table: "item",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_category_category_id",
                table: "item_category",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_category_item_id",
                table: "item_category",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_image_item_id",
                table: "item_image",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_rental_item_id",
                table: "item_rental",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_rental_rental_id",
                table: "item_rental",
                column: "rental_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_status_item_id",
                table: "item_status",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_item_status_status_id",
                table: "item_status",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_customer_id",
                table: "purchase",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_employee_id",
                table: "purchase",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_item_item_id",
                table: "purchase_item",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_item_purchase_id",
                table: "purchase_item",
                column: "purchase_id");

            migrationBuilder.CreateIndex(
                name: "IX_rental_customer_id",
                table: "rental",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_rental_employee_id",
                table: "rental",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_customer_id",
                table: "review",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_item_id",
                table: "review",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_room_type_id",
                table: "room",
                column: "room_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_rental_rental_id",
                table: "room_rental",
                column: "rental_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_rental_room_id",
                table: "room_rental",
                column: "room_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "item_category");

            migrationBuilder.DropTable(
                name: "item_image");

            migrationBuilder.DropTable(
                name: "item_rental");

            migrationBuilder.DropTable(
                name: "item_status");

            migrationBuilder.DropTable(
                name: "purchase_item");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "room_rental");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "purchase");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "rental");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "room_type");
        }
    }
}
