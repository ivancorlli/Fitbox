using Domain.src.Interface;
using Domain.src.ValueObject;
using MediatR;

namespace Application.src.UserFeature.Command.ChangeEmail
{
    public class ChangeEmailHandler : IRequestHandler<ChangeEmailCommand, Unit>
    {
        private readonly IUserRepository _UserRepository;

        public ChangeEmailHandler(IUserRepository repository) {
            _UserRepository=repository; 
            }
        public async Task<Unit> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
        {
            // Obtenemos input
            var userInput = request.email;

            // Buscamos usuario por id
            var user = await _UserRepository.GetById(userInput.Id);

            // Nuevo email
            var newEmail = Email.Create(userInput.Email);

            // Enviamos mensaje de error
            user.ChangeEmail(newEmail.Value);
            


            return Unit.Value;
        }
    }
}