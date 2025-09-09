using ProdClient.Communication.Responses;
using ProdClient_API.Infraestructure;

namespace ProdClient_API.UseCase.Clients.GetAll
{
    public class GetAllClientsUseCase
    {
        public ResponseAllClientsJson Execute()
        {
            var dbContext = new ProductClientDbContext();

            var clients = dbContext.Clients.ToList();

            return new ResponseAllClientsJson
            {
                Clients = clients.Select(client => new ResponseShortClientJson
                {
                    id = client.Id,
                    Name = client.Name,
                }).ToList()
            };
        }
    }
}
