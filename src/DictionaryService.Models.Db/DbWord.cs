using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryService.Models.Db;

public class DbWord
{
  public const string TableName = "Words";

  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Translation { get; set; }
  public Guid ThemeId { get; set; }
  public bool IsActive { get; set; }

  public DbTheme Theme { get; set; }
}

public class WordConfiguration : IEntityTypeConfiguration<DbWord>
{
  public void Configure(EntityTypeBuilder<DbWord> builder)
  {
    builder
      .ToTable(DbWord.TableName);

    builder.HasKey(w => w.Id);

    builder
      .Property(w => w.Name)
      .IsRequired();

    builder
      .Property(w => w.Translation)
      .IsRequired();

    builder
      .HasOne(w => w.Theme)
      .WithMany(t => t.Words);
  }
}
