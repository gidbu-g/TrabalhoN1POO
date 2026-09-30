using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class CorTest
{
    [Fact]
    public void SalvarEmString_CorLaranja_RetornaRGBSeparadosPorVirgula()
    {
        // Arrange
        var cor = new Cor(255, 128, 0);

        // Act
        string resultado = cor.SalvarEmString();

        // Assert
        Assert.Equal("255,128,0", resultado);
    }

    [Fact]
    public void CarregarDeString_StringValida_RecriaACor()
    {
        // Arrange
        var cor = new Cor();

        // Act
        cor.CarregarDeString("255,128,0");

        // Assert
        Assert.Equal("255,128,0", cor.SalvarEmString());
    }

    [Theory]
    [InlineData(-5, 0)]
    [InlineData(0, 0)]
    [InlineData(255, 255)]
    [InlineData(256, 255)]
    [InlineData(300, 255)]
    public void Construtor_ComponenteVermelho_FicaEntre0e255(int informado, int esperado)
    {
        // Arrange
        var cor = new Cor(informado, 0, 0);

        // Act
        string resultado = cor.SalvarEmString();

        // Assert
        Assert.Equal($"{esperado},0,0", resultado);
    }
}