﻿using DictionaryService.Mappers.Db.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Dictionary;

namespace DictionaryService.Mappers.Db;

public class DbDictionaryMapper : IDbDictionaryMapper
{
  public DbDictionary Map(CreateDictionaryRequest request)
  {
    Guid dictionaryId = Guid.NewGuid();

    return request is null
      ? null
      : new DbDictionary
      {
        Id = dictionaryId,
        Name = request.Name,
        Description = request.Description,
        IsActive = true
      };
  }
}
