using Task5_CRUD.Domain;

namespace Task5_CRUD.Models.HolePointSet;

public class GetHolePointSetResponseDto
{
    public int Id { get; set; }
       
    public int HoleId { get; set; }

    public List<MapPoint> Sequence { get; set; }
}