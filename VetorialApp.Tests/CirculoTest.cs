using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class CirculoTest
{
    [Fact]
    public void SalvarEmString_CirculoAmarelo_RetornaTipo3ComTodosOsCampos()
    {
        // Arrange
        var circulo = new Circulo(new Ponto(330, 60), 30, new Cor(255, 255, 0));

        // Act
        string resultado = circulo.SalvarEmString();

        // Assert
        Assert.Equal("3;330;60;30;255,255,0", resultado);
    }

    [Fact]
    public void CarregarDeString_StringValida_RecriaOCirculo()
    {
        // Arrange
        var circulo = new Circulo();

        // Act
        circulo.CarregarDeString("3;330;60;30;255,255,0");

        // Assert
        Assert.Equal("3;330;60;30;255,255,0", circulo.SalvarEmString());
    }

    [Fact]
    public void Desenhar_CirculoValido_EscreveAStringDoCirculoNoConsole()
    {
        // Arrange
        var circulo = new Circulo(new Ponto(330, 60), 30, new Cor(255, 255, 0));
        var saida = new StringWriter();
        Console.SetOut(saida);

        // Act
        circulo.Desenhar();

        // Assert
        Assert.Equal("3;330;60;30;255,255,0" + Environment.NewLine, saida.ToString());
    }
}