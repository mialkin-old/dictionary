using AutoMapper;
using Dictionary.Database.Models;
using Dictionary.Services.Models.Word;
using Dictionary.WebApi.ViewModels.Word;

namespace Dictionary.WebApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ViewModels
            CreateMap<WordCreateViewModel, WordCreateServiceModel>();

            // ServiceModels
            CreateMap<WordCreateServiceModel, WordDto>();
            CreateMap<WordListServiceModel, WordListViewModel>();

            // Dtos
            CreateMap<WordDto, WordListServiceModel>();
        }
    }
}
