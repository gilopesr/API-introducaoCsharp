using ProdClient.Exceptions.ExceptionBase;
using ProdClient_API.Infraestructure;

namespace ProdClient_API.UseCase.Clients.Delete
{
    public class DeleteClientUseCase
    {
            public void Execute(Guid id)
            {
                var dbContext = new ProductClientDbContext();

                var entity = dbContext.Clients.FirstOrDefault(client => client.Id == id);
                if (entity is null)
                    throw new NotFoundException("Cliente não encontrado");

                dbContext.Clients.Remove(entity);

                dbContext.SaveChanges();
            }
        
    }
}

