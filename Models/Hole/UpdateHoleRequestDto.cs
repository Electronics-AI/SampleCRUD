namespace Task5_CRUD.Models.Hole;

public class UpdateHoleRequestDto
{
    public int DrillBlockId { get; set; }

    public string Name { get; set; }

    public int DepthMeters { get; set; }
}