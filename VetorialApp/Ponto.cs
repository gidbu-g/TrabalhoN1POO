namespace VetorialApp;

public class Ponto
{
    private int x;
    private int y;

    public Ponto() : this(0, 0)
    {
    }

    public Ponto(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public string SalvarEmString()
    {
        return $"{x};{y}";
    }

    public void CarregarDeString(string texto)
    {
        string[] partes = texto.Split(';');
        x = int.Parse(partes[0]);
        y = int.Parse(partes[1]);
    }
}