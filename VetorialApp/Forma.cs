namespace VetorialApp;

public abstract class Forma
{
    protected Cor cor;

    protected Forma(Cor cor)
    {
        this.cor = cor;
    }

    public abstract string SalvarEmString();

    public abstract void CarregarDeString(string texto);

    public void Desenhar()
    {
        Console.WriteLine(SalvarEmString());
    }
}