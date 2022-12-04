using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentResults;

namespace Domain.src.ValueObject
{
    public record ZipCode
    {
        private static int _Min = 3;
        private static int _Max = 8; 
        private static Regex _Reg = new Regex("^[a-zA-Z0-9- ]+$");

        public string Value {get;init;}

        private ZipCode(string zipCode){
            Value =zipCode;
        }

        public static Result<ZipCode> Create(string zipCode){
            var validZip = Validate(zipCode);

            if(validZip.IsFailed)
                return Result.Fail(new Error(validZip.Errors[0].Message));
            var newZip = new ZipCode(zipCode);
                return Result.Ok<ZipCode>(newZip);
        }

        private static Result Validate(string zip){
            return Result.Merge(
                Result.FailIf(string.IsNullOrEmpty(zip),new Error("Debe ingresar un codigo postal")),
                Result.FailIf(! _Reg.IsMatch(zip),new Error("Codigo postal invalido")),
                Result.FailIf(zip.Length < _Min, new Error($"El codigo postal debe tener mas de {_Min} caracteres")),
                Result.FailIf(zip.Length > _Max, new Error($"El odigo postal no debe tener mas de {_Max} caracteres"))
            );
        }
        
    }
}