using Domain.src.ValueObject;
using Domain.src.Enum;

namespace Domain.src.Entity
{
    public class Gym
    {
        public Guid Id {get;}
        public string Username {get;private set;}
        public string Email {get;private set;}
        public GymStatus Status {get;private set;}
        public  GymProfile? Profile {get;private set;}
        public Schedule? Schedule {get;private set;}
        public Address? Address {get;private set;}
        public PhoneNumber? PhoneNumber {get;private set;}

        /// <summary>
        /// Crea un nuevo gimnasio
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        public Gym(string username,string email){
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Status = GymStatus.Active;
        }

    }
}