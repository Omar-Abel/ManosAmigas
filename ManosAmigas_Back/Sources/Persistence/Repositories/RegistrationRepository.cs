using ManosAmigas_Back.Sources.Application.Interfaces.Repositories;
using ManosAmigas_Back.Sources.Domain.Entities;


namespace ManosAmigas_Back.Sources.Persistence.Repositories
{
    public class RegistrationRepository : GenericRepository<Registration>, IRegistrationRepository
    {
        private readonly ApplicationContext _dbContext;

        public RegistrationRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
