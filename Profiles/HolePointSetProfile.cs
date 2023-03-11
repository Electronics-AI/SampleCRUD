using AutoMapper;
using Task5_CRUD.Domain;
using Task5_CRUD.Models.Hole;

namespace Task5_CRUD.Profiles;

public class HoleProfile : Profile
{   
    public HoleProfile()
    {
        CreateMap<Hole, GetHoleResponseDto>();
        CreateMap<AddHoleRequestDto, Hole>();
        CreateMap<UpdateHoleRequestDto, Hole>();
    }
}