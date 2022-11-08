namespace Domain.src.utils
{
    public class Capitalize
    {

        public string Value {get;}

        private Capitalize(string value){
         Value = char.ToUpper(value[0]) + value.Substring(1);

        }
        

        public static string Create(string value){
            if (string.IsNullOrEmpty(value)){
                return String.Empty;
            }
                return new Capitalize(value).Value;
        }

    }
}