﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MIS.Backend.Mappers.Interfaces;

namespace MIS.Backend.Mappers;

public abstract class Mapper<TModel, TDto> : IMapper<TModel, TDto>
{
    protected IMapper _mapper;

    public TModel Map(TDto dto)
    {
        return _mapper!.Map<TModel>(dto);
    }

    public IList<TModel> Map(IList<TDto> dtos)
    {
        return dtos.Select(Map).ToList();
    }

    public TDto Map(TModel model)
    {
        return _mapper!.Map<TDto>(model);
    }

    public IList<TDto> Map(IList<TModel> models)
    {
        return models.Select(Map).ToList();
    }
}