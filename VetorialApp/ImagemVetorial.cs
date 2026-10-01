namespace VetorialApp;

public class ImagemVetorial
{
    private int largura;
    private int altura;
    private List<Forma> formas;

    public ImagemVetorial() : this(0, 0)
    {
    }

    public ImagemVetorial(int largura, int altura)
    {
        this.largura = largura;
        this.altura = altura;
        formas = new List<Forma>();
    }

    public void AdicionarForma(Forma forma)
    {
        formas.Add(forma);
    }

    public void Desenhar()
    {
        Console.WriteLine(SalvarEmString());
    }

    public string SalvarEmString()
    {
        string resultado = $"0;{largura};{altura}";

        foreach (Forma forma in formas)
        {
            resultado += Environment.NewLine + forma.SalvarEmString();
        }

        return resultado;
    }

    public void CarregarDeString(string texto)
    {
        string[] linhas = texto.Split('\n');
        string[] cabecalho = linhas[0].Trim().Split(';');
        largura = int.Parse(cabecalho[1]);
        altura = int.Parse(cabecalho[2]);
        formas.Clear();

        for (int i = 1; i < linhas.Length; i++)
        {
            string linha = linhas[i].Trim();

            if (linha != "")
            {
                Forma? forma = CriarForma(linha.Split(';')[0]);

                if (forma != null)
                {
                    forma.CarregarDeString(linha);
                    formas.Add(forma);
                }
            }
        }
    }

    private Forma? CriarForma(string tipo)
    {
        if (tipo == "1")
        {
            return new Linha();
        }

        if (tipo == "2")
        {
            return new Retangulo();
        }

        if (tipo == "3")
        {
            return new Circulo();
        }

        if (tipo == "4")
        {
            return new Elipse();
        }

        if (tipo == "5")
        {
            return new Poligono();
        }

        if (tipo == "6")
        {
            return new Texto();
        }

        return null;
    }
}