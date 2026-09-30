using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class LinhaTest
{
    [Fact]
    public void SalvarEmString_LinhaVerde_RetornaTipo1ComTodosOsCampos()
    {
        // Arrange
        var linha = new Linha(new Ponto(20, 260), new Ponto(380, 260), new Cor(0, 255, 0), 2);

        // Act
        string resultado = linha.SalvarEmString();

        // Assert
        Assert.Equal("1;20;260;380;260;0,255,0;2", resultado);
    }

    [Fact]
    public void CarregarDeString_StringValida_RecriaALinha()
    {
        // Arrange
        var linha = new Linha();

        // Act
        linha.CarregarDeString("1;20;260;380;260;0,255,0;2");

        // Assert
        Assert.Equal("1;20;260;380;260;0,255,0;2", linha.SalvarEmString());
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(-3, 1)]
    [InlineData(1, 1)]
    [InlineData(5, 5)]
    public void Construtor_LarguraDaLinha_NuncaFicaMenorQue1(int informada, int esperada)
    {
        // Arrange
        var linha = new Linha(new Ponto(0, 0), new Ponto(10, 10), new Cor(0, 0, 0), informada);

        // Act
        string resultado = linha.SalvarEmString();

        // Assert
        Assert.Equal($"1;0;0;10;10;0,0,0;{esperada}", resultado);
    }

    [Fact]
    public void Desenhar_LinhaValida_EscreveAStringDaLinhaNoConsole()
    {
        // Arrange
        var linha = new Linha(new Ponto(20, 260), new Ponto(380, 260), new Cor(0, 255, 0), 2);
        var saida = new StringWriter();
        Console.SetOut(saida);

        // Act
        linha.Desenhar();

        // Assert
        Assert.Equal("1;20;260;380;260;0,255,0;2" + Environment.NewLine, saida.ToString());
    }
}