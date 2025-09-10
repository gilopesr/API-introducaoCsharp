using Microsoft.AspNetCore.Mvc;
using ProdClient.Communication.Requests;
using ProdClient.Communication.Responses;
using ProdClient_API.UseCase.Clients.Delete;
using ProdClient_API.UseCase.Clients.GetAll;
using ProdClient_API.UseCase.Clients.GetById;
using ProdClient_API.UseCase.Clients.Register;
using ProdClient_API.UseCase.Clients.Update;

namespace ProdClient_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody]RequestClientJson request)
        {
                var useCase = new RegisterClientUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] Guid id,[FromBody] RequestClientJson request)
        {
            var useCase = new UpdateClienteUseCase();
            useCase.Execute(id, request);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllClientsUseCase();

            var response = useCase.Execute();

            if (response.Clients.Count == 0)
                return NoContent();

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteClientUseCase();
            useCase.Execute(id);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseClientJson),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var useCase = new GetClientByIdUseCase();

            var response = useCase.Execute(id);

            return Ok(response);
        }
    }
}
