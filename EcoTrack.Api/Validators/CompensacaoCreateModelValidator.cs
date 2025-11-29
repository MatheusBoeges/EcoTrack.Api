using EcoTrack.Api.Views.Compesacao;
using FluentValidation;

public class CompensacaoCreateModelValidator : AbstractValidator<CompensacaoCreateModel>
{
    public CompensacaoCreateModelValidator()
    {
        RuleFor(x => x.AtividadeId).GreaterThan(0);
        RuleFor(x => x.QtdCo2Compensado).GreaterThan(0);
        RuleFor(x => x.Referencia).MaximumLength(200);
    }
}
