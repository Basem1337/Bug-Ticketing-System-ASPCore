﻿
using BugTicketingSystem.BL;
using BugTicketingSystem.DAL;
using FluentValidation;

namespace BugTrackingSystem.BL;

public class RegisterDtoValidator : AbstractValidator<UserRegisterDTO>
{
    private readonly IUnitOfWork _unitWork;
    public RegisterDtoValidator(
        IUnitOfWork unitWork
        )
    {
        _unitWork = unitWork;
        //Rules
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MinimumLength(2)
            .WithMessage("Name must be at least 2 characters long.")
            .Matches(@"^[a-zA-Z]+$")
            .WithMessage("Name must contain only letters.");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long.");
        //RuleFor(x => x.Role)
        //    .NotEmpty()
        //    .WithMessage("Role is required.")
        //    .IsInEnum()
        //    .WithMessage("Invalid role. Role must be either Manager, Developer, or Tester.");
        RuleFor(x => x.Email)
            .MustAsync(CheckEmailUniqueness)
            .WithMessage("Email already exists.")
            .When(x => !string.IsNullOrEmpty(x.Email));
        RuleFor(x => x.Age)
            .GreaterThan(18)
            .WithMessage("Cannot be less than 18 years old.");

    }

    private async Task<bool> CheckEmailUniqueness(
    string email,
    CancellationToken token)
    {
        var users = await _unitWork.UserRepository.getAllAsync();
        return users.All(u => u.Email != email);
    }
}
