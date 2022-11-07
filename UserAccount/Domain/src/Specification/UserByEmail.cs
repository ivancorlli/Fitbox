using Ardalis.Specification;
using Domain.src.Aggregate.UserAggregate;
using Domain.src.ValueObject;

namespace Domain.src.Specification
{
    public class UserByEmail:Specification<User>
    {
        public UserByEmail(Email email){
            Query.Search(user=>user.Email.Value, email.Value);
        }
    }
}