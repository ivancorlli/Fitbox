using Domain.src.Interface;
using Domain.src.Service;
using Domain.src.ValueObject;
using MediatR;

namespace Application.src.User.Command.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, Unit>
    {   
        private readonly IUserRepository _UserRepository;
        private readonly UserManager _UserManager;

        public CreateAccountHandler(IUserRepository repository,UserManager manager){
            _UserRepository = repository;
            _UserManager =manager;
        }

        public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {    
            var userInput = request.newAccount;

            // Creamos un nuevo usuario
            var newUser = await _UserManager.CreateUser(
                new Email(userInput.Email),
                new Username(userInput.Username),
                userInput.Password
            );

            
            // Guardamos usuario en base de datos
            var userSaved = await _UserRepository.Add(newUser.Value);
            return Unit.Value;
        }
    }
}