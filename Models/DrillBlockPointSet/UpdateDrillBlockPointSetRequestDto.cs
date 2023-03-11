using Task5_CRUD.Domain;

namespace Task5_CRUD.Models.DrillBlockPointSet;

public class UpdateDrillBlockPointSetRequestDto
{
    public int DrillBlockId { get; set; }

    public List<MapPoint> Sequence { get; set; }
}
