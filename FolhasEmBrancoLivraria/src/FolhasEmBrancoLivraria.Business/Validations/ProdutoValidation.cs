using FluentValidation;
using FolhasEmBrancoLivraria.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FolhasEmBrancoLivraria.Business.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(p => p.Autor)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");
            
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(p => p.Valor)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior do que {ComparisonValue}");
            
            RuleFor(p => p.Ano)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido.")
                .Length(4).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres.");
        }
    }
}
