using AutoMapper;
using Task5_CRUD.Domain;
using Task5_CRUD.Models.HolePointSet;

namespace Task5_CRUD.Profiles;

public class HolePointSetProfile : Profile
{   
    public HolePointSetProfile()
    {
        CreateMap<HolePointSet, GetHolePointSetResponseDto>();
        CreateMap<AddHolePointSetRequestDto, HolePointSet>();
        CreateMap<UpdateHolePointSetRequestDto, HolePointSet>();
    }
}