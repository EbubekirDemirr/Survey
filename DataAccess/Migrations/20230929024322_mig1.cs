using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyChoices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyQuestionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyChoices_SurveyQuestions_SurveyQuestionId",
                        column: x => x.SurveyQuestionId,
                        principalTable: "SurveyQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSurveyQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPollster = table.Column<bool>(type: "bit", nullable: false),
                    SurveyChoiceId = table.Column<long>(type: "bigint", nullable: true),
                    SurveyQuestionId = table.Column<long>(type: "bigint", nullable: false),
                    SurveyId = table.Column<long>(type: "bigint", nullable: true),
                    AnswerUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSurveyQuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSurveyQuestionAnswers_AspNetUsers_AnswerUserId",
                        column: x => x.AnswerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSurveyQuestionAnswers_SurveyChoices_SurveyChoiceId",
                        column: x => x.SurveyChoiceId,
                        principalTable: "SurveyChoices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSurveyQuestionAnswers_SurveyQuestions_SurveyQuestionId",
                        column: x => x.SurveyQuestionId,
                        principalTable: "SurveyQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSurveyQuestionAnswers_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreatedDate", "TokenExpires", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[] { 1L, 0, "d9488a0f-07aa-416b-9edf-e9e75126b9f8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "super_admin@survey.com.tr", true, "Super", false, "Admin", false, null, null, "SUPERADMIN2023", null, null, false, null, null, null, null, false, null, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "SurveyName", "UpdatedDate", "UserId" },
                values: new object[] { 1L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3915), false, "Hazır Anket", null, 1L });

            migrationBuilder.InsertData(
                table: "SurveyQuestions",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "QuestionName", "SurveyId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3830), false, "En sevdiği yemek?", 1L, null },
                    { 2L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3841), false, "En sevdiği müzik türü?", 1L, null },
                    { 3L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3843), false, "Zamanını nasıl geçirir?", 1L, null },
                    { 4L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3844), false, "Onu en çok ne sevindirir?", 1L, null }
                });

            migrationBuilder.InsertData(
                table: "SurveyChoices",
                columns: new[] { "Id", "ChoiceName", "CreatedDate", "IsDeleted", "SurveyQuestionId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, "Patates Kızartması", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3863), false, 1L, null },
                    { 2L, "Burger", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3865), false, 1L, null },
                    { 3L, "Döner", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3866), false, 1L, null },
                    { 4L, "Kuru Fasulye", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3867), false, 1L, null },
                    { 5L, "Makarna", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3868), false, 1L, null },
                    { 6L, "Pop", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3869), false, 2L, null },
                    { 7L, "Rap", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3870), false, 2L, null },
                    { 8L, "Rock", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3871), false, 2L, null },
                    { 9L, "Türk Halk Müziği", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3872), false, 2L, null },
                    { 10L, "Arabesk", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3873), false, 2L, null },
                    { 11L, "Uyuyarak", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3874), false, 3L, null },
                    { 12L, "Bilgisayar başında", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3876), false, 3L, null },
                    { 13L, "Yürüyüş yaparak", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3877), false, 3L, null },
                    { 14L, "Kitap okuyarak", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3878), false, 3L, null },
                    { 15L, "Arkadaşlarıyla buluşarak", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3879), false, 3L, null },
                    { 16L, "Kayıp parayı bulmak", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3880), false, 4L, null },
                    { 17L, "Tuttuğu takımın galibiyeti", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3881), false, 4L, null },
                    { 18L, "Süpriz hediye almak", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3882), false, 4L, null },
                    { 19L, "Alışveriş mağazasındaki indirimler", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3883), false, 4L, null },
                    { 20L, "Çekilişle telefon kazanmak", new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3884), false, 4L, null }
                });

            migrationBuilder.InsertData(
                table: "UserSurveyQuestionAnswers",
                columns: new[] { "Id", "AnswerUserId", "CreatedDate", "IsDeleted", "IsPollster", "SurveyChoiceId", "SurveyId", "SurveyQuestionId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3935), false, false, 1L, 1L, 1L, null },
                    { 2L, 1L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3937), false, false, 8L, 1L, 2L, null },
                    { 3L, 1L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3939), false, false, 12L, 1L, 3L, null },
                    { 4L, 1L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3940), false, false, 16L, 1L, 4L, null },
                    { 5L, 1L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3952), false, true, 2L, 1L, 1L, null },
                    { 6L, 1L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3954), false, true, 9L, 1L, 2L, null },
                    { 7L, 1L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3955), false, true, 12L, 1L, 3L, null },
                    { 8L, 1L, new DateTime(2023, 9, 29, 5, 43, 22, 659, DateTimeKind.Local).AddTicks(3957), false, true, 16L, 1L, 4L, null }
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
                name: "IX_SurveyChoices_SurveyQuestionId",
                table: "SurveyChoices",
                column: "SurveyQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestions_SurveyId",
                table: "SurveyQuestions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_UserId",
                table: "Surveys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyQuestionAnswers_AnswerUserId",
                table: "UserSurveyQuestionAnswers",
                column: "AnswerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyQuestionAnswers_SurveyChoiceId",
                table: "UserSurveyQuestionAnswers",
                column: "SurveyChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyQuestionAnswers_SurveyId",
                table: "UserSurveyQuestionAnswers",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyQuestionAnswers_SurveyQuestionId",
                table: "UserSurveyQuestionAnswers",
                column: "SurveyQuestionId");
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
                name: "UserSurveyQuestionAnswers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SurveyChoices");

            migrationBuilder.DropTable(
                name: "SurveyQuestions");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
