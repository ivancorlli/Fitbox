using Domain.src.Interface;
using Domain.src.Service;
using Domain.src.ValueObject;
using MediatR;

namespace Application.src.User.Command.ChangeUsername
{
    public class ChangeUsernameHandler : IRequestHandler<ChangeUsernameCommand, Unit>
    {

        private readonly IUserRepository _UserRepository;
        private readonly UserManager _UserManager;

        public ChangeUsernameHandler(IUserRepository repository,UserManager manager) {
            _UserRepository=repository; 
            _UserManager = manager;
            }

        public async Task<Unit> Handle(ChangeUsernameCommand request, CancellationToken cancellationToken)
        {   
            // Obtenemos input
            var userInput = request.username;

            // Obtenemos usuario
            var user = await _UserRepository.GetById(userInput.Id);

            // Cambiamos nombre de usuario
            await _UserManager.ChangeUsername(user,new Username(userInput.Username));

            // Guardamos los datos en db
            await _UserRepository.Add(user);

            return Unit.Value;

        }
    }
}