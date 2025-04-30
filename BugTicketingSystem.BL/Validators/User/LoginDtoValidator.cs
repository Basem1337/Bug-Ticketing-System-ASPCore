
using BugTicketingSystem.BL;
using BugTicketingSystem.DAL;
using FluentValidation;

namespace BugTrackingSystem.BL;

public class LoginDtoValidator : AbstractValidator<User>
{
    private readonly IUnitOfWork _unitWork;
    private readonly UserManager _userManager;

    public LoginDtoValidator(
        IUnitOfWork unitWork,
        UserManager userManager
        )
    {
        _unitWork = unitWork;
        _userManager = userManager;
        //Rules
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
            //.MustAsync(async (model, password, cancellationToken) =>
            //{
            //    var user = await _userManager.FindByEmailAsync(model.Email);
            //    if (user == null)
            //    {
            //        return false;
            //    }

            //    var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            //    return result.Succeeded;
            //})
            //.WithMessage("Invalid password.");

    }
}
