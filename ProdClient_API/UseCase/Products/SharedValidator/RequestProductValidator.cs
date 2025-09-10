using FluentValidation;
using ProdClient.Communication.Requests;

namespace ProdClient_API.UseCase.Products.SharedValidator
{
    public class RequestProductValidator : AbstractValidator<RequestProductJson>
    {
        public RequestProductValidator() 
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Nome do Produto não pode estar vazio");
            RuleFor(product => product.Brand).NotEmpty().WithMessage("Marca do Produto não pode estar vazia");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Preço Inválido");
        }
    }
}
