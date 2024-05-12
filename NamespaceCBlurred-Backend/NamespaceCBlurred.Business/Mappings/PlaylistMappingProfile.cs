using AutoMapper;
using NamespaceCBlurred.Business.Models;
using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Business.Mappings
{
    public class PlaylistMappingProfile : Profile
    {
        public PlaylistMappingProfile()
        {
            CreateMap<Playlist, PlaylistForAddUpdateModel>().ReverseMap();
        }
    }
}
