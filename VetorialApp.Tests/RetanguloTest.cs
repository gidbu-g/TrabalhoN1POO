using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class RetanguloTest
{
    [Fact]
    public void SalvarEmString_RetanguloAzul_RetornaTipo2ComTodosOsCampos()
    {
        // Arrange
        var retangulo = new Retangulo(new Ponto(50, 120), 200, 140, new Cor(0, 0, 255));

        // Act
        string resultado = retangulo.SalvarEmString();

        // Assert
        Assert.Equal("2;50;120;200;140;0,0,255", resultado);
    }

    [Fact]
    public void CarregarDeString_StringValida_RecriaORetangulo()
    {
        // Arrange
        var retangulo = new Retangulo();

        // Act
        retangulo.CarregarDeString("2;50;120;200;140;0,0,255");

        // Assert
        Assert.Equal("2;50;120;200;140;0,0,255", retangulo.SalvarEmString());
    }

    [Fact]
    public void Desenhar_RetanguloValido_EscreveAStringDoRetanguloNoConsole()
    {
        // Arrange
        var retangulo = new Retangulo(new Ponto(50, 120), 200, 140, new Cor(0, 0, 255));
        var saida = new StringWriter();
        Console.SetOut(saida);

        // Act
        retangulo.Desenhar();

        // Assert
        Assert.Equal("2;50;120;200;140;0,0,255" + Environment.NewLine, saida.ToString());
    }
}