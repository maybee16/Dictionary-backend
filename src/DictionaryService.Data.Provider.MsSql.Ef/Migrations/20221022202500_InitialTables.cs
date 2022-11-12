using DictionaryService.Models.Db;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DictionaryService.Data.Provider.MsSql.Ef.Migrations;

[DbContext(typeof(DictionaryServiceDbContext))]
[Migration("20221022202500_InitialTables")]
public class InitialTables : Migration
{
  protected override void Up(MigrationBuilder builder)
  {
    builder.CreateTable(
      name: DbDictionary.TableName,
      columns: table => new
      {
        Id = table.Column<Guid>(nullable: false),
        Name = table.Column<string>(nullable: false),
        Description = table.Column<string>(nullable: true),
        IsActive = table.Column<bool>(nullable: false)
      },
      constraints: table =>
      {
        table.PrimaryKey($"PK_{DbDictionary.TableName}", x => x.Id);
      });

    builder.CreateTable(
      name: DbTheme.TableName,
      columns: table => new
      {
        Id = table.Column<Guid>(nullable: false),
        Name = table.Column<string>(nullable: false),
        Description = table.Column<string>(nullable: true),
        DictionaryId = table.Column<Guid>(nullable: false),
        IsActive = table.Column<bool>(nullable: false)
      },
      constraints: table =>
      {
        table.PrimaryKey($"PK_{DbTheme.TableName}", x => x.Id);
      });

    builder.CreateTable(
      name: DbWord.TableName,
      columns: table => new
      {
        Id = table.Column<Guid>(nullable: false),
        Name = table.Column<string>(nullable: false),
        Translation = table.Column<string>(nullable: false),
        ThemeId = table.Column<Guid>(nullable: false),
        IsActive = table.Column<bool>(nullable: false)
      },
      constraints: table =>
      {
        table.PrimaryKey($"PK_{DbWord.TableName}", x => x.Id);
      });
  }
}
