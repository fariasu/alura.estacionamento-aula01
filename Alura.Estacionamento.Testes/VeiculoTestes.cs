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

        [Fact(DisplayName ="Testa o m�todo Acelerar da classe Ve�culo com o par�metro 10.")]
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

        [Fact(DisplayName = "Testa o m�todo Frear da classe Ve�culo com o par�metro 10.")]
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

        [Fact(DisplayName ="Testa os dois tipos do ve�culo: Autom�vel e Motocicleta.")]
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

        [Fact(Skip ="Teste ainda n�o implementado, ignorar.")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact(DisplayName ="Testa a altera��o de dados do ve�culo.")]
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

        [Fact(DisplayName ="Valida a altera��o de dados do pr�prio ve�culo.")]
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
            Assert.Contains("Ficha do Ve�culo", dados);

        }

        [Fact(DisplayName ="Testa o nome do propriet�rio do ve�culo com menos de 3 caracteres.")]
        public void TestaNomeProprietario()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo(nomeProprietario));
        }

        [Fact(DisplayName ="Testa a mensagem de exce��o do quarto caractere da placa")]
        public void TesteCaracterePlaca()
        {
            //Arrange
            string placa = "ASDF1232";

            //Act
            var mensagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placa
                );

            //Assert
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message); ;
        }
        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}