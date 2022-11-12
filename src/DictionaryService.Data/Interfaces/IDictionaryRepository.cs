using DictionaryService.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryService.Data.Interfaces;

public interface IDictionaryRepository
{
  Task<Guid?> CreateAsync(DbDictionary dbDictionary);
}
