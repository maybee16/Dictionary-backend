using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryService.Models.Db;

public class DbDictionary
{
  public const string TableName = "Dictionaries";

  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public bool IsActive { get; set; }

  public ICollection<DbTheme> Themes { get; set; }

  public DbDictionary()
  {
    Themes = new HashSet<DbTheme>();
  }
}

public class DictionaryConfiguration : IEntityTypeConfiguration<DbDictionary>
{
  public void Configure(EntityTypeBuilder<DbDictionary> builder)
  {
    builder
      .ToTable(DbDictionary.TableName);

    builder.HasKey(d => d.Id);

    builder
      .Property(d => d.Name)
      .IsRequired();

    builder
      .HasMany(d => d.Themes)
      .WithOne(t => t.Dictionary);
  }
}
