using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.src.Interface
{
    public interface IAppError
    {
        public int Code {get;}
        public string Message {get;}
    }
}