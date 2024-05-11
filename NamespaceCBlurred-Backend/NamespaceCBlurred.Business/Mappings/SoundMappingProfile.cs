using AutoMapper;
using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Business.Mappings
{
    public class SoundMappingProfile : Profile
    {
        public SoundMappingProfile() 
        {
            CreateMap<Sound, SoundForAddUpdateModel>().ReverseMap();
        }
    }
}
