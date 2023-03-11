using Task5_CRUD.Domain;
using Task5_CRUD.Infrastructure.DbContexts;
using Task5_CRUD.Domain.Interfaces;

namespace Task5_CRUD.Infrastructure.Repositories;

public class DrillBlockPointSetRepository : GenericRepository<DrillBlockPointSet>, IDrillBlockPointSetRepository
{
    public DrillBlockPointSetRepository(CrudContext context) : base(context)
    {
        
    }
}