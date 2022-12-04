using System.Threading.Tasks;
using System.Reflection.Metadata;
using Domain.src.Entity;
using Xunit;
using FluentAssertions;
using Domain.src.ValueObject;
using Domain.src.Enum;
using FluentResults;
using System.Collections.Generic;
using System;
using Bogus;

namespace Tests.src.Domain.Entity
{
    public class UserShould
    {   

        public Result<Username> username = Username.Create("ivancorlli");
        public Result<Email> email = Email.Create("ivancorlli@gmail.com");
        public string password = "qwdfrto32422";

    }
}