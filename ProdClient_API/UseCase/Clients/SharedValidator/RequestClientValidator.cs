using FluentValidation;
using ProdClient.Communication.Requests;

namespace ProdClient_API.UseCase.Clients.SharedValidator
{
    public class RequestClientValidator : AbstractValidator<RequestClientJson>
    {
        public RequestClientValidator()
        {
            RuleFor(client => client.Name).NotEmpty().WithMessage("O nome não pode ser vazio!");
            RuleFor(client => client.Email).EmailAddress().WithMessage("O email não é válido!");

        }
    }
}
