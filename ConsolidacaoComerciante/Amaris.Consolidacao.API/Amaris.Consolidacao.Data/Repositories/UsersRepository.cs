using Amaris.Consolidacao.Data.Interfaces;
using Amaris.Consolidacao.Data.Repositories.Base;
using Amaris.Consolidacao.Domain.Entities;
using Amaris.Consolidacao.Service.Interfaces.Repository;
using Microsoft.Extensions.Logging;

namespace Amaris.Consolidacao.Data.Repositories
{
    public class UsersRepository : RepositoryBase<UserEntity>, IUsersRepository
    {
        private readonly ILogger<UsersRepository> _logger;
        public UsersRepository(IDbContext context, ILogger<UsersRepository> logger) : base(context)
        {
            _logger = logger;
        }
    }
}
