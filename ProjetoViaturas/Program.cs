using System;
using System.Collections.Generic;

namespace projetoViaturas
{ 
    class Viatura
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string TipoViatura { get; set; }
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

        public void editarViatura(string novaMarca, string novoModelo, string novaMatricula, double novoCustoPorKm,
            double novoPesoMax, double novaAlturaMax, double novaLarguraMax, double novaProfundidadeMax)
        {
            Marca = novaMarca;
            Modelo = novoModelo;
            Matricula = novaMatricula;
            CustoPorKm = novoCustoPorKm;
            PesoMax = novoPesoMax;
            AlturaMax = novaAlturaMax;
            LarguraMax = novaLarguraMax;
            ProfundidadeMax = novaProfundidadeMax;
        }

        public override string ToString()
        {
            return $"Viatura: {Marca} {Modelo}\nMatrícula: {Matricula}\nCusto por Km: {CustoPorKm}\n" +
                   $"Peso máximo: {PesoMax} Kg\nDimensões máximas (LxPxA): {LarguraMax}x{ProfundidadeMax}x{AlturaMax}\n";
        }
    }



    class ViaturaAerea : Viatura
    {
        public string NumeroRegistro { get; set; }
        public double Envergadura { get; set; }
        public double Comprimento { get; set; }

        public ViaturaAerea(string marca, string modelo, string matricula, double custoPorKm, double altura, double largura, double profundidade, double pesoMaximoCarga, string tipoTransporte, string numeroRegistro, double envergadura, double comprimento)
            : base(marca, modelo, matricula, custoPorKm, altura, largura, profundidade, pesoMaximoCarga, tipoTransporte)
        {
            NumeroRegistro = numeroRegistro;
            Envergadura = envergadura;
            Comprimento = comprimento;
        }

        class ViaturaAquatica : Viatura
        {
            public string NumeroRegistro { get; set; }
            public string CodigoEmbarcacao { get; set; }
            public double Boca { get; set; }
            public double Calado { get; set; }
            public double Comprimento { get; set; }

            public ViaturaAquatica(string marca, string modelo, string matricula, double custoPorKm, double altura, double largura, double profundidade, double pesoMaximoCarga, string tipoTransporte, string numeroRegistro, string codigoEmbarcacao, double boca, double calado, double comprimento)
                : base(marca, modelo, matricula, custoPorKm, altura, largura, profundidade, pesoMaximoCarga, tipoTransporte)
            {
                NumeroRegistro = numeroRegistro;
                CodigoEmbarcacao = codigoEmbarcacao;
                Boca = boca;
                Calado = calado;
                Comprimento = comprimento;
            }
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
            return $"Encomenda: peso={Peso}Kg, dimensões (LxPxA)={Largura}x{Profundidade}x{Altura}\n";
        }
    }

    class Transporte
    {
        public Viatura Viatura { get; set; }
        public Encomenda Encomenda { get; set; }
        public int Id { get; set; }
        public static int count = 0;

        public Transporte(Viatura viatura, Encomenda encomenda, int id)
        {
            Viatura = viatura;
            Encomenda = encomenda;
            Id = id;
            count++;
        }

        public static int getCountTransportes()
        {
            return count;
        }

        public void editarTransporte(double novoPeso, double novaAltura, double novaLargura, double novaProfundidade)
        {
            if (novoPeso <= Viatura.PesoMax && novaAltura <= Viatura.AlturaMax &&
                novaLargura <= Viatura.LarguraMax && novaProfundidade <= Viatura.ProfundidadeMax)
            {
                Encomenda.Peso = novoPeso;
                Encomenda.Altura = novaAltura;
                Encomenda.Largura = novaLargura;
                Encomenda.Profundidade = novaProfundidade;
                Console.WriteLine("Transporte editado com sucesso.");
            }
            else
            {
                Console.WriteLine("A encomenda excede as dimensões ou peso máximo. O transporte não foi editado.");
            }
        }


        public override string ToString()
        {
            return $"Transporte:\nId: {Id}\n{Encomenda}\n{Viatura}\n";
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
                Console.WriteLine("");
                Console.WriteLine("    VIATURAS:");
                Console.WriteLine("1 - Adicionar");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("3 - Editar");
                Console.WriteLine("4 - Remover");
                Console.WriteLine("");
                Console.WriteLine("   TRANSPORTES:");
                Console.WriteLine("5 - Registar");
                Console.WriteLine("6 - Listar");
                Console.WriteLine("7 - Editar");
                Console.WriteLine("8 - Remover");
                Console.WriteLine("");
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
                        adicionarViatura();
                        break;
                    case 2:
                        listarViaturas();
                        break;
                    case 3:
                        editarViatura();
                        break;
                    case 4:
                        removerViatura();
                        break;
                    case 5:
                        registarTransporte();
                        break;
                    case 6:
                        listarTransportes();
                        break;
                    case 7:
                        editarTransporte();
                        break;
                    case 8:
                        removerTransporte();
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
        static void adicionarViatura()
        {
            Console.WriteLine("Adicionar Viatura");
            Console.WriteLine("Marca: ");
            string marca = Console.ReadLine();
            Console.WriteLine("Modelo: ");
            string modelo = Console.ReadLine();
            Console.WriteLine("Matrícula: ");
            string matricula = Console.ReadLine();
            Console.WriteLine("Custo por Km: ");
            double custoPorKm;
            if (!double.TryParse(Console.ReadLine(), out custoPorKm))
            {
                Console.WriteLine("Valor inválido para custo por Km. Viatura não adicionada.");
                return;
            }
            Console.WriteLine("Peso máximo(Kg): ");
            double pesoMax;
            if (!double.TryParse(Console.ReadLine(), out pesoMax))
            {
                Console.WriteLine("Valor inválido para peso máximo. Viatura não adicionada.");
                return;
            }
            Console.WriteLine("Altura máxima(M): ");
            double alturaMax;
            if (!double.TryParse(Console.ReadLine(), out alturaMax))
            {
                Console.WriteLine("Valor inválido para altura máxima. Viatura não adicionada.");
                return;
            }
            Console.WriteLine("Largura máxima(M): ");
            double larguraMax;
            if (!double.TryParse(Console.ReadLine(), out larguraMax))
            {
                Console.WriteLine("Valor inválido para largura máxima. Viatura não adicionada.");
                return;
            }
            Console.WriteLine("Profundidade máxima(M): ");
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

        static void listarViaturas()
        {
            Console.WriteLine("Lista de Viaturas:");
            foreach (Viatura viatura in viaturas)
            {
                Console.WriteLine(viatura);
            }
        }

        static void editarViatura()
        {
            Console.WriteLine("Editar Viatura");
            Console.WriteLine("Matrícula da viatura:");
            string matricula = Console.ReadLine();

            Viatura viaturaEditar = viaturas.Find(v => v.Matricula == matricula);
            if (viaturaEditar != null)
            {
                Console.WriteLine("Nova marca: ");
                string novaMarca = Console.ReadLine();
                Console.WriteLine("Novo modelo: ");
                string novoModelo = Console.ReadLine();
                Console.WriteLine("Nova matrícula: ");
                string novaMatricula = Console.ReadLine();
                Console.WriteLine("Novo custo por Km: ");
                double novoCustoPorKm;
                if (!double.TryParse(Console.ReadLine(), out novoCustoPorKm))
                {
                    Console.WriteLine("Valor inválido para custo por Km. Viatura não atualizada.");
                    return;
                }
                Console.WriteLine("Novo peso máximo(Kg): ");
                double novoPesoMax;
                if (!double.TryParse(Console.ReadLine(), out novoPesoMax))
                {
                    Console.WriteLine("Valor inválido para peso máximo. Viatura não atualizada.");
                    return;
                }
                Console.WriteLine("Nova altura máxima(M): ");
                double novaAlturaMax;
                if (!double.TryParse(Console.ReadLine(), out novaAlturaMax))
                {
                    Console.WriteLine("Valor inválido para altura máxima. Viatura não atualizada.");
                    return;
                }
                Console.WriteLine("Nova largura máxima(M): ");
                double novaLarguraMax;
                if (!double.TryParse(Console.ReadLine(), out novaLarguraMax))
                {
                    Console.WriteLine("Valor inválido para largura máxima. Viatura não atualizada.");
                    return;
                }
                Console.WriteLine("Nova profundidade máxima(M): ");
                double novaProfundidadeMax;
                if (!double.TryParse(Console.ReadLine(), out novaProfundidadeMax))
                {
                    Console.WriteLine("Valor inválido para profundidade máxima. Viatura não atualizada.");
                    return;
                }

                // chama o método editarViatura na instância correspondente
                viaturaEditar.editarViatura(novaMarca, novoModelo, novaMatricula, novoCustoPorKm,
                    novoPesoMax, novaAlturaMax, novaLarguraMax, novaProfundidadeMax);

                Console.WriteLine("Viatura atualizada com sucesso.");
            }
            else
            {
                Console.WriteLine("Viatura não encontrada.");
            }
        }

        static void removerViatura()
        {
            Console.WriteLine("Remover Viatura");
            Console.WriteLine("Matrícula da viatura: ");
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

        static void registarTransporte()
        {
            Console.WriteLine("Registar Transporte");
            Console.WriteLine("Matrícula da viatura: ");
            string matricula = Console.ReadLine();
            int id = 0;

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
            Console.WriteLine("Altura da encomenda(M): ");
            double altura;
            if (!double.TryParse(Console.ReadLine(), out altura))
            {
                Console.WriteLine("Valor inválido para a altura da encomenda. O transporte não foi registado.");
                return;
            }
            Console.WriteLine("Largura da encomenda(M): ");
            double largura;
            if (!double.TryParse(Console.ReadLine(), out largura))
            {
                Console.WriteLine("Valor inválido para a largura da encomenda. O transporte não foi registado.");
                return;
            }
            Console.WriteLine("Profundidade da encomenda(M): ");
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
                Console.WriteLine("A encomenda excede as dimensões ou peso máximo. O transporte não foi registado.");
                return;
            }

            id = Transporte.getCountTransportes() + 1;

            Transporte transporte = new Transporte(viatura, encomenda, id);
            transportes.Add(transporte);
            Console.WriteLine("Transporte registado com sucesso.");
        }

        static void listarTransportes()
        {
            Console.WriteLine("Lista de Transportes:");
            foreach (Transporte transporte in transportes)
            {
                Console.WriteLine(transporte);
            }
        }

        static void editarTransporte()
        {
            Console.WriteLine("Editar Transporte");
            Console.WriteLine("Id do Transporte:");
            int id = 0;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Valor inválido para custo por Id. Transporte não encontrado.");
                return;
            }

            Transporte transporteEditar = transportes.Find(t => t.Id == id);
            if (transporteEditar == null)
            {
                Console.WriteLine("Transporte não encontrado.");
                return;
            }

            Console.WriteLine($"Transporte encontrado:\n{transporteEditar}");

            Console.WriteLine("Novo peso da encomenda(Kg): ");
            double novoPeso;
            if (!double.TryParse(Console.ReadLine(), out novoPeso))
            {
                Console.WriteLine("Valor inválido para o peso da encomenda. O transporte não foi editado.");
                return;
            }
            Console.WriteLine("Nova altura da encomenda(m): ");
            double novaAltura;
            if (!double.TryParse(Console.ReadLine(), out novaAltura))
            {
                Console.WriteLine("Valor inválido para a altura da encomenda. O transporte não foi editado.");
                return;
            }
            Console.WriteLine("Nova largura da encomenda(m): ");
            double novaLargura;
            if (!double.TryParse(Console.ReadLine(), out novaLargura))
            {
                Console.WriteLine("Valor inválido para a largura da encomenda. O transporte não foi editado.");
                return;
            }
            Console.WriteLine("Nova profundidade da encomenda(m): ");
            double novaProfundidade;
            if (!double.TryParse(Console.ReadLine(), out novaProfundidade))
            {
                Console.WriteLine("Valor inválido para a profundidade da encomenda. O transporte não foi editado.");
                return;
            }

            transporteEditar.editarTransporte(novoPeso, novaAltura, novaLargura, novaProfundidade);

        }

        static void removerTransporte()
        {
            Console.WriteLine("Remover Transporte");
            Console.WriteLine("Id do Transporte: ");
            int id = 0;

            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Valor inválido para custo por Id. Transporte não encontrado.");
                return;
            }

            Transporte transporteRemover = transportes.Find(t => t.Id == id);
            if (transporteRemover != null)
            {
                transportes.Remove(transporteRemover);
                Console.WriteLine("Transporte removido com sucesso.");
            }
            else
            {
                Console.WriteLine("Transporte não encontrado.");
            }
        }
    }
}
