using Microsoft.AspNetCore.Mvc;
using ProdClient.Communication.Requests;
using ProdClient.Communication.Responses;
using ProdClient.Exceptions.ExceptionBase;
using ProdClient_API.UseCase.Clients.Register;

namespace ProdClient_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody]RequestClientJson request)
        {
            try
            {
                var useCase = new RegisterClientUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ProdClientException ex) 
            {
                var errors = ex.GetErrors();

                return BadRequest(new ResponseErrorMessagesJson(errors));
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("erro desconhecido"));
            }

        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetID([FromRoute]Guid id)
        {
            return Ok();
        }
    }
}
