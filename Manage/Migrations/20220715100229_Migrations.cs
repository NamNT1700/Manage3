using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Manage.API.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hu_allwance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_allwance", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_bank",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_bank", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_contract",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    number_of_month = table.Column<int>(type: "int", nullable: true),
                    money = table.Column<double>(type: "float", nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_contract", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_hospital",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_hospital", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_nation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_nation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_org_title",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    title_id = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_org_title", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_organization",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    order_number = table.Column<int>(type: "int", nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_organization", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_title",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: true),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_title", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hu_welface",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_welface", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "other_list_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_other_list_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Se_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Token = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ActiveFlg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Se_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hu_bank_branch",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    bank_id = table.Column<int>(type: "int", nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_bank_branch", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_bank_branch_hu_bank",
                        column: x => x.bank_id,
                        principalTable: "hu_bank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_Contract_allowance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    contract_id = table.Column<int>(type: "int", nullable: true),
                    allwance_id = table.Column<int>(type: "int", nullable: true),
                    money = table.Column<double>(type: "float", nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_Contract_allowance", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_Contract_allowance_hu_allwance",
                        column: x => x.allwance_id,
                        principalTable: "hu_allwance",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hu_Contract_allowance_hu_contract",
                        column: x => x.contract_id,
                        principalTable: "hu_contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_type_of_contract",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    contract_id = table.Column<int>(type: "int", nullable: true),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    number_of_month = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_type_of_contract", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_type_of_contract_hu_contract",
                        column: x => x.contract_id,
                        principalTable: "hu_contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_employee_cv",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    id_card = table.Column<int>(type: "int", nullable: true),
                    sex = table.Column<bool>(type: "bit", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "datetime", nullable: true),
                    Place_of_birth = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ethnic = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    reiligion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    temporary_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    permanent_address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    hospital_id = table.Column<int>(type: "int", nullable: true),
                    bank_number = table.Column<int>(type: "int", nullable: true),
                    health_condition = table.Column<bool>(type: "bit", nullable: true),
                    clothes_size = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_employee_cv", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_employee_cv_hu_hospital",
                        column: x => x.hospital_id,
                        principalTable: "hu_hospital",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_province",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    nation_id = table.Column<int>(type: "int", nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_province", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_province_hu_nation",
                        column: x => x.nation_id,
                        principalTable: "hu_nation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    employee_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    org_id = table.Column<int>(type: "int", nullable: true),
                    join_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    work_status = table.Column<bool>(type: "bit", nullable: true),
                    contract_id = table.Column<int>(type: "int", nullable: true),
                    title_id = table.Column<int>(type: "int", nullable: true),
                    working_id = table.Column<int>(type: "int", nullable: true),
                    direct_manager = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    itime_id = table.Column<int>(type: "int", nullable: true),
                    last_working_id = table.Column<int>(type: "int", nullable: true),
                    last_working_day = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_employee_hu_contract",
                        column: x => x.contract_id,
                        principalTable: "hu_contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hu_employee_hu_org_title",
                        column: x => x.org_id,
                        principalTable: "hu_org_title",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hu_employee_hu_title",
                        column: x => x.title_id,
                        principalTable: "hu_title",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_contractual_benefits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    contract_id = table.Column<int>(type: "int", nullable: true),
                    welface_id = table.Column<int>(type: "int", nullable: true),
                    money = table.Column<double>(type: "float", nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_contractual_benefits", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_contractual_benefits_hu_contract",
                        column: x => x.contract_id,
                        principalTable: "hu_contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hu_contractual_benefits_hu_welface",
                        column: x => x.welface_id,
                        principalTable: "hu_welface",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "other_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    type_id = table.Column<int>(type: "int", nullable: true),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_other_list", x => x.id);
                    table.ForeignKey(
                        name: "FK_ID_OtherList",
                        column: x => x.id,
                        principalTable: "other_list_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_other_list_hu_title",
                        column: x => x.type_id,
                        principalTable: "hu_title",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_district",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    province_id = table.Column<int>(type: "int", nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_district", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_district_hu_province",
                        column: x => x.province_id,
                        principalTable: "hu_province",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_employee_education",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    fisrt_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    finsish_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_employee_education", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_employee_education_hu_employee",
                        column: x => x.employee_id,
                        principalTable: "hu_employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_family",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    relationship = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    province = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    district = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phonenumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_family", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_family_hu_employee",
                        column: x => x.employee_id,
                        principalTable: "hu_employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_salary_records",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    contrac_id = table.Column<int>(type: "int", nullable: true),
                    contract_allwance_id = table.Column<int>(type: "int", nullable: true),
                    contract_welface_id = table.Column<int>(type: "int", nullable: true),
                    money = table.Column<double>(type: "float", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_salary_records", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_salary_records_hu_contract",
                        column: x => x.contrac_id,
                        principalTable: "hu_contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hu_salary_records_hu_Contract_allowance",
                        column: x => x.contract_allwance_id,
                        principalTable: "hu_Contract_allowance",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hu_salary_records_hu_employee",
                        column: x => x.employee_id,
                        principalTable: "hu_employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hu_salary_records_hu_welface",
                        column: x => x.contract_welface_id,
                        principalTable: "hu_welface",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hu_ward",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    distric_id = table.Column<int>(type: "int", nullable: true),
                    activeflg = table.Column<bool>(type: "bit", nullable: true),
                    created_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_updated_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hu_ward", x => x.id);
                    table.ForeignKey(
                        name: "FK_hu_ward_hu_district",
                        column: x => x.distric_id,
                        principalTable: "hu_district",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_hu_bank_branch_bank_id",
                table: "hu_bank_branch",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_Contract_allowance_allwance_id",
                table: "hu_Contract_allowance",
                column: "allwance_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_Contract_allowance_contract_id",
                table: "hu_Contract_allowance",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_contractual_benefits_contract_id",
                table: "hu_contractual_benefits",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_contractual_benefits_welface_id",
                table: "hu_contractual_benefits",
                column: "welface_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_district_province_id",
                table: "hu_district",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_contract_id",
                table: "hu_employee",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_org_id",
                table: "hu_employee",
                column: "org_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_title_id",
                table: "hu_employee",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_cv_hospital_id",
                table: "hu_employee_cv",
                column: "hospital_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_employee_education_employee_id",
                table: "hu_employee_education",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_family_employee_id",
                table: "hu_family",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_province_nation_id",
                table: "hu_province",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_salary_records_contrac_id",
                table: "hu_salary_records",
                column: "contrac_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_salary_records_contract_allwance_id",
                table: "hu_salary_records",
                column: "contract_allwance_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_salary_records_contract_welface_id",
                table: "hu_salary_records",
                column: "contract_welface_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_salary_records_employee_id",
                table: "hu_salary_records",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_type_of_contract_contract_id",
                table: "hu_type_of_contract",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "IX_hu_ward_distric_id",
                table: "hu_ward",
                column: "distric_id");

            migrationBuilder.CreateIndex(
                name: "IX_other_list_type_id",
                table: "other_list",
                column: "type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hu_bank_branch");

            migrationBuilder.DropTable(
                name: "hu_contractual_benefits");

            migrationBuilder.DropTable(
                name: "hu_employee_cv");

            migrationBuilder.DropTable(
                name: "hu_employee_education");

            migrationBuilder.DropTable(
                name: "hu_family");

            migrationBuilder.DropTable(
                name: "hu_organization");

            migrationBuilder.DropTable(
                name: "hu_salary_records");

            migrationBuilder.DropTable(
                name: "hu_type_of_contract");

            migrationBuilder.DropTable(
                name: "hu_ward");

            migrationBuilder.DropTable(
                name: "other_list");

            migrationBuilder.DropTable(
                name: "Se_User");

            migrationBuilder.DropTable(
                name: "hu_bank");

            migrationBuilder.DropTable(
                name: "hu_hospital");

            migrationBuilder.DropTable(
                name: "hu_Contract_allowance");

            migrationBuilder.DropTable(
                name: "hu_employee");

            migrationBuilder.DropTable(
                name: "hu_welface");

            migrationBuilder.DropTable(
                name: "hu_district");

            migrationBuilder.DropTable(
                name: "other_list_type");

            migrationBuilder.DropTable(
                name: "hu_allwance");

            migrationBuilder.DropTable(
                name: "hu_contract");

            migrationBuilder.DropTable(
                name: "hu_org_title");

            migrationBuilder.DropTable(
                name: "hu_title");

            migrationBuilder.DropTable(
                name: "hu_province");

            migrationBuilder.DropTable(
                name: "hu_nation");
        }
    }
}
