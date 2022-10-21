using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryService.Models.Db;

public class DbTheme
{
  public const string TableName = "Theme";

  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public bool IsActive { get; set; }

  public DbDictionary Dictionary { get; set; }
  public ICollection<DbWord> Words { get; set; }

  public DbTheme()
  {
    Dictionary = new DbDictionary();
    Words = new HashSet<DbWord>();
  }
}

public class ThemeConfiguration : IEntityTypeConfiguration<DbTheme>
{
  public void Configure(EntityTypeBuilder<DbTheme> builder)
  {
    builder
      .ToTable(DbTheme.TableName);

    builder.HasKey(t => t.Id);

    builder
      .Property(t => t.Name)
      .IsRequired();

    builder
      .HasOne(t => t.Dictionary)
      .WithMany(d => d.Themes);

    builder
      .HasMany(t => t.Words)
      .WithOne(w => w.Theme);
  }
}
