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

       public int AreaCode {get;private set;}
       public int Phone {get;private set;} 
       public bool Verified {get;private set;}

        /// <summary>
        /// Actualiza el codigo de area
        /// </summary>
        /// <param name="areaCode"></param>
       internal void ChangeAreaCode(int areaCode){
        AreaCode = areaCode;
       }

        /// <summary>
        /// Actualiza el nuemero de telefono
        /// </summary>
        /// <param name="phoneNumber"></param>
       internal void ChangePhoneNumber(int phoneNumber){
        Phone = phoneNumber;
       }

        /// <summary>
        /// Verifica el numero de telefono
        /// </summary>
        public void VerifyPhoneNumber(){
        Verified = true;
        }

        /// <summary>
        /// Desverifica el numero de telefono
        /// </summary>
        public void UnverifyPhoneNumber(){
        Verified = false;
        }
    }
}