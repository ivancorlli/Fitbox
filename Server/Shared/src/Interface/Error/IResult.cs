using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.src.Interface.Error
{
    public interface IResult
    {
        public bool IsSuccess {get;}
        public bool IsFailure {get;}
        public IError Error {get;}
    }
}