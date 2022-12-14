using System.Text.RegularExpressions;
using Domain.src.Utils;
using FluentValidation;
using Shared.src.Constant;
using Shared.src.Error;

namespace Domain.src.ValueObject
{
    public record MedicalInfo
    {


        public static int MaxLength = 300;
        public static Regex Reg = new Regex("^[a-zA-Z0-9., ]+$");

        public Uri? Aptitude {get; private set;}
        public string? Disabilities {get;private set;}

        private MedicalInfo(Uri aptitude){
            Aptitude = aptitude;
        }

        private MedicalInfo(string disabilities){
            Disabilities= disabilities;
        }

        private MedicalInfo(Uri aptitude, string disabilities){
            Aptitude = aptitude;
            Disabilities= disabilities;
        }

        /// <summary>
        /// Crea una nueva aptitud medica
        /// </summary>
        /// <param name="aptitude"></param>
        /// <returns></returns>
        public static Result<MedicalInfo> Create(Uri aptitude){
            return Result.Ok<MedicalInfo>(new MedicalInfo(aptitude));
        }

        /// <summary>
        /// Crea un registro de las dificultades para realizar actividad fisica
        /// </summary>
        /// <param name="disabilities"></param>
        /// <returns></returns>
        public static Result<MedicalInfo> Create(string disabilities){
            MedicalInfo medical = new(disabilities);
            MedicalInfoValiator validator = new();
            var result = validator.Validate(medical);
            if(!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<MedicalInfo>(errors[0]);
            }
            return Result.Ok<MedicalInfo>(medical);
        }

        /// <summary>
        /// Crea un registro medico de la aptitud fisica y las dificultades para realizar actividad fisica
        /// </summary>
        /// <param name="aptirude"></param>
        /// <param name="disabilities"></param>
        /// <returns></returns>
        public static Result<MedicalInfo> Create(Uri aptirude,string disabilities){
            MedicalInfo medical = new(aptirude,disabilities);
            MedicalInfoValiator validator = new();
            var result = validator.Validate(medical);
            if(!result.IsValid)
            {
                var errors = ConvertDomainError.Convert(result);
                return Result.Fail<MedicalInfo>(errors[0]);
            }
            return Result.Ok<MedicalInfo>(medical);
        }
    }
    internal class MedicalInfoValiator : AbstractValidator<MedicalInfo>
    {
        public MedicalInfoValiator()
        {
            RuleFor(x=>x.Disabilities)
                .Matches(MedicalInfo.Reg)
                .MaximumLength(MedicalInfo.MaxLength)
                .WithErrorCode(ErrorTypes.Validation);
        }
    }
}