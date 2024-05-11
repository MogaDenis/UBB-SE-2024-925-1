using AutoMapper;
using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Business.Mappings
{
    public class SongMappingProfile : Profile
    {
        public SongMappingProfile()
        {
            CreateMap<Song, SongForAddUpdateModel>().ReverseMap();
        }
    }
}
