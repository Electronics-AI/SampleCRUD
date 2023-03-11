using Task5_CRUD.Domain;
using Task5_CRUD.Infrastructure.DbContexts;
using Task5_CRUD.Domain.Interfaces;

namespace Task5_CRUD.Infrastructure.Repositories;

public class HoleRepository : GenericRepository<Hole>, IHoleRepository
{
    public HoleRepository(CrudContext context) : base(context)
    {
        
    }
}
