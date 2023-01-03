using Amaris.Consolidacao.Domain.Entities;
using Amaris.Consolidacao.Domain.Models;
using Amaris.Consolidacao.Identity.Dtos;
using Amaris.Consolidacao.Identity.Entities;

namespace Amaris.Consolidacao.Service.Interfaces.Service
{
    public interface IUsersService : IServiceBase<UserEntity>
    {
        Task<ResposeRequest<AppUser>> CreateUserAsync(User model);
    }
}
