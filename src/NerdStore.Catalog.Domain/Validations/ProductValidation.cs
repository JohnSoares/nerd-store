using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Catalog.Domain.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public static string NameNotEmptyMsg => "O campo Nome do produto não pode estar vazio";
        public static string NameMaxLengthMsg => "O campo Nome do produto só pode ter no máximo 256 caracteres";
        public static string DescriptionNotEmptyMsg => "O campo Descrição do produto não pode estar vazio";
        public static string DescriptionMaxLengthMsg => "O campo Descrição do produto só pode ter no máximo 500 caracteres";
        public static string CategoryIdNotEmptyMsg => "O campo CategoriaId não pode estar vazio";
        public static string ValueNotEmptyMsg => "O campo Valor do produto não pode ser menor ou igual a 0";
        public static string ImageIdNotEmptyMsg => "O campo ImagemId do produto não pode estar vazio";
        
        public ProductValidation()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage(NameNotEmptyMsg)
                .MaximumLength(256)
                .WithMessage(NameMaxLengthMsg);

            RuleFor(f => f.Description)
                .NotEmpty().WithMessage(DescriptionNotEmptyMsg)
                .MaximumLength(500)
                .WithMessage(DescriptionMaxLengthMsg);

            RuleFor(f => f.CategoryId).Equal(Guid.Empty)
                .WithMessage(CategoryIdNotEmptyMsg);

            RuleFor(f => f.Value).LessThanOrEqualTo(0)
                .WithMessage(ValueNotEmptyMsg);

            RuleFor(f => f.ImageId).Equal(Guid.Empty)
                .WithMessage(ImageIdNotEmptyMsg);
        }
    }
}
