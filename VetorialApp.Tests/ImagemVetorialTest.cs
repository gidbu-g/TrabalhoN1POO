using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class ImagemVetorialTest
{
    [Fact]
    public void SalvarEmString_ImagemSemFormas_RetornaSoALinhaDaImagem()
    {
        // Arrange
        var imagem = new ImagemVetorial(500, 400);

        // Act
        string resultado = imagem.SalvarEmString();

        // Assert
        Assert.Equal("0;500;400", resultado);
    }

    [Fact]
    public void AdicionarForma_DuasFormas_FicamNaOrdemEmQueForamAdicionadas()
    {
        // Arrange
        var imagem = new ImagemVetorial(500, 400);
        var linha = new Linha(new Ponto(0, 320), new Ponto(500, 320), new Cor(0, 128, 0), 3);
        var retangulo = new Retangulo(new Ponto(150, 180), 200, 140, new Cor(173, 216, 230));

        // Act
        imagem.AdicionarForma(linha);
        imagem.AdicionarForma(retangulo);

        // Assert
        string esperado = "0;500;400" + Environment.NewLine
            + "1;0;320;500;320;0,128,0;3" + Environment.NewLine
            + "2;150;180;200;140;173,216,230";
        Assert.Equal(esperado, imagem.SalvarEmString());
    }

    [Fact]
    public void CarregarDeString_ImagemComTodosOsTiposDeForma_RecriaAImagem()
    {
        // Arrange
        var imagem = new ImagemVetorial();
        string texto = "0;500;400" + Environment.NewLine
            + "1;0;320;500;320;0,128,0;3" + Environment.NewLine
            + "2;150;180;200;140;173,216,230" + Environment.NewLine
            + "3;270;285;5;0,0,0" + Environment.NewLine
            + "4;200;265;180;10;255,0,0" + Environment.NewLine
            + "5;40;120;150;40;260;120;125,125,125" + Environment.NewLine
            + "6;180;360;Dia de Sol;0,0,0";

        // Act
        imagem.CarregarDeString(texto);

        // Assert
        Assert.Equal(texto, imagem.SalvarEmString());
    }

    [Fact]
    public void Desenhar_ImagemComUmaForma_EscreveAStringDaImagemNoConsole()
    {
        // Arrange
        var imagem = new ImagemVetorial(500, 400);
        imagem.AdicionarForma(new Linha(new Ponto(0, 320), new Ponto(500, 320), new Cor(0, 128, 0), 3));
        var saida = new StringWriter();
        Console.SetOut(saida);

        // Act
        imagem.Desenhar();

        // Assert
        string esperado = "0;500;400" + Environment.NewLine
            + "1;0;320;500;320;0,128,0;3" + Environment.NewLine;
        Assert.Equal(esperado, saida.ToString());
    }
}