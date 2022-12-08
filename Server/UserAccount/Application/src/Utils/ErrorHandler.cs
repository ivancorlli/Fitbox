using Application.src.Error;
using Application.src.Interface;
using FluentResults;

namespace Application.src.Utils
{
    public class ErrorHandler
    {

        public static IAppError? GetError(List<IError> errors){
            IAppError? response = null;
            for (int i = 0; i < errors.Count; i++)
            {
                var error = errors[i].Metadata["Type"].ToString();
                if(error == "1"){

                    response = new AppError(400,errors[i].Message);
                    break;
                }

            }
                return response;
        }

    }
}