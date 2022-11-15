using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;

namespace Domain.src.ValueObject
{
    public record MedicalInfo
    {
        public string Aptitude {get;}
        public string? Allergies {get;}
        public string? Disabilities {get;}

        private MedicalInfo(string aptitude){
            Aptitude = aptitude;
        }

        internal static Result<MedicalInfo> Create(string aptitude){
            return Result.Ok<MedicalInfo>(new MedicalInfo(aptitude));
        }
    }
}