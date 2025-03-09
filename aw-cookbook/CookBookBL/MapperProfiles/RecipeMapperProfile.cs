using AutoMapper;
using CookBook.Common.Models.Recipe;
using CookBook.DAL;

namespace CookBook.BL.MapperProfiles;

public class RecipeMapperProfile : Profile
{
    public RecipeMapperProfile()
    {
        CreateMap<RecipeEntity, RecipeListModel>();
        CreateMap<RecipeEntity, RecipeDetailModel>();

        CreateMap<RecipeDetailModel, RecipeEntity>();
       
    }
}