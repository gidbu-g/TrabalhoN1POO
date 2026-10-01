namespace VetorialApp;

public class Elipse : Forma
{
    private Ponto centro;
    private int raioHorizontal;
    private int raioVertical;

    public Elipse() : this(new Ponto(), 0, 0, new Cor())
    {
    }

    public Elipse(Ponto centro, int raioHorizontal, int raioVertical, Cor cor) : base(cor)
    {
        this.centro = centro;
        this.raioHorizontal = raioHorizontal;
        this.raioVertical = raioVertical;
    }

    public override string SalvarEmString()
    {
        return $"4;{centro.SalvarEmString()};{raioHorizontal};{raioVertical};{cor.SalvarEmString()}";
    }

    public override void CarregarDeString(string texto)
    {
        string[] partes = texto.Split(';');
        centro.CarregarDeString($"{partes[1]};{partes[2]}");
        raioHorizontal = int.Parse(partes[3]);
        raioVertical = int.Parse(partes[4]);
        cor.CarregarDeString(partes[5]);
    }
}