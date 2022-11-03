using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.ValueObject
{
    public record PhoneNumber
    {

        public PhoneNumber(int areaCode, int phoneNumber){
            AreaCode = areaCode;
            Phone = phoneNumber;
        }

       public int AreaCode {get;}
       public int Phone {get; } 
    }
}