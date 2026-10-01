using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class PoligonoTest
{
    [Fact]
    public void SalvarEmString_TrianguloCinza_RetornaTipo5ComTodosOsPontosECor()
    {
        // Arrange
        var pontos = new List<Ponto>
        {
            new Ponto(40, 120),
            new Ponto(150, 40),
            new Ponto(260, 120)
        };
        var poligono = new Poligono(pontos, new Cor(125, 125, 125));

        // Act
        string resultado = poligono.SalvarEmString();

        // Assert
        Assert.Equal("5;40;120;150;40;260;120;125,125,125", resultado);
    }

    [Fact]
    public void CarregarDeString_Triangulo_RecriaOPoligono()
    {
        // Arrange
        var poligono = new Poligono();

        // Act
        poligono.CarregarDeString("5;40;120;150;40;260;120;125,125,125");

        // Assert
        Assert.Equal("5;40;120;150;40;260;120;125,125,125", poligono.SalvarEmString());
    }

    [Fact]
    public void CarregarDeString_PoligonoComQuatroPontos_RecriaOPoligono()
    {
        // Arrange
        var poligono = new Poligono();

        // Act
        poligono.CarregarDeString("5;0;0;100;0;100;50;0;50;0,0,255");

        // Assert
        Assert.Equal("5;0;0;100;0;100;50;0;50;0,0,255", poligono.SalvarEmString());
    }

    [Fact]
    public void Desenhar_PoligonoValido_EscreveAStringDoPoligonoNoConsole()
    {
        // Arrange
        var pontos = new List<Ponto>
        {
            new Ponto(40, 120),
            new Ponto(150, 40),
            new Ponto(260, 120)
        };
        var poligono = new Poligono(pontos, new Cor(125, 125, 125));
        var saida = new StringWriter();
        Console.SetOut(saida);

        // Act
        poligono.Desenhar();

        // Assert
        Assert.Equal("5;40;120;150;40;260;120;125,125,125" + Environment.NewLine, saida.ToString());
    }
}