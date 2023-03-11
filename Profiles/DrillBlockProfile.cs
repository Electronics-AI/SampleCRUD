using AutoMapper;
using Task5_CRUD.Domain;
using Task5_CRUD.Models.DrillBlock;

namespace Task5_CRUD.Profiles;

public class DrillBlockProfile : Profile
{   
    public DrillBlockProfile()
    {
        CreateMap<DrillBlock, GetDrillBlockResponseDto>();
        CreateMap<AddDrillBlockRequestDto, DrillBlock>();
        CreateMap<UpdateDrillBlockRequestDto, DrillBlock>();
    }
}
