
using API.Controllers.Presenters.Request.User;
using API.Controllers.Presenters.Response.User;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Shared.Exceptions;

namespace API.Controllers.Presenters.User
{
    public class UserPresenter(IUserService userService,
        IUnitOfWork unitOfWork) : IUserPresenter
    {
        private readonly IUserService _userService = userService;
        private readonly IUnitOfWork _uniOfWotk = unitOfWork;

        public async Task<AuthResponse> GetUserByEmail(AuthRequest request)
        {
            var recoveryUser = await _userService.FilterAsync(x => x.Email.Equals(request.Email));

            if (recoveryUser is null)
                throw new BusinessException(["Usuário não encontrado"]);

            if (!recoveryUser.Senha.Equals(request.Senha))
                throw new BusinessException(["Senha inválida"]);

            return new AuthResponse { Email = recoveryUser.Email, Senha = recoveryUser.Senha };
        }

        public async Task SaveAsync(UserCreateAndUpdateRequest request)
        {
            UserEntity user = new(request.Nome,
                request.Email,
                request.Senha);

            await _userService.AddAsync(user);
            await _uniOfWotk.CommitAsync();
        }
    }
}
