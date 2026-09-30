namespace VetorialApp;

public class Circulo : Forma
{
    private Ponto centro;
    private int raio;

    public Circulo() : this(new Ponto(), 0, new Cor())
    {
    }

    public Circulo(Ponto centro, int raio, Cor cor) : base(cor)
    {
        this.centro = centro;
        this.raio = raio;
    }

    public override string SalvarEmString()
    {
        return $"3;{centro.SalvarEmString()};{raio};{cor.SalvarEmString()}";
    }

    public override void CarregarDeString(string texto)
    {
        string[] partes = texto.Split(';');
        centro.CarregarDeString($"{partes[1]};{partes[2]}");
        raio = int.Parse(partes[3]);
        cor.CarregarDeString(partes[4]);
    }
}