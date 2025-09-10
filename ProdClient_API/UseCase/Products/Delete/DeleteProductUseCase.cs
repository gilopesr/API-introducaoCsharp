using ProdClient.Exceptions.ExceptionBase;
using ProdClient_API.Infraestructure;

namespace ProdClient_API.UseCase.Products.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ProductClientDbContext();

            var entity = dbContext.Products.FirstOrDefault(product => product.Id == id);
            if (entity is null)
                throw new NotFoundException("Produto não encontrado");

            dbContext.Products.Remove(entity);

            dbContext.SaveChanges();
        }
    }
}
