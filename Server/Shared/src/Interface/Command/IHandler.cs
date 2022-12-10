using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Shared.src.Interface.Command
{
     public interface IHandler<T>:IRequestHandler<T> where T :ICommand 
    {
        
    }

    public interface IHandler<T,R>:IRequestHandler<T,R> where T :ICommand<R> 
    {
        
    }
}