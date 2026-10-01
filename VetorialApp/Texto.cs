namespace VetorialApp;

public class Texto : Forma
{
    private Ponto posicao;
    private string conteudo;

    public Texto() : this(new Ponto(), "", new Cor())
    {
    }

    public Texto(Ponto posicao, string conteudo, Cor cor) : base(cor)
    {
        this.posicao = posicao;
        this.conteudo = conteudo;
    }

    public override string SalvarEmString()
    {
       return $"6;{posicao.SalvarEmString()};{conteudo};{cor.SalvarEmString()}";
    }

    public override void CarregarDeString(string texto)
    {
        string[] partes = texto.Split(';');
        posicao.CarregarDeString($"{partes[1]};{partes[2]}");
        conteudo = partes[3];
        cor.CarregarDeString(partes[4]);
    }
}