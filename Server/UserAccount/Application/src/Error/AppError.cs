using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.src.Interface;

namespace Application.src.Error
{
    public class AppError : IAppError
    {
        public int Code { get; init; }
        public string Message { get; init; }

        public AppError(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}