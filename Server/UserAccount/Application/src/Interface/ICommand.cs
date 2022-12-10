using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using MediatR;

namespace Application.src.Interface
{
    public interface ICommand:IRequest<Result>
    {
        
    }

    public interface ICommand<TResponse> :IRequest<Result<TResponse>>
    {
        
    }
}