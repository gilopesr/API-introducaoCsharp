using ProdClient.Communication.Requests;
using ProdClient.Communication.Responses;
using ProdClient.Exceptions.ExceptionBase;

namespace ProdClient_API.UseCase.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            var validator = new RegisterClientvalidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                 var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }

            return new ResponseClientJson();
        }
    }
}
