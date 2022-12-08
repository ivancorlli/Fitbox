using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.Entity;
using Domain.src.ValueObject;
using FluentResults;

namespace Domain.src.Interface
{
    public interface IUserManager
    {
        public Task<Result<User>> CreateUser(Username username,Email email, string passowrd);
        public Task<Result> ChangeUsername(User user,Username username);
        public Task<Result> ChangeEmail(User user,Email email);
        public Task<Result> ChangePhone(User user,Phone phone);
    }
}