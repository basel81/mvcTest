using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mvcTest.Migrations
{
    public partial class addingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "yourdir");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                schema: "yourdir",
                columns: table => new
                {
                    categorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CategoryEName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    categoryPhoto = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.categorId);
                });

            migrationBuilder.CreateTable(
                name: "client",
                schema: "yourdir",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    realName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    registerationDate = table.Column<DateTime>(type: "date", nullable: false),
                    city = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    country = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    phone = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    MACaddress = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    password = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    address = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "datacollector",
                schema: "yourdir",
                columns: table => new
                {
                    DCID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    userName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    isActive = table.Column<int>(nullable: false),
                    email = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    mobile = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    zone = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    MACAddress = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    addinfDate = table.Column<DateTime>(type: "date", nullable: false),
                    phone = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datacollector", x => x.DCID);
                });

            migrationBuilder.CreateTable(
                name: "referencepoint",
                schema: "yourdir",
                columns: table => new
                {
                    referencePointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    location = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    eName = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_referencepoint", x => x.referencePointId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "itemstosale",
                schema: "yourdir",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    AName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    EName = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemstosale", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_itemstosale_category",
                        column: x => x.CategoryId,
                        principalSchema: "yourdir",
                        principalTable: "category",
                        principalColumn: "categorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shoptype",
                schema: "yourdir",
                columns: table => new
                {
                    ShopTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    EName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    aliases = table.Column<string>(unicode: false, nullable: false),
                    ealiases = table.Column<string>(unicode: false, nullable: false),
                    photo = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    categoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoptype", x => x.ShopTypeId);
                    table.ForeignKey(
                        name: "FK_shoptype_category",
                        column: x => x.categoryId,
                        principalSchema: "yourdir",
                        principalTable: "category",
                        principalColumn: "categorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    bannerId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    startDate = table.Column<DateTime>(type: "date", nullable: false),
                    duration = table.Column<int>(nullable: false),
                    cost = table.Column<int>(nullable: false),
                    photo = table.Column<string>(maxLength: 150, nullable: false),
                    link = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.bannerId);
                    table.ForeignKey(
                        name: "FK_Banner_client",
                        column: x => x.ClientId,
                        principalSchema: "yourdir",
                        principalTable: "client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientPayment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: true),
                    amount = table.Column<int>(nullable: false),
                    Reciept = table.Column<string>(maxLength: 50, nullable: true),
                    paymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    reason = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPayment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_ClientPayment_client",
                        column: x => x.ClientId,
                        principalSchema: "yourdir",
                        principalTable: "client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "joboffer",
                schema: "yourdir",
                columns: table => new
                {
                    jobOfferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientId = table.Column<int>(nullable: false),
                    offerText = table.Column<string>(unicode: false, nullable: false),
                    offerTitle = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    offerDate = table.Column<DateTime>(type: "date", nullable: false),
                    days = table.Column<int>(nullable: false),
                    cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_joboffer", x => x.jobOfferId);
                    table.ForeignKey(
                        name: "FK_joboffer_client",
                        column: x => x.clientId,
                        principalSchema: "yourdir",
                        principalTable: "client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "jobrequest",
                schema: "yourdir",
                columns: table => new
                {
                    JobRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientId = table.Column<int>(nullable: false),
                    requestTitle = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    requestText = table.Column<string>(unicode: false, nullable: false),
                    requestDate = table.Column<DateTime>(type: "date", nullable: false),
                    days = table.Column<int>(nullable: false),
                    cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobrequest", x => x.JobRequestId);
                    table.ForeignKey(
                        name: "FK_jobrequest_client",
                        column: x => x.clientId,
                        principalSchema: "yourdir",
                        principalTable: "client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "logs",
                schema: "yourdir",
                columns: table => new
                {
                    LogsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    LogDate = table.Column<DateTime>(type: "date", nullable: false),
                    MacAddress = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    location = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.LogsId);
                    table.ForeignKey(
                        name: "FK_logs_client",
                        column: x => x.ClientId,
                        principalSchema: "yourdir",
                        principalTable: "client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "saleoffer",
                schema: "yourdir",
                columns: table => new
                {
                    SOId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    OfferText = table.Column<string>(unicode: false, nullable: false),
                    OfferTitle = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    photo = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    duration = table.Column<int>(nullable: false),
                    cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleoffer", x => x.SOId);
                    table.ForeignKey(
                        name: "FK_saleoffer_client",
                        column: x => x.ClientId,
                        principalSchema: "yourdir",
                        principalTable: "client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dcpayment",
                schema: "yourdir",
                columns: table => new
                {
                    DCPaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    DCID = table.Column<int>(nullable: false),
                    recNum = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dcpayment", x => x.DCPaymentID);
                    table.ForeignKey(
                        name: "FK_dcpayment_datacollector",
                        column: x => x.DCID,
                        principalSchema: "yourdir",
                        principalTable: "datacollector",
                        principalColumn: "DCID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "offer",
                schema: "yourdir",
                columns: table => new
                {
                    OfferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    offerTitle = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    offerText = table.Column<string>(unicode: false, nullable: false),
                    offerDate = table.Column<DateTime>(type: "date", nullable: false),
                    activationDate = table.Column<DateTime>(type: "date", nullable: false),
                    shopId = table.Column<int>(nullable: false),
                    photo = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    duration = table.Column<int>(nullable: false),
                    cost = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offer", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_offer_client",
                        column: x => x.ClientId,
                        principalSchema: "yourdir",
                        principalTable: "client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_offer_shoptype",
                        column: x => x.shopId,
                        principalSchema: "yourdir",
                        principalTable: "shoptype",
                        principalColumn: "ShopTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shop",
                schema: "yourdir",
                columns: table => new
                {
                    ShopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopTypeId = table.Column<int>(nullable: false),
                    ShopName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    EShopName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    city = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Country = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Location = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    properties = table.Column<string>(unicode: false, nullable: false),
                    phone = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    mobile = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    facebook = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    twiter = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    website = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    registerationDate = table.Column<DateTime>(type: "date", nullable: false),
                    ActivationDate = table.Column<DateTime>(type: "date", nullable: false),
                    referencePointId = table.Column<int>(nullable: false),
                    notes = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop", x => x.ShopId);
                    table.ForeignKey(
                        name: "FK_shop_referencepoint",
                        column: x => x.referencePointId,
                        principalSchema: "yourdir",
                        principalTable: "referencepoint",
                        principalColumn: "referencePointId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shop_shoptype",
                        column: x => x.ShopTypeId,
                        principalSchema: "yourdir",
                        principalTable: "shoptype",
                        principalColumn: "ShopTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "activationtable",
                schema: "yourdir",
                columns: table => new
                {
                    ActivationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivationDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    cost = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activationtable", x => x.ActivationId);
                    table.ForeignKey(
                        name: "FK_activationtable_shop",
                        column: x => x.ShopId,
                        principalSchema: "yourdir",
                        principalTable: "shop",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "datacollectorshop",
                schema: "yourdir",
                columns: table => new
                {
                    DCSId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DCId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    MACAddress = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    location = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    addingDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_datacollectorshop", x => x.DCSId);
                    table.ForeignKey(
                        name: "FK_datacollectorshop_datacollector",
                        column: x => x.DCId,
                        principalSchema: "yourdir",
                        principalTable: "datacollector",
                        principalColumn: "DCID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_datacollectorshop_shop",
                        column: x => x.ShopId,
                        principalSchema: "yourdir",
                        principalTable: "shop",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shopitem",
                schema: "yourdir",
                columns: table => new
                {
                    ShopItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopitem", x => x.ShopItemId);
                    table.ForeignKey(
                        name: "FK_shopitem_itemstosale",
                        column: x => x.itemId,
                        principalSchema: "yourdir",
                        principalTable: "itemstosale",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shopitem_shop",
                        column: x => x.ShopId,
                        principalSchema: "yourdir",
                        principalTable: "shop",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Banner_ClientId",
                table: "Banner",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPayment_ClientId",
                table: "ClientPayment",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_activationtable_ShopId",
                schema: "yourdir",
                table: "activationtable",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_datacollectorshop_DCId",
                schema: "yourdir",
                table: "datacollectorshop",
                column: "DCId");

            migrationBuilder.CreateIndex(
                name: "IX_datacollectorshop_ShopId",
                schema: "yourdir",
                table: "datacollectorshop",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_dcpayment_DCID",
                schema: "yourdir",
                table: "dcpayment",
                column: "DCID");

            migrationBuilder.CreateIndex(
                name: "CategoryId",
                schema: "yourdir",
                table: "itemstosale",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "clientId",
                schema: "yourdir",
                table: "joboffer",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "clientId",
                schema: "yourdir",
                table: "jobrequest",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "ClientId",
                schema: "yourdir",
                table: "logs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_offer_ClientId",
                schema: "yourdir",
                table: "offer",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "shopId",
                schema: "yourdir",
                table: "offer",
                column: "shopId");

            migrationBuilder.CreateIndex(
                name: "UserId",
                schema: "yourdir",
                table: "saleoffer",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "referencePointId",
                schema: "yourdir",
                table: "shop",
                column: "referencePointId");

            migrationBuilder.CreateIndex(
                name: "ShopTypeId",
                schema: "yourdir",
                table: "shop",
                column: "ShopTypeId");

            migrationBuilder.CreateIndex(
                name: "itemId",
                schema: "yourdir",
                table: "shopitem",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "ShopItemID",
                schema: "yourdir",
                table: "shopitem",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "categoryId",
                schema: "yourdir",
                table: "shoptype",
                column: "categoryId");
        }

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
                name: "Banner");

            migrationBuilder.DropTable(
                name: "ClientPayment");

            migrationBuilder.DropTable(
                name: "activationtable",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "datacollectorshop",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "dcpayment",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "joboffer",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "jobrequest",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "logs",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "offer",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "saleoffer",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "shopitem",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "datacollector",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "client",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "itemstosale",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "shop",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "referencepoint",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "shoptype",
                schema: "yourdir");

            migrationBuilder.DropTable(
                name: "category",
                schema: "yourdir");
        }
    }
}
