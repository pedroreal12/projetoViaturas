using System;
using System.Collections.Generic;

class Viatura
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Matricula { get; set; }
    public double CustoPorKm { get; set; }
    public double PesoMax { get; set; }
    public double AlturaMax { get; set; }
    public double LarguraMax { get; set; }
    public double ProfundidadeMax { get; set; }

    public Viatura(string marca, string modelo, string matricula, double custoPorKm, double pesoMax, double alturaMax, double larguraMax, double profundidadeMax)
    {
        Marca = marca;
        Modelo = modelo;
        Matricula = matricula;
        CustoPorKm = custoPorKm;
        PesoMax = pesoMax;
        AlturaMax = alturaMax;
        LarguraMax = larguraMax;
        ProfundidadeMax = profundidadeMax;
    }

    public override string ToString()
    {
        return $"Viatura: {Marca} {Modelo}\nMatrícula: {Matricula}\nCusto por km: {CustoPorKm}\n" +
               $"Peso máximo: {PesoMax} Kg\nDimensões máximas (LxPxA): {LarguraMax}x{ProfundidadeMax}x{AlturaMax}\n";
    }
}

class Encomenda
{
    public double Peso { get; set; }
    public double Altura { get; set; }
    public double Largura { get; set; }
    public double Profundidade { get; set; }

    public Encomenda(double peso, double altura, double largura, double profundidade)
    {
        Peso = peso;
        Altura = altura;
        Largura = largura;
        Profundidade = profundidade;
    }

    public override string ToString()
    {
        return $"Encomenda: peso={Peso} kg, dimensões (LxPxA)={Largura}x{Profundidade}x{Altura}\n";
    }
}

class Transporte
{
    public Viatura Viatura { get; set; }
    public Encomenda Encomenda { get; set; }

    public Transporte(Viatura viatura, Encomenda encomenda)
    {
        Viatura = viatura;
        Encomenda = encomenda;
    }

    public override string ToString()
    {
        return $"Transporte:\n{Encomenda}\n{Viatura}\n";
    }
}

class Transportadora
{
    static List<Viatura> viaturas = new List<Viatura>();
    static List<Transporte> transportes = new List<Transporte>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Adicionar viatura");
            Console.WriteLine("2 - Listar viaturas");
            Console.WriteLine("3 - Remover viatura");
            Console.WriteLine("4 - Registar transporte de encomenda");
            Console.WriteLine("5 - Listar transportes");
            Console.WriteLine("0 - Sair");

            string opcaoStr = Console.ReadLine();
            int opcao;
            if (!int.TryParse(opcaoStr, out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            Console.Clear();

            switch (opcao)
            {
                case 1:
                    AdicionarViatura();
                    break;
                case 2:
                    ListarViaturas();
                    break;
                case 3:
                    RemoverViatura();
                    break;
                case 4:
                    RegistarTransporte();
                    break;
                case 5:
                    ListarTransportes();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
    static void AdicionarViatura()
    {
        Console.WriteLine("Adicionar Viatura");
        Console.WriteLine("Marca: ");
        string marca = Console.ReadLine();
        Console.WriteLine("Modelo: ");
        string modelo = Console.ReadLine();
        Console.WriteLine("Matrícula: ");
        string matricula = Console.ReadLine();
        Console.WriteLine("Custo por km: ");
        double custoPorKm;
        if (!double.TryParse(Console.ReadLine(), out custoPorKm))
        {
            Console.WriteLine("Valor inválido para custo por km. Viatura não adicionada.");
            return;
        }
        Console.WriteLine("Peso máximo(Kg): ");
        double pesoMax;
        if (!double.TryParse(Console.ReadLine(), out pesoMax))
        {
            Console.WriteLine("Valor inválido para peso máximo. Viatura não adicionada.");
            return;
        }
        Console.WriteLine("Altura máxima(m): ");
        double alturaMax;
        if (!double.TryParse(Console.ReadLine(), out alturaMax))
        {
            Console.WriteLine("Valor inválido para altura máxima. Viatura não adicionada.");
            return;
        }
        Console.WriteLine("Largura máxima(m): ");
        double larguraMax;
        if (!double.TryParse(Console.ReadLine(), out larguraMax))
        {
            Console.WriteLine("Valor inválido para largura máxima. Viatura não adicionada.");
            return;
        }
        Console.WriteLine("Profundidade máxima(m): ");
        double profundidadeMax;
        if (!double.TryParse(Console.ReadLine(), out profundidadeMax))
        {
            Console.WriteLine("Valor inválido para profundidade máxima. Viatura não adicionada.");
            return;
        }

        Viatura viatura = new Viatura(marca, modelo, matricula, custoPorKm, pesoMax, alturaMax, larguraMax, profundidadeMax);
        viaturas.Add(viatura);
        Console.WriteLine("Viatura adicionada com sucesso.");
    }

    static void ListarViaturas()
    {
        Console.WriteLine("Lista de Viaturas:");
        foreach (Viatura viatura in viaturas)
        {
            Console.WriteLine(viatura);
        }
    }

    static void RemoverViatura()
    {
        Console.WriteLine("Remover Viatura");
        Console.WriteLine("Matrícula da viatura a remover: ");
        string matricula = Console.ReadLine();

        Viatura viaturaRemover = viaturas.Find(v => v.Matricula == matricula);
        if (viaturaRemover != null)
        {
            viaturas.Remove(viaturaRemover);
            Console.WriteLine("Viatura removida com sucesso.");
        }
        else
        {
            Console.WriteLine("Viatura não encontrada.");
        }
    }

    static void RegistarTransporte()
    {
        Console.WriteLine("Registar Transporte");
        Console.WriteLine("Matrícula da viatura: ");
        string matricula = Console.ReadLine();

        Viatura viatura = viaturas.Find(v => v.Matricula == matricula);
        if (viatura == null)
        {
            Console.WriteLine("Viatura não encontrada.");
            return;
        }

        Console.WriteLine("Peso da encomcomenda(Kg): ");
        double peso;
        if (!double.TryParse(Console.ReadLine(), out peso))
        {
            Console.WriteLine("Valor inválido para o peso da encomenda. O transporte não foi registado.");
            return;
        }
        Console.WriteLine("Altura da encomenda(m): ");
        double altura;
        if (!double.TryParse(Console.ReadLine(), out altura))
        {
            Console.WriteLine("Valor inválido para a altura da encomenda. O transporte não foi registado.");
            return;
        }
        Console.WriteLine("Largura da encomenda(m): ");
        double largura;
        if (!double.TryParse(Console.ReadLine(), out largura))
        {
            Console.WriteLine("Valor inválido para a largura da encomenda. O transporte não foi registado.");
            return;
        }
        Console.WriteLine("Profundidade da encomenda(m): ");
        double profundidade;
        if (!double.TryParse(Console.ReadLine(), out profundidade))
        {
            Console.WriteLine("Valor inválido para a profundidade da encomenda. O transporte não foi registado.");
            return;
        }
        Encomenda encomenda = new Encomenda(peso, altura, largura, profundidade);

        if (encomenda.Peso > viatura.PesoMax || encomenda.Altura > viatura.AlturaMax ||
            encomenda.Largura > viatura.LarguraMax || encomenda.Profundidade > viatura.ProfundidadeMax)
        {
            Console.WriteLine("A encomenda excede as dimensões ou peso máximo da viatura. O transporte não foi registado.");
            return;
        }

        Transporte transporte = new Transporte(viatura, encomenda);
        transportes.Add(transporte);
        Console.WriteLine("Transporte registado com sucesso.");
    }

    static void ListarTransportes()
    {
        Console.WriteLine("Lista de Transportes:");
        foreach (Transporte transporte in transportes)
        {
            Console.WriteLine(transporte);
        }
    }

}
