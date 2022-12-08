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
            var validText = ValidateText(disabilities);
            if(validText.IsFailed){
                return Result.Fail(new Error(validText.Errors[0].Message));
            }else{
            return Result.Ok<MedicalInfo>(new MedicalInfo(disabilities));
            }
        }

        /// <summary>
        /// Crea un registro medico de la aptitud fisica y las dificultades para realizar actividad fisica
        /// </summary>
        /// <param name="aprirude"></param>
        /// <param name="disabilities"></param>
        /// <returns></returns>
        public static Result<MedicalInfo> Create(Uri aprirude,string disabilities){
            var validText =Result.Merge(
                ValidateText(disabilities)
            );
            
            if(validText.IsFailed){
                return Result.Fail(new Error(validText.Errors[0].Message));
            }else{
                return Result.Ok<MedicalInfo>(new MedicalInfo(disabilities));
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