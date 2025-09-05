using ProdClient.Communication.Requests;
using ProdClient.Communication.Responses;
using ProdClient.Exceptions.ExceptionBase;
using ProdClient_API.Entities;
using ProdClient_API.Infraestructure;

namespace ProdClient_API.UseCase.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientDbContext();

            var entity = new Client
            {
                Name = request.Name,
                Email = request.Email,
                Id = Guid.NewGuid()
            };

            dbContext.Clients.Add(entity);
            dbContext.SaveChanges();

            return new ResponseClientJson
            {
                id = entity.Id,
                Name = entity.Name,
            };
        }

        private void Validate(RequestClientJson request)
        {
            var validator = new RegisterClientvalidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }

}
