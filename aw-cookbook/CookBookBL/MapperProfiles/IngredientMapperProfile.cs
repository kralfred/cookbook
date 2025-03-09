using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBook;
using CookBook.Common.Models.Ingredient;
using CookBook.DAL;

namespace CookBookBL.MapperProfiles;

public class IngredientMapperProfile : Profile
{
    public IngredientMapperProfile()
    {
        CreateMap<IngredientEntity, IngredientListModel>();
        CreateMap<IngredientEntity, IngredientDetailModel>();

        CreateMap<IngredientDetailModel, IngredientEntity>();
    }
}
