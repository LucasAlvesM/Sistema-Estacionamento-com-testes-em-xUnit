using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes:IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
           saidaConsoleTeste.WriteLine("Construtorr Invocado.");
           veiculo = new Veiculo();
        }

        [Fact (DisplayName = "Teste n 1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact (DisplayName = "Teste n 2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);

        }

        [Fact(DisplayName = "Teste n 3", Skip = "teste ainda não implementado. ignorar")]
        [Trait("Funcionalidade", "Validar Proprietário")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }
      
        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //arange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Carol Lina";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "EAR-4737";
            veiculo.Modelo = "Corvette";

            //act
            string dados = veiculo.ToString();

            //assert
            Assert.Contains("Ficha do Veículo:", dados);

        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose Invocado.");
        }

        [Fact]

        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            string nomeProprietario = "Ab";

            Assert.Throws<System.FormatException>(
                () => new Veiculo(nomeProprietario)

            );
        }

        [Fact]

        public void TestaMenssagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //arrange
            string placa = "ASDF9777";

            //act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );
            //assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        [Fact]
        public void TestaUltimosCaracteresPlacaVeiculoComoNumeros()
        {
            //arrange
            string placaFormatoErrado = "ASD-995U";

            //assert
            Assert.Throws<FormatException>(
                //act
                () => new Veiculo().Placa = placaFormatoErrado
            );

        }

    }

   
}
