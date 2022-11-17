using Domain.src.Interface;


namespace Domain.src.Service
{
    public class UserManager
    {
        private readonly IUserReadRepository _UserRepo;

        public UserManager(IUserReadRepository repo){
            _UserRepo = repo;
        }

        private void CryptPassword(){
             BCrypt.Net.BCrypt.HashPassword("Pa$$w0rd");
        } 

    }
}