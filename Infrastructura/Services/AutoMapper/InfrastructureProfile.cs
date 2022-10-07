using AutoMapper;
using Domain.Dtos;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile ()
    {
        CreateMap<Challange, GEtChallangeDto>();
        CreateMap<Group, GEtGroupDto>();
        CreateMap<Location, AddLocationDto>();
    }
}