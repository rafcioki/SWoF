using AutoMapper;
using BusinessLogic.DomainObjects;
using WebApi.ViewModels;

namespace WebApi.Mapping
{
    public class ViewModelsMappingProfile : Profile
    {
        public ViewModelsMappingProfile()
        {
            CreateMap<Engineer, EngineerViewModel>();
            CreateMap<RotaEntry, RotaEntryViewModel>();
        }
    }
}
