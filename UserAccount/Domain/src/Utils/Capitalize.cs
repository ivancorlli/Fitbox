using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.Utils
{
    public class Capitalize
    {

        public static string Create(string value){
            var Initial = char.ToUpper(value[0]);
            var Rest = value.Substring(1).ToLower();
            return Initial.ToString() + Rest ;
        }
    }
}