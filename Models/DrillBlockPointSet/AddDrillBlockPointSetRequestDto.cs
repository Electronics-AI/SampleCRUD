using Task5_CRUD.Domain;

namespace Task5_CRUD.Models.DrillBlockPointSet;

public class AddDrillBlockPointSetRequestDto
{
    public int DrillBlockId { get; set; }

    public List<MapPoint> Sequence { get; set; }
}

