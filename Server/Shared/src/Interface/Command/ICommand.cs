using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Shared.src.Interface.Command
{
    public interface ICommand : IRequest
    {

    }

    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}