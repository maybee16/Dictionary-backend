using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DictionaryService.Models.Db;

public class DbWord
{
  public const string TableName = "Word";

  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Translation { get; set; }

  public DbTheme Theme { get; set; }
  public ICollection<DbWordsDescriptions> WordsDescriptions { get; set; }

  public DbWord()
  {
    Theme = new DbTheme();
    WordsDescriptions = new HashSet<DbWordsDescriptions>();
  }
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

    builder
      .HasMany(w => w.WordsDescriptions)
      .WithOne(wd => wd.Word);
  }
}
