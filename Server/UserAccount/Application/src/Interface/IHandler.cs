using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using MediatR;

namespace Application.src.Interface
{
    public interface IHandler<T>:IRequestHandler<T,Result> where T :ICommand 
    {
        
    }

    public interface IHandler<T,R>:IRequestHandler<T,Result<R>> where T :ICommand<R> 
    {
        
    }
}