﻿using DictionaryService.Mappers.Db.Interfaces;
using DictionaryService.Models.Db;
using DictionaryService.Models.Dto.Requests.Theme;

namespace DictionaryService.Mappers.Db;

public class DbThemeMapper : IDbThemeMapper
{
  public DbTheme Map(CreateThemeRequest request)
  {
    return request is null
      ? null
      : new DbTheme
      {
        Id = Guid.NewGuid(),
        Name = request.Name,
        Description = request.Description,
        DictionaryId = request.DictionaryId,
        IsActive = true
      };
  }
}
