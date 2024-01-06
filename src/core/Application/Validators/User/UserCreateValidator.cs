using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.User
{
    public class UserCreateValidator : AbstractValidator<UserEntity>
    {
        public UserCreateValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage(u => $"Campo {nameof(u.Nome)} é obrigatório");

            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage(u => $"Campo {nameof(u.Email)} é obrigatório");

            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage(u => $"Campo {nameof(u.Senha)} é obrigatório");
        }
    }
}
