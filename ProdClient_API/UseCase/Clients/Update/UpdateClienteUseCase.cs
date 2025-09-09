using ProdClient.Communication.Requests;
using ProdClient.Exceptions.ExceptionBase;
using ProdClient_API.Infraestructure;
using ProdClient_API.UseCase.Clients.SharedValidator;

namespace ProdClient_API.UseCase.Clients.Update
{
    public class UpdateClienteUseCase
    {

        public void Execute(Guid clientId, RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientDbContext();

            var entity = dbContext.Clients.FirstOrDefault(client => client.Id == clientId);
            if (entity is null)
                throw new NotFoundException("Cliente Não encontrado.");
            entity.Name = request.Name;
            entity.Email = request.Email;

            dbContext.Clients.Update(entity);
            dbContext.SaveChanges();
        }

        private void Validate(RequestClientJson request)
        {
            {
                var validator = new RequestClientValidator();
                var result = validator.Validate(request);

                if (result.IsValid == false)
                {

                    var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                    throw new ErrorOnValidationException(errors);

                }
            }
        }
    }
}
