using Microsoft.EntityFrameworkCore;
using ProdClient.Communication.Responses;
using ProdClient.Exceptions.ExceptionBase;
using ProdClient_API.Infraestructure;

namespace ProdClient_API.UseCase.Clients.GetById
{
    public class GetClientByIdUseCase
    {
        public ResponseClientJson Execute(Guid Id)
        {
            var dbContext = new ProductClientDbContext();

            var entity = dbContext
                .Clients
                .Include(Client => Client.Products)
                .FirstOrDefault(client => client.Id == Id);


            if (entity is null)
                throw new NotFoundException("Cliente não encontrado");

            return new ResponseClientJson
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Products = entity.Products.Select(products => new ResponseShortProductJson
                {
                    Id = products.Id,
                    Name = products.Name,
                }).ToList()
            };
        }
    }
}
