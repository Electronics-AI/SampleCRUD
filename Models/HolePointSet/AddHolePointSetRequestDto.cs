using Task5_CRUD.Domain;

namespace Task5_CRUD.Models.HolePointSet;

public class AddHolePointSetRequestDto
{   
    public int HoleId { get; set; }

    public List<MapPoint> Sequence { get; set; }
}
