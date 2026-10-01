namespace VetorialApp;

public class Poligono : Forma
{
    private List<Ponto> pontos;

    public Poligono() : this(new List<Ponto>(), new Cor())
    {
    }

    public Poligono(List<Ponto> pontos, Cor cor) : base(cor)
    {
        this.pontos = pontos;
    }

    public override string SalvarEmString()
{
    string resultado = "5";

    for (int i = 0; i < pontos.Count; i++)
    {
        resultado += ";" + pontos[i].SalvarEmString();
    }

    resultado += ";" + cor.SalvarEmString();

    return resultado;
}

    public override void CarregarDeString(string texto)
{
    string[] partes = texto.Split(';');
    pontos.Clear();

    for (int i = 1; i < partes.Length - 1; i += 2)
    {
        int x = int.Parse(partes[i]);
        int y = int.Parse(partes[i + 1]);
        pontos.Add(new Ponto(x, y));
    }

    cor.CarregarDeString(partes[partes.Length - 1]);
}
}