using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentResults;

namespace Domain.src.ValueObject
{
    public record MedicalInfo
    {


        private static int _Max = 300;
        private static Regex _Reg = new Regex("^[a-zA-Z0-9., ]+$");

        public Uri? Aptitude {get; private set;}
        public string? Allergies {get;private set;}
        public string? Disabilities {get;private set;}

        private MedicalInfo(Uri aptitude){
            Aptitude = aptitude;
        }

        private MedicalInfo(string disabilities, string? allergies){
            Disabilities= disabilities;
            Allergies= allergies;
        }

        /// <summary>
        /// Crea una nueva aptitud medica
        /// </summary>
        /// <param name="aptitude"></param>
        /// <returns></returns>
        internal static Result<MedicalInfo> Create(Uri aptitude){
            return Result.Ok<MedicalInfo>(new MedicalInfo(aptitude));
        }

        /// <summary>
        /// Crea un registro de las dificultades para realizar actividad fisica
        /// </summary>
        /// <param name="disabilities"></param>
        /// <returns></returns>
        internal static Result<MedicalInfo> Create(string disabilities){
            var validText = ValidateText(disabilities);
            if(validText.IsFailed){
                return Result.Fail(new Error(validText.Errors[0].Message));
            }else{
            return Result.Ok<MedicalInfo>(new MedicalInfo(disabilities,null));
            }
        }

        /// <summary>
        /// Crea un registro de las dificultades para realizar actividad fisica y de las alergias
        /// </summary>
        /// <param name="disabilities"></param>
        /// <param name="allergies"></param>
        /// <returns></returns>
        internal static Result<MedicalInfo> Create(string disabilities, string allergies){
            var validText =Result.Merge(
                ValidateText(disabilities),
                ValidateText(allergies)
            );
            
            if(validText.IsFailed){
                return Result.Fail(new Error(validText.Errors[0].Message));
            }else{
                return Result.Ok<MedicalInfo>(new MedicalInfo(disabilities,allergies));
            }
        }

        public void ChangeAptitude(Uri aptitude){
            Aptitude = aptitude;
        }

        public Result ChangeDisabilites(string disabilities){
            var vaildText = ValidateText(disabilities);

            if(vaildText.IsFailed){
                return Result.Fail(new Error(vaildText.Errors[0].Message));
            }else {
                Disabilities = disabilities;
                return Result.Ok();
            }
        }

        public Result ChangeAllergies(string allergies){
            var vaildText = ValidateText(allergies);

            if(vaildText.IsFailed){
                return Result.Fail(new Error(vaildText.Errors[0].Message));
            }else {
                Allergies = allergies;
                return Result.Ok();
            }
        }


        private static Result ValidateText(string text){
            return Result.Merge(
                Result.FailIf(!_Reg.IsMatch(text),new Error("Formato de texto invalido")),
                Result.FailIf(text.Length > _Max,new Error("El texto es demasiado largo"))
            );
        }
    }
}