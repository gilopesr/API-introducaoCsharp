using ProdClient.Communication.Requests;
using ProdClient.Communication.Responses;
using ProdClient.Exceptions.ExceptionBase;
using ProdClient_API.Entities;
using ProdClient_API.Infraestructure;
using ProdClient_API.UseCase.Products.SharedValidator;

namespace ProdClient_API.UseCase.Products.Register
{
    public class RegisterProductUseCase
    {
        public ResponseShortProductJson Execute(Guid ClientId, RequestProductJson request)
        {
            var dbContext = new ProductClientDbContext();

            Validate(dbContext, ClientId,request);

            var entity = new Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Price = request.Price,
                ClientId = ClientId,
            };

            dbContext.Products.Add(entity);
            dbContext.SaveChanges();

            return new ResponseShortProductJson
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        private void Validate(ProductClientDbContext dbContext, Guid ClientId,RequestProductJson request)
        {

            var clientExist = dbContext.Clients.Any(client => client.Id == ClientId);
            if (clientExist == false)
                throw new NotFoundException("Client não Existe");

            var validator = new RequestProductValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }

}
