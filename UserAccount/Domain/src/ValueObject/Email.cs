using System.Text.RegularExpressions;
namespace Domain.src.ValueObject
{
    public record Email
    {   
        public Email (string value){
            Value = value;
        }
        public string Value {get;}
    }
}