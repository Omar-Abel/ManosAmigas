using ManosAmigas_Back.Sources.Application.Interfaces.Repositories;
using ManosAmigas_Back.Sources.Domain.Entities;


namespace ManosAmigas_Back.Sources.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
