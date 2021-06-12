using AutoMapper;
using Dictionary.Database.Models;
using Dictionary.Services.Models.Word;
using Dictionary.Web.ViewModels.Word;
using Dictionary.WebUi.ViewModels.Word;

namespace Dictionary.Web.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ViewModels
            CreateMap<WordCreateVm, WordCreateServiceModel>();
            CreateMap<WordUpdateVm, WordUpdateServiceModel>();

            // ServiceModels
            CreateMap<WordCreateServiceModel, WordDto>();
            CreateMap<WordUpdateServiceModel, WordDto>();
            CreateMap<WordListServiceModel, WordListVm>();

            // DTOs
            CreateMap<WordDto, WordListServiceModel>()
                .ForMember(x => x.Created, o => o.MapFrom(y => y.Created.ToString("yy")));
        }
    }
}