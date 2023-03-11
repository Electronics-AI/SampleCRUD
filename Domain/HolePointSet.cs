namespace Task5_CRUD.Domain;

public class HolePointSet : Entity<int>
{
    public int HoleId { get; set; }

    public List<MapPoint> Sequence { get; set; }
}

