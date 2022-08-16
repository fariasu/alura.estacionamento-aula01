using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {
        public Patio patio;
        public Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor invocado.");
            patio = new Patio();
            veiculo = new Veiculo();
        }

        [Fact(DisplayName ="Valida faturamento do estacionamento com 1 veículo.")]
        public void ValidaFaturamento()
        {
            //Arrange
            //var patio = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Farias";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Astra";
            veiculo.Placa = "asd-9999";

            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = patio.TotalFaturado();

            //Assert
            Assert.Equal(2,faturamento);
        }

        [Theory(DisplayName ="Valida faturamento do estacionamento com vários veículos.")]
        [InlineData("Pablo", "AAA-1234", "Azul", "Gol")]
        [InlineData("Garcia", "BBB-1234", "Preto", "Corsa")]
        [InlineData("Farias", "CCC-1234", "Branco", "Clio")]
        [InlineData("Fernanda", "DDD-1234", "Roxo", "Volvo")]
        public void ValidaFaturamentoPlus(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            //var patio = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            patio.RegistrarEntradaVeiculo(veiculo);
            patio.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = patio.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory(DisplayName ="Valida a localização de veículos no pátio.")]
        [InlineData("Pablo", "AAA-1234", "Azul", "Gol")]
        public void LocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            //var patio = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            patio.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = patio.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
