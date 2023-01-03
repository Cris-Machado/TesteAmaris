using Amaris.Consolidacao.Domain.Entities;
using Amaris.Consolidacao.Domain.Models;
using Amaris.Consolidacao.Identity.Dtos;
using Amaris.Consolidacao.Identity.Entities;
using Amaris.Consolidacao.Service.Interfaces.Repository;
using Amaris.Consolidacao.Service.Interfaces.Service;
using Amaris.Consolidacao.Service.Service.Base;
using Microsoft.AspNetCore.Identity;

namespace Amaris.Consolidacao.Service.Service
{
    public class UsersService : ServiceBase<UserEntity>, IUsersService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUsersRepository _userRepository;

        public UsersService(IUnitOfWork unitOfWork, IRepositoryBase<UserEntity> repository, UserManager<AppUser> userManager, IUsersRepository userRepository) : base(unitOfWork, repository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        #region Methods
        public async Task<ResposeRequest<AppUser>> CreateUserAsync(User model)
        {
            var response = new ResposeRequest<AppUser>();
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    response.Sucesso = false;
                    response.ErrorDescription = "E-mail já utilizado por outra conta.";
                }
                else
                {
                    user = new AppUser
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        Name = model.Name,
                        PhoneNumber = model.PhoneNumber,
                        EmailConfirmed = true
                    };

                    response.Data = user;
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (!result.Succeeded)
                    {
                        response.Sucesso = false;
                        response.ErrorDescription = "Ocorreu um erro ao cadastrar o usuário, tente novamente.";
                    }
                    else
                        CreateLocalUser(model);
                }

                return response;
            }
            catch (Exception e)
            {

                response.Sucesso = false;
                response.ErrorDescription = e.Message;
                return response;
            }

        }
        #endregion

        #region ## Private Methods
        private void CreateLocalUser(User model)
        {
            var userEntity = new UserEntity();
            userEntity.ModelToEntity(model);
            _userRepository.InsertAsync(userEntity);
        }
        #endregion
    }
}
