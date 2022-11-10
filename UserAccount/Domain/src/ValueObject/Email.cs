using FluentResults;

namespace Domain.src.ValueObject
{
    public record Email
    {   
        private Email (string value){
            Value = value;
        }
        public string Value {get;}

        public static Result<Email> Create(string email){
            Result result = ValidateEmail(email);
            if(result.IsFailed)
                return Result.Fail(result.Errors[0]);
            return Result.Ok(new Email(email));
        }

        private static Result ValidateEmail(string email){
            return Result.Merge(
                Result.FailIf(string.IsNullOrEmpty(email),new Error("Email requerido")),
                Result.Ok()
            );
        }
    }
}