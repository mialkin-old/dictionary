using AutoMapper;
using Dictionary.Database.Models;
using Dictionary.Services.Models.Word;
using Dictionary.WebUi.ViewModels.Word;

namespace Dictionary.WebUi.AutoMapper
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
