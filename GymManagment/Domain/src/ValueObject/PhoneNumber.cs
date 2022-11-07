using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.ValueObject
{
    public class PhoneNumber
    {
        public int AreaCode {get;private set;}
        public int Phone {get;private set;}

        public PhoneNumber(int areaCode, int phoneNumber){
            AreaCode = areaCode;
            Phone = phoneNumber;
        }
    }
}