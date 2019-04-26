using FluentValidation;

namespace WebApi.Model
{
    public class InputModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public string TipoUsuario { get; set; }
        public string Descricao { get; set; }
    }

    public class InputModelValidator : AbstractValidator<InputModel>
    {
        public InputModelValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("O Id deve ser maior que zero");

            RuleFor(x => x.Nome)
                .NotNull()
                .Length(5, 50)
                .WithMessage("O nome deve conter entre 5 e 50 caracteres");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotNull()
                .WithMessage("Informe um email válido");

            RuleFor(x => x.Idade)
                .InclusiveBetween(18, 100)
                .WithMessage("A idade de ser entre 18 e 100");

            //validação condicional. Se o TipoUsuario == adm inserir a descrição
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .When(x => x.TipoUsuario.ToLower() == "adm")
                .WithMessage("Informe a descrição do usuário");
        }
    }
}
