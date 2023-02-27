using SharedKernell.src.Interface.Mediator;
using SharedKernell.src.Result;
using UserContext.Application.src.Features.PersonAccount.DTO.Output;
using UserContext.Domain.src.Entity;
using UserContext.Domain.src.Enum;
using UserContext.Domain.src.Error;
using UserContext.Domain.src.Interface;
using UserContext.Domain.src.ValueObject;

namespace UserContext.Application.src.Features.PersonAccount.Command.CreateProfile;

internal class CreateProfileHandler : IHandler<CreateProfileCommand, Result<CreateProfileOutput>>
{
    private readonly IUnitOfWork _Unit;
    public CreateProfileHandler(IUnitOfWork unitOfWork) => _Unit = unitOfWork;
    public async Task<Result<CreateProfileOutput>> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var input = request.Input;
        // Obtenemos la cuenta
        var account = await _Unit.PersonReadRepository.GetByIdAsync(input.AccountId);
        if (account == null) return Result.Fail<CreateProfileOutput>(new AccountNotFound());
        var name = PersonName.Create(input.Name, input.Surname);
        if(name.IsFailure)
            return Result.Fail<CreateProfileOutput>(name.Error);
        var gender = (Gender)Enum.Parse(typeof(Gender), input.Gender);
        var newProfile = account.AddProfile(name.Value, gender,input.Birth);
        if(newProfile.IsFailure)
            return Result.Fail<CreateProfileOutput>(newProfile.Error);
        PersonProfile? profile = null;
        if(account.Profile != null)
        {
            profile = account.Profile;
            await _Unit.PersonWriteRepository.AddProfileAsync(account.Profile);
        }
        await _Unit.SaveChangesAsync(cancellationToken);
        return Result.Ok(new CreateProfileOuput(profile!.AccountId,profile.Name,profile.Gender,profile.Birth));
    }
}
