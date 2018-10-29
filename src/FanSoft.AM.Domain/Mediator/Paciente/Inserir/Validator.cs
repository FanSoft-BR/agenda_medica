using FluentValidation;

namespace FanSoft.AM.Domain.Mediator.Paciente.Inserir
{
    public class Validator : AbstractValidator<Request>
    {

        public Validator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(1, 80).WithMessage("Nome não pode ser maior que 80 caracteres");

            RuleFor(x => x.Sobrenome)
                .NotEmpty().WithMessage("Sobrenome é obrigatório")
                .Length(1, 80).WithMessage("SobreNome não pode ser maior que 80 caracteres");

            RuleFor(x => x.SexoId)
                .NotEmpty().WithMessage("Sexo é obrigatório");

            RuleFor(x => x.Nascimento)
                .NotEmpty().WithMessage("Nascimento é obrigatório");

        }
    }
}
