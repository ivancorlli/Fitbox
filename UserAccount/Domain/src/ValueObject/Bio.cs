using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;

namespace Domain.src.ValueObject
{
    public record Bio
    {   
        private static int _Max = 300;

        public string Value {get;}

        private Bio(string value){
            Value = value;
        }

        public static Result<Bio> Create(string bio){
            if(string.IsNullOrEmpty(bio)){
            var newBio = new Bio("");
                return Result.Ok<Bio>(newBio);
            }else{
                var validBio = ValidateBio(bio);
                if(validBio.IsFailed){
                    return Result.Fail(new Error(validBio.Errors[0].Message));
                }else {
                    var newBio = new Bio(bio);
                    return Result.Ok<Bio>(newBio);
                }

            }
        }

        private static Result ValidateBio(string bio){
            return Result.Merge(
                Result.FailIf(bio.Length > _Max,new Error($"La biografia no debe tener mas de {_Max} caracteres"))
            );
        }

        
    }
}