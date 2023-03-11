namespace Task5_CRUD.Domain;

public class Hole : Entity<int>
{
    public int DrillBlockId { get; set; }

    public string Name { get; set; }

    public int DepthMeters { get; set; }
}

