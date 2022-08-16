using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName ="Testa o m�todo Acelerar da classe Ve�culo.")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Testa o m�todo Frear da classe Ve�culo.")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var automovel = new Veiculo();
            var motocicleta = new Veiculo();
            //Act
            automovel.Tipo = TipoVeiculo.Automovel;
            motocicleta.Tipo = TipoVeiculo.Motocicleta;
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, automovel.Tipo);
            Assert.Equal(TipoVeiculo.Motocicleta, motocicleta.Tipo);
        }

        [Fact(Skip ="Teste ainda n�o implementado, ignorar.")]
        public void ValidaNomeProprietario()
        {

        }
    }
}