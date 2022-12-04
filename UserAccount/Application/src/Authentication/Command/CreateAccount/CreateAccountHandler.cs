using MediatR;
using Domain.src.Interface;
using Domain.src.ValueObject;
using Domain.src.Entity;

namespace Application.src.Authentication.Command.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand,User>
    {
        private readonly IUserManager _UserManager;

        public CreateAccountHandler(IUserManager userManager)
        {
            _UserManager = userManager;
        }

        public async Task<User> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {   
            // obtenemos parametros
            var input = request.input;
            // Creamos usernmae
            var username = Username.Create(input.username);
            // Creamos email
            var email = Email.Create(input.email);
            // Creamos nuevo usuario
            var newUser = await _UserManager.CreateUser(username.Value,email.Value,input.password);

            return newUser.Value;
        }
    }
}