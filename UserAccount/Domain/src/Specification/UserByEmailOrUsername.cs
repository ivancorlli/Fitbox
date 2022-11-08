using Ardalis.Specification;
using Domain.src.Aggregate.UserAggregate;
using Domain.src.ValueObject;

namespace Domain.src.Specification
{
    public class UserByEmailOrUsername:Specification<User>
    {
        public UserByEmailOrUsername(Email email,Username username){

            if(!string.IsNullOrEmpty(email.Value) && !string.IsNullOrEmpty(username.Value) ){
                Query.Where(X=>X.Email.Value == email.Value || X.Username.Value == username.Value);
            }
        }
    }
}