using ManosAmigas_Back.Sources.Application.Interfaces.Repositories;
using ManosAmigas_Back.Sources.Domain.Entities;


namespace ManosAmigas_Back.Sources.Persistence.Repositories
{
    public class VolunteerActivityRepository : GenericRepository<VolunteerActivity>, IVolunteerActivityRepository
    {
        private readonly ApplicationContext _dbContext;

        public VolunteerActivityRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
