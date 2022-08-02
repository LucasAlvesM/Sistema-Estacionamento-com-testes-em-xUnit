using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste:IDisposable
    {
        
        private Veiculo veiculo;
        private Operador operador;
        public ITestOutputHelper saidaConsoleTeste;

        public PatioTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtorr Invocado.");
            veiculo = new Veiculo();

            operador = new Operador();
            operador.Nome = "Julio Garcia";
        }
        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //arrange
            var estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            //Operador operador = new Operador();
            //operador.Nome = "Julio Garcia";
            //estacionamento.OperadorPatio = operador;

            // var veiculo = new Veiculo();


            veiculo.Proprietario = "Lucas Alves";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul Ultra";
            veiculo.Modelo = "Mercedez Benz Slr";
            veiculo.Placa = "AVZ-8734";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);


        }

        [Theory]
        [InlineData("Marcela Moreira", "ASD-3632", "Roxo", "Gol")]
        [InlineData("Pedro Silva ", "WEQ-0283", "Rosa", "CamaroSS")]
        [InlineData("Julia Oliveira", "UIW-3478", "Amarelo", "Fusca")]
        [InlineData("Camila Alves", "UED-7543", "Preto", "BMW")]


        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario,
                                                                       string placa,
                                                                       string cor,
                                                                       string modelo)
        {
            //arrange
            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            //var veiculo = new Veiculo
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Marcela Moreira", "ASD-3632", "Roxo", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(string proprietario,
                                                         string placa,
                                                         string cor,
                                                         string modelo)
                                            
        {
            //arrange
            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //assert
            Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //arrange
            Patio estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Lucas Alves";
            veiculo.Placa = "HSF-3672";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Camaro";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Lucas Alves";
            veiculoAlterado.Placa = "HSF-3672";
            veiculoAlterado.Cor = "Roxo";
            veiculoAlterado.Modelo = "Porsche";

            //act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
            
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose Invocado.");
        }
    }
}
