using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class TextoTest
{
    [Fact]
    public void SalvarEmString_TextoPreto_RetornaTipo6ComTodosOsCampos()
    {
        // Arrange
        var texto = new Texto(new Ponto(145, 292), "Minha Casa", new Cor(0, 0, 0));

        // Act
        string resultado = texto.SalvarEmString();

        // Assert
        Assert.Equal("6;145;292;Minha Casa;0,0,0", resultado);
    }

    [Fact]
    public void CarregarDeString_StringValida_RecriaOTexto()
    {
        // Arrange
        var texto = new Texto();

        // Act
        texto.CarregarDeString("6;145;292;Minha Casa;0,0,0");

        // Assert
        Assert.Equal("6;145;292;Minha Casa;0,0,0", texto.SalvarEmString());
    }

    [Fact]
    public void Desenhar_TextoValido_EscreveAStringDoTextoNoConsole()
    {
        // Arrange
        var texto = new Texto(new Ponto(145, 292), "Minha Casa", new Cor(0, 0, 0));
        var saida = new StringWriter();
        Console.SetOut(saida);

        // Act
        texto.Desenhar();

        // Assert
        Assert.Equal("6;145;292;Minha Casa;0,0,0" + Environment.NewLine, saida.ToString());
    }
}