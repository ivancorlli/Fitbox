using Domain.src.Interface;
using Shared.src.Error;
using Shared.src.Interface.Command;

namespace Application.src.Features.Authentication.Command.VerifyEmail
{
    public class VerifyEmailHandler : IHandler<VerifyEmailCommand, Result>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IUserReadRepository _UserRead;
        public VerifyEmailHandler(IUnitOfWork unitOfWork, IUserReadRepository userRead)
        {
            _UnitOfWork = unitOfWork;
            _UserRead = userRead;
        }

        public async Task<Result> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var input = request.verifyEmail;
            // Buscamos usuario por su id
            var user = await _UserRead.GetUserById(input.userId);
            if (user == null)
                return Result.Fail(new DomainError("NotFound", "No se encontro al usuario"));
            // Cambiamos su estado a verificado
            user.VerifyEmail();
            // Guardamos en base de datos
            await _UnitOfWork.UserWriteRepository.Update();
            return Result.Ok();
        }
    }
}