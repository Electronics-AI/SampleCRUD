namespace Task5_CRUD.Domain;

public class DrillBlock : Entity<int>
{
    public string Name { get; set; }

    public DateTime UpdateDate { get; set; }
}

