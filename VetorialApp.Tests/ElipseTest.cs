using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class ElipseTest
{
    [Fact]
    public void SalvarEmString_ElipseVermelha_RetornaTipo4ComTodosOsCampos()
    {
        // Arrange
        var elipse = new Elipse(new Ponto(200, 265), 180, 10, new Cor(255, 0, 0));

        // Act
        string resultado = elipse.SalvarEmString();

        // Assert
        Assert.Equal("4;200;265;180;10;255,0,0", resultado);
    }

    [Fact]
    public void CarregarDeString_StringValida_RecriaAElipse()
    {
        // Arrange
        var elipse = new Elipse();

        // Act
        elipse.CarregarDeString("4;200;265;180;10;255,0,0");

        // Assert
        Assert.Equal("4;200;265;180;10;255,0,0", elipse.SalvarEmString());
    }

    [Fact]
    public void Desenhar_ElipseValida_EscreveAStringDaElipseNoConsole()
    {
        // Arrange
        var elipse = new Elipse(new Ponto(200, 265), 180, 10, new Cor(255, 0, 0));
        var saida = new StringWriter();
        Console.SetOut(saida);

        // Act
        elipse.Desenhar();

        // Assert
        Assert.Equal("4;200;265;180;10;255,0,0" + Environment.NewLine, saida.ToString());
    }
}