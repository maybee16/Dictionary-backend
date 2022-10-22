using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryService.Models.Db;

public class DbWordsDescription
{
  public const string TableName = "WordsDescription";

  public Guid Id { get; set; }
  public Guid WordId { get; set; }
  public string Name { get; set; }
  public string Content { get; set; }

  public DbWord Word { get; set; }

  public DbWordsDescription()
  {
    Word = new DbWord();
  }
}

public class WordsDescriptionsConfiguration : IEntityTypeConfiguration<DbWordsDescription>
{
  public void Configure(EntityTypeBuilder<DbWordsDescription> builder)
  {
    builder
      .ToTable(DbWordsDescription.TableName);

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
