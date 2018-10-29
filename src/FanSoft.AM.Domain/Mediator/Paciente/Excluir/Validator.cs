using FluentValidation;

namespace FanSoft.AM.Domain.Mediator.Paciente.Excluir
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id é obrigatório");
        }
    }
}
