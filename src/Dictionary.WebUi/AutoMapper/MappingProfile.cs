using AutoMapper;
using Dictionary.Database.Models;
using Dictionary.Excel.Parsers.Word;
using Dictionary.Services.Models.Word;
using Dictionary.WebUi.ViewModels.Word;

namespace Dictionary.WebUi.AutoMapper
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
            CreateMap<WordImportModel, WordDto>();

            // Dtos
            CreateMap<WordDto, WordListServiceModel>()
                .ForMember(x => x.Created, o => o.MapFrom(y => y.Created.ToString("yy")));
        }
    }
}
