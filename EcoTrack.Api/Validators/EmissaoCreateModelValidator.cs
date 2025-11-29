using EcoTrack.Api.Views.Emissao;
using FluentValidation;

public class EmissaoCreateModelValidator : AbstractValidator<EmissaoCreateModel>
{
    public EmissaoCreateModelValidator()
    {
        RuleFor(x => x.AtividadeId).GreaterThan(0);
        RuleFor(x => x.QtdCo2).GreaterThan(0).WithMessage("Quantidade de CO2 deve ser maior que zero.");
        RuleFor(x => x.MetodoCalculo).MaximumLength(200);
    }
}
