using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class FormaTest
{
    [Fact]
    public void Desenhar_FormaQualquer_EscreveNoConsoleAStringDaFormaComQuebraDeLinha()
    {
        // Arrange
        Forma forma = new Linha(new Ponto(20, 260), new Ponto(380, 260), new Cor(0, 255, 0), 2);
        var saida = new StringWriter();
        Console.SetOut(saida);

        // Act
        forma.Desenhar();

        // Assert
        Assert.Equal("1;20;260;380;260;0,255,0;2" + Environment.NewLine, saida.ToString());
    }
}