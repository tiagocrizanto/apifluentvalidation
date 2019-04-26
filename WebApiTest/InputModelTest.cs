using FluentValidation.TestHelper;
using WebApi.Model;
using Xunit;

namespace WebApiTest
{
    public class InputModelTest
    {
        InputModelValidator validation = new InputModelValidator();

        [Fact]
        public void IdMenorOuIgualZeroUsuarioNaoAdm_RetornaErro()
        {
            var input = new InputModel { Id = 0, TipoUsuario = "a" };
            validation.ShouldHaveValidationErrorFor(m => m.Id, input);
        }

        [Fact]
        public void IdMaiorZeroUsuarioNaoAdm_NaoRetornaErro()
        {
            var input = new InputModel { Id = 1, TipoUsuario = "a" };
            validation.ShouldNotHaveValidationErrorFor(m => m.Id, input);
        }

        [Fact]
        public void NomeObrigatorioUsuarioNaoAdm_RetornaErro()
        {
            var input = new InputModel { Id = 1, TipoUsuario = "a" };

            validation.ShouldHaveValidationErrorFor(m => m.Nome, input);
        }

        [Fact]
        public void DescricaoObrigatoriaUsuarioAdm_RetornaErro()
        {
            var input = new InputModel { Id = 1, TipoUsuario = "adm" };

            validation.ShouldHaveValidationErrorFor(m => m.Descricao, input);
        }

        [Fact]
        public void DescricaoObrigatoriaUsuarioAdm_NaoRetornaErro()
        {
            var input = new InputModel { Id = 1, TipoUsuario = "adm", Descricao = "descrição" };

            validation.ShouldNotHaveValidationErrorFor(m => m.Descricao, input);
        }
    }
}
