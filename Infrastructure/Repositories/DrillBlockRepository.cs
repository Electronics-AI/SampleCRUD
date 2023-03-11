using Task5_CRUD.Domain;
using Task5_CRUD.Infrastructure.DbContexts;
using Task5_CRUD.Domain.Interfaces;

namespace Task5_CRUD.Infrastructure.Repositories;

public class DrillBlockRepository : GenericRepository<DrillBlock>, IDrillBlockRepository
{
    public DrillBlockRepository(CrudContext context) : base(context)
    {
        
    }
}
