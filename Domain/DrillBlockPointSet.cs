namespace Task5_CRUD.Domain;

public class DrillBlockPointSet : Entity<int>
{
    public int DrillBlockId { get; set; }

    public List<MapPoint> Sequence { get; set; }
}