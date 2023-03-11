using Microsoft.EntityFrameworkCore;
using Task5_CRUD.Domain;

namespace Task5_CRUD.Infrastructure.DbContexts;

public class CrudContext : DbContext
{   
    public virtual DbSet<Hole> Holes { get; set; }

    public virtual DbSet<HolePointSet> HolePointSets { get; set; }

    public virtual DbSet<DrillBlock> DrillBlocks { get; set; }

    public virtual DbSet<DrillBlockPointSet> DrillBlockPointSets { get; set; }

    public CrudContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        configureDrillBlockEntity(modelBuilder);
        configureDrillBlockPointSetEntity(modelBuilder);

        configureHoleEntity(modelBuilder);
        configureHolePointSetEntity(modelBuilder);
    }

    private void configureHoleEntity(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<Hole>().ToTable("holes");

        modelBuilder.Entity<Hole>().Property(hole => hole.Id)
            .HasColumnName("hole_id")
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Hole>().Property(hole => hole.DrillBlockId)
            .HasColumnName("drill_block_id");

        modelBuilder.Entity<Hole>().Property(hole => hole.Name)
            .HasColumnName("name");
        
        modelBuilder.Entity<Hole>().Property(hole => hole.DepthMeters)
            .HasColumnName("depth_meters");
    }

    private void configureHolePointSetEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HolePointSet>().ToTable("hole_point_sets");

        modelBuilder.Entity<HolePointSet>().Property(hps => hps.Id)
            .HasColumnName("hole_point_set_id")
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<HolePointSet>().Property(hps => hps.HoleId)
            .HasColumnName("hole_id");
        
        modelBuilder.Entity<HolePointSet>().Property(hps => hps.Sequence)
            .HasColumnName("sequence")
            .HasPostgresArrayConversion(
                v => MapPointConverter.convertMapPointToString(v),
                v => MapPointConverter.convertStringToMapPoint(v)
            );
                
    }

    private void configureDrillBlockEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DrillBlock>().ToTable("drill_blocks");

        modelBuilder.Entity<DrillBlock>().Property(db => db.Id)
            .HasColumnName("drill_block_id")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<DrillBlock>().Property(db => db.Name)
            .HasColumnName("name");

        modelBuilder.Entity<DrillBlock>().Property(db => db.UpdateDate)
            .HasColumnName("update_date");
    }

    private void configureDrillBlockPointSetEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DrillBlockPointSet>().ToTable("drill_block_point_sets");

        modelBuilder.Entity<DrillBlockPointSet>().Property(dbps => dbps.Id)
            .HasColumnName("drill_block_point_set_id")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<DrillBlockPointSet>().Property(dbps => dbps.DrillBlockId)
            .HasColumnName("drill_block_id");

        modelBuilder.Entity<DrillBlockPointSet>().Property(dbps => dbps.Sequence)
            .HasColumnName("sequence")
            .HasPostgresArrayConversion(
                v => MapPointConverter.convertMapPointToString(v),
                v => MapPointConverter.convertStringToMapPoint(v)
            );

    }
}
