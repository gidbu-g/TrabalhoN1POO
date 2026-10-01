using VetorialApp;
using Xunit;

namespace VetorialApp.Tests;

public class TestesBasicosTest
{
    private static readonly string TextoParque = "0;600;400" + Environment.NewLine
        + "3;520;80;40;255,255,0" + Environment.NewLine
        + "4;120;70;55;25;255,255,255" + Environment.NewLine
        + "5;0;300;150;140;300;300;128,128,128" + Environment.NewLine
        + "1;0;300;600;300;34,139,34;4" + Environment.NewLine
        + "2;430;230;30;70;139,69,19" + Environment.NewLine
        + "3;445;200;55;0,128,0" + Environment.NewLine
        + "6;200;350;Parque da Cidade;0,0,0";

    private ImagemVetorial MontarImagemParque()
    {
        var imagem = new ImagemVetorial(600, 400);

        imagem.AdicionarForma(new Circulo(new Ponto(520, 80), 40, new Cor(255, 255, 0)));
        imagem.AdicionarForma(new Elipse(new Ponto(120, 70), 55, 25, new Cor(255, 255, 255)));

        var pontos = new List<Ponto>
        {
            new Ponto(0, 300),
            new Ponto(150, 140),
            new Ponto(300, 300)
        };
        imagem.AdicionarForma(new Poligono(pontos, new Cor(128, 128, 128)));

        imagem.AdicionarForma(new Linha(new Ponto(0, 300), new Ponto(600, 300), new Cor(34, 139, 34), 4));
        imagem.AdicionarForma(new Retangulo(new Ponto(430, 230), 30, 70, new Cor(139, 69, 19)));
        imagem.AdicionarForma(new Circulo(new Ponto(445, 200), 55, new Cor(0, 128, 0)));
        imagem.AdicionarForma(new Texto(new Ponto(200, 350), "Parque da Cidade", new Cor(0, 0, 0)));

        return imagem;
    }

    [Fact]
    public void SalvarEmString_LinhaVermelha_RetornaTipo1ComTodosOsCampos()
    {
        // Arrange
        var linha = new Linha(new Ponto(10, 90), new Ponto(250, 90), new Cor(255, 0, 0), 5);

        // Act
        string resultado = linha.SalvarEmString();

        // Assert
        Assert.Equal("1;10;90;250;90;255,0,0;5", resultado);
    }

    [Fact]
    public void SalvarEmString_RetanguloVerde_RetornaTipo2ComTodosOsCampos()
    {
        // Arrange
        var retangulo = new Retangulo(new Ponto(80, 40), 120, 60, new Cor(0, 255, 0));

        // Act
        string resultado = retangulo.SalvarEmString();

        // Assert
        Assert.Equal("2;80;40;120;60;0,255,0", resultado);
    }

    [Fact]
    public void SalvarEmString_CirculoLaranja_RetornaTipo3ComTodosOsCampos()
    {
        // Arrange
        var circulo = new Circulo(new Ponto(200, 150), 45, new Cor(255, 128, 0));

        // Act
        string resultado = circulo.SalvarEmString();

        // Assert
        Assert.Equal("3;200;150;45;255,128,0", resultado);
    }

    [Fact]
    public void SalvarEmString_ElipseBranca_RetornaTipo4ComTodosOsCampos()
    {
        // Arrange
        var elipse = new Elipse(new Ponto(150, 120), 80, 35, new Cor(255, 255, 255));

        // Act
        string resultado = elipse.SalvarEmString();

        // Assert
        Assert.Equal("4;150;120;80;35;255,255,255", resultado);
    }

    [Fact]
    public void SalvarEmString_PoligonoAzul_RetornaTipo5ComTodosOsCampos()
    {
        // Arrange
        var pontos = new List<Ponto>
        {
            new Ponto(10, 10),
            new Ponto(110, 10),
            new Ponto(60, 90)
        };
        var poligono = new Poligono(pontos, new Cor(0, 0, 255));

        // Act
        string resultado = poligono.SalvarEmString();

        // Assert
        Assert.Equal("5;10;10;110;10;60;90;0,0,255", resultado);
    }

    [Fact]
    public void SalvarEmString_TextoPreto_RetornaTipo6ComTodosOsCampos()
    {
        // Arrange
        var texto = new Texto(new Ponto(30, 200), "Bom Dia", new Cor(0, 0, 0));

        // Act
        string resultado = texto.SalvarEmString();

        // Assert
        Assert.Equal("6;30;200;Bom Dia;0,0,0", resultado);
    }

    [Fact]
    public void CarregarDeString_StringDeLinha_RecriaALinhaEsperada()
    {
        // Arrange
        var esperada = new Linha(new Ponto(10, 90), new Ponto(250, 90), new Cor(255, 0, 0), 5);
        var carregada = new Linha();

        // Act
        carregada.CarregarDeString("1;10;90;250;90;255,0,0;5");

        // Assert
        Assert.Equal(esperada.SalvarEmString(), carregada.SalvarEmString());
    }

    [Fact]
    public void CarregarDeString_StringDeRetangulo_RecriaORetanguloEsperado()
    {
        // Arrange
        var esperado = new Retangulo(new Ponto(80, 40), 120, 60, new Cor(0, 255, 0));
        var carregado = new Retangulo();

        // Act
        carregado.CarregarDeString("2;80;40;120;60;0,255,0");

        // Assert
        Assert.Equal(esperado.SalvarEmString(), carregado.SalvarEmString());
    }

    [Fact]
    public void CarregarDeString_StringDeCirculo_RecriaOCirculoEsperado()
    {
        // Arrange
        var esperado = new Circulo(new Ponto(200, 150), 45, new Cor(255, 128, 0));
        var carregado = new Circulo();

        // Act
        carregado.CarregarDeString("3;200;150;45;255,128,0");

        // Assert
        Assert.Equal(esperado.SalvarEmString(), carregado.SalvarEmString());
    }

    [Fact]
    public void CarregarDeString_StringDeElipse_RecriaAElipseEsperada()
    {
        // Arrange
        var esperada = new Elipse(new Ponto(150, 120), 80, 35, new Cor(255, 255, 255));
        var carregada = new Elipse();

        // Act
        carregada.CarregarDeString("4;150;120;80;35;255,255,255");

        // Assert
        Assert.Equal(esperada.SalvarEmString(), carregada.SalvarEmString());
    }

    [Fact]
    public void CarregarDeString_StringDePoligono_RecriaOPoligonoEsperado()
    {
        // Arrange
        var pontos = new List<Ponto>
        {
            new Ponto(10, 10),
            new Ponto(110, 10),
            new Ponto(60, 90)
        };
        var esperado = new Poligono(pontos, new Cor(0, 0, 255));
        var carregado = new Poligono();

        // Act
        carregado.CarregarDeString("5;10;10;110;10;60;90;0,0,255");

        // Assert
        Assert.Equal(esperado.SalvarEmString(), carregado.SalvarEmString());
    }

    [Fact]
    public void CarregarDeString_StringDeTexto_RecriaOTextoEsperado()
    {
        // Arrange
        var esperado = new Texto(new Ponto(30, 200), "Bom Dia", new Cor(0, 0, 0));
        var carregado = new Texto();

        // Act
        carregado.CarregarDeString("6;30;200;Bom Dia;0,0,0");

        // Assert
        Assert.Equal(esperado.SalvarEmString(), carregado.SalvarEmString());
    }

    [Fact]
    public void SalvarEmString_ImagemParqueDaCidade_RetornaTodasAsLinhasNaOrdem()
    {
        // Arrange
        ImagemVetorial imagem = MontarImagemParque();

        // Act
        string resultado = imagem.SalvarEmString();

        // Assert
        Assert.Equal(TextoParque, resultado);
    }

    [Fact]
    public void CarregarDeString_ImagemParqueDaCidade_RecriaAImagemEsperada()
    {
        // Arrange
        ImagemVetorial esperada = MontarImagemParque();
        var carregada = new ImagemVetorial();

        // Act
        carregada.CarregarDeString(TextoParque);

        // Assert
        Assert.Equal(esperada.SalvarEmString(), carregada.SalvarEmString());
    }
}