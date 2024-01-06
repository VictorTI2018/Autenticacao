using Application.Validators.User;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Shared.Exceptions;
using System.Linq.Expressions;

namespace Application.Services.User
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserEntity?> FilterAsync(Expression<Func<UserEntity, bool>> expression)
            => await _userRepository.FilterAsync(expression);
        public async Task AddAsync(UserEntity user)
        {
            var validator = new UserCreateValidator();
            var result = await validator.ValidateAsync(user);

            if (!result.IsValid)
                throw new BusinessException(result.Errors.Select(x => x.ErrorMessage).ToList());

            var recoveryUser = await FilterAsync(x => x.Email.Equals(user.Email));

            if (recoveryUser is not null)
                throw new BusinessException(["Usuário já cadastrado."]);

            await _userRepository.AddAsync(user);

        }
    }
}
