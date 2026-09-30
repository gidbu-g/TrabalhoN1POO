namespace VetorialApp;

public class Retangulo : Forma
{
    private Ponto posicao;
    private int largura;
    private int altura;

    public Retangulo() : this(new Ponto(), 0, 0, new Cor())
    {
    }

    public Retangulo(Ponto posicao, int largura, int altura, Cor cor) : base(cor)
    {
        this.posicao = posicao;
        this.largura = largura;
        this.altura = altura;
    }

    public override string SalvarEmString()
    {
        return $"2;{posicao.SalvarEmString()};{largura};{altura};{cor.SalvarEmString()}";
    }

    public override void CarregarDeString(string texto)
    {
        string[] partes = texto.Split(';');
        posicao.CarregarDeString($"{partes[1]};{partes[2]}");
        largura = int.Parse(partes[3]);
        altura = int.Parse(partes[4]);
        cor.CarregarDeString(partes[5]);
    }
}