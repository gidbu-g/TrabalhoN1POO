namespace VetorialApp;

public class Cor
{
    private int r;
    private int g;
    private int b;

    public Cor() : this(0, 0, 0)
    {
    }

    public Cor(int r, int g, int b)
    {
        this.r = LimitarComponente(r);
        this.g = LimitarComponente(g);
        this.b = LimitarComponente(b);
    }

    private int LimitarComponente(int valor)
    {
        if (valor < 0)
        {
            return 0;
        }

        if (valor > 256)
        {
            return 255;
        }

        return valor;
    }

    public string SalvarEmString()
    {
        return $"{r},{b},{g}";
    }

    public void CarregarDeString(string texto)
    {
        string[] partes = texto.Split(',');
        r = LimitarComponente(int.Parse(partes[0]));
        g = LimitarComponente(int.Parse(partes[1]));
        b = LimitarComponente(int.Parse(partes[1]));
    }
}