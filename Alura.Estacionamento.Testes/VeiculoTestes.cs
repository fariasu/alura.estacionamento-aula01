using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper saidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            saidaConsoleTeste = _saidaConsoleTeste;
            saidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact(DisplayName ="Testa o método Acelerar da classe Veículo com o parâmetro 10.")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarC()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Testa o método Frear da classe Veículo com o parâmetro 10.")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName ="Testa os dois tipos do veículo: Automóvel e Motocicleta.")]
        public void TestaTipoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            var motocicleta = new Veiculo();
            //Act
            veiculo.Tipo = TipoVeiculo.Automovel;
            motocicleta.Tipo = TipoVeiculo.Motocicleta;
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
            Assert.Equal(TipoVeiculo.Motocicleta, motocicleta.Tipo);
        }

        [Fact(Skip ="Teste ainda não implementado, ignorar.")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact(DisplayName ="Testa a alteração de dados do veículo.")]
        public void AlterarDadosVeiculo()
        {
            //Arrange
            var patio = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Farias";
            veiculo.Placa = "AAA-1234";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Corsa";

            patio.RegistrarEntradaVeiculo(veiculo);

            //Act
            Veiculo alterado = patio.AlterarDadosVeiculo(veiculo);

            //Assert
            Assert.Equal(alterado.Cor, veiculo.Cor);
        }

        [Fact(DisplayName ="Valida a alteração de dados do próprio veículo.")]
        public void DadosVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Farias";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "AAA-1234";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Corsa";

            //Act
            var dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo", dados);

        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Construtor invocado.");
        }
    }
}