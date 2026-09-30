using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class PontoTest
{
    [Fact]
    public void SalvarEmString_PontoComXeY_RetornaCoordenadasSeparadasPorPontoEVirgula()
    {
        // Arrange
        var ponto = new Ponto(20, 260);

        // Act
        string resultado = ponto.SalvarEmString();

        // Assert
        Assert.Equal("20;260", resultado);
    }

    [Fact]
    public void CarregarDeString_StringValida_RecriaOPonto()
    {
        // Arrange
        var ponto = new Ponto();

        // Act
        ponto.CarregarDeString("20;260");

        // Assert
        Assert.Equal("20;260", ponto.SalvarEmString());
    }
}