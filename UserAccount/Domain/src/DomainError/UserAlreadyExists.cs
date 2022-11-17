using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.src.ValueObject;
using FluentResults;

namespace Domain.src.DomainError
{
    public class UserAlreadyExists:Error
    {   
        /// <summary>
        /// Nombre de usuario o Email
        /// </summary>
        /// <param name="text"></param>    
        public UserAlreadyExists(string text):base($"{text} ya ha sido registrado"){}
        
    }
}