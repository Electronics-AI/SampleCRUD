using AutoMapper;
using Task5_CRUD.Domain;
using Task5_CRUD.Models.DrillBlockPointSet;

namespace Task5_CRUD.Profiles;

public class DrillBlockPointSetProfile : Profile
{   
    public DrillBlockPointSetProfile()
    {
        CreateMap<DrillBlockPointSet, GetDrillBlockPointSetResponseDto>();
        CreateMap<AddDrillBlockPointSetRequestDto, DrillBlockPointSet>();
        CreateMap<UpdateDrillBlockPointSetRequestDto, DrillBlockPointSet>();
    }
}

