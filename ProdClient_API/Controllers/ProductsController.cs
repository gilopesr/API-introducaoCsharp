using Microsoft.AspNetCore.Mvc;
using ProdClient.Communication.Requests;
using ProdClient.Communication.Responses;
using ProdClient_API.UseCase.Products.Delete;
using ProdClient_API.UseCase.Products.Register;

namespace ProdClient_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [Route("{ClientId}")]
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Register([FromRoute] Guid ClientId,[FromBody] RequestProductJson request)
        {
            var useCase = new RegisterProductUseCase();

            var response = useCase.Execute(ClientId, request);

            return Created(string.Empty, response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteProductUseCase();
            useCase.Execute(id);

            return NoContent();
        }



    }
}
