namespace VetorialApp;

public class Linha : Forma
{
    private Ponto inicial;
    private Ponto final;
    private int largura;

    public Linha() : this(new Ponto(), new Ponto(), new Cor(), 1)
    {
    }

    public Linha(Ponto inicial, Ponto final, Cor cor, int largura) : base(cor)
    {
        this.inicial = inicial;
        this.final = final;
        this.largura = LimitarLargura(largura);
    }

    private int LimitarLargura(int valor)
    {
        if (valor < 1)
        {
            return 1;
        }

        return valor;
    }

    public override string SalvarEmString()
    {
        return $"1;{inicial.SalvarEmString()};{final.SalvarEmString()};{cor.SalvarEmString()};{largura}";
    }

    public override void CarregarDeString(string texto)
    {
        string[] partes = texto.Split(';');
        inicial.CarregarDeString($"{partes[1]};{partes[2]}");
        final.CarregarDeString($"{partes[3]};{partes[4]}");
        cor.CarregarDeString(partes[5]);
        largura = LimitarLargura(int.Parse(partes[6]));
    }
}