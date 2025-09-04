using FluentValidation;
using ProdClient.Communication.Requests;

namespace ProdClient_API.UseCase.Clients.Register
{
    public class RegisterClientvalidator : AbstractValidator<RequestClientJson>
    {
        public RegisterClientvalidator()
        {
            RuleFor(client => client.Nome).NotEmpty().WithMessage("O nome não pode ser vazio!");
            RuleFor(client => client.Email).EmailAddress().WithMessage("O email não é válido!");

        }
    }
}
