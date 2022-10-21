using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryService.Models.Db;

public class DbWordsDescriptions
{
  public const string TableName = "WordsDescription";

  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Content { get; set; }

  public DbWord Word { get; set; }

  public DbWordsDescriptions()
  {
    Word = new DbWord();
  }
}

public class WordsDescriptionsConfiguration : IEntityTypeConfiguration<DbWordsDescriptions>
{
  public void Configure(EntityTypeBuilder<DbWordsDescriptions> builder)
  {
    builder
      .ToTable(DbWordsDescriptions.TableName);

    builder.HasKey(wd => wd.Id);

    builder
      .Property(wd => wd.Name)
      .IsRequired();

    builder
      .Property(wd => wd.Content)
      .IsRequired();

    builder
      .HasOne(wd => wd.Word)
      .WithMany(w => w.WordsDescriptions);
  }
}
