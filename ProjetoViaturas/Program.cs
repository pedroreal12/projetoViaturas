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
        public string TipoTransporte { get; set; }

        public Viatura(string marca, string modelo, string matricula, double custoPorKm, double pesoMax, double alturaMax, double larguraMax, double profundidadeMax, string tipoTransporte, string tipoViatura)
        {
            Marca = marca;
            Modelo = modelo;
            Matricula = matricula;
            CustoPorKm = custoPorKm;
            PesoMax = pesoMax;
            AlturaMax = alturaMax;
            LarguraMax = larguraMax;
            ProfundidadeMax = profundidadeMax;
            TipoViatura = tipoViatura;
            TipoTransporte = tipoTransporte;
        }

        public void editarViatura(string novaMarca, string novoModelo, string novaMatricula, double novoCustoPorKm,
            double novoPesoMax, double novaAlturaMax, double novaLarguraMax, double novaProfundidadeMax, string novoTipoTransporte)
        {
            Marca = novaMarca;
            Modelo = novoModelo;
            Matricula = novaMatricula;
            CustoPorKm = novoCustoPorKm;
            PesoMax = novoPesoMax;
            AlturaMax = novaAlturaMax;
            LarguraMax = novaLarguraMax;
            ProfundidadeMax = novaProfundidadeMax;
            TipoTransporte = novoTipoTransporte;
        }

        public override string ToString()
        {
            return $"Viatura: {Marca} {Modelo}\nMatrícula: {Matricula}\nCusto por Km: {CustoPorKm}\n" +
                   $"Peso máximo: {PesoMax} Kg\nDimensões máximas (LxPxA): {LarguraMax}x{ProfundidadeMax}x{AlturaMax}\n";
        }
    }

    class ViaturaAerea : Viatura
    {
        public string NumeroRegisto { get; set; }
        public double Envergadura { get; set; }
        public double Comprimento { get; set; }

        public ViaturaAerea(string marca, string modelo, string matricula, double custoPorKm, double altura, double largura, double profundidade, double pesoMaximoCarga, string tipoTransporte, string numeroRegisto, double envergadura, double comprimento)
            : base(marca, modelo, matricula, custoPorKm, altura, largura, profundidade, pesoMaximoCarga, tipoTransporte, tipoTransporte)
        {
            NumeroRegisto = numeroRegisto;
            Envergadura = envergadura;
            Comprimento = comprimento;
        }
    }

    class ViaturaAquatica : Viatura
    {
        public string NumeroRegisto { get; set; }
        public string CodigoEmbarcacao { get; set; }
        public double Boca { get; set; }
        public double Calado { get; set; }
        public double Comprimento { get; set; }

        public ViaturaAquatica(string marca, string modelo, string matricula, double custoPorKm, double altura, double largura, double profundidade, double pesoMaximoCarga, string tipoTransporte, string numeroRegisto, string codigoEmbarcacao, double boca, double calado, double comprimento)
            : base(marca, modelo, matricula, custoPorKm, altura, largura, profundidade, pesoMaximoCarga, tipoTransporte, tipoTransporte)
        {
            NumeroRegisto = numeroRegisto;
            CodigoEmbarcacao = codigoEmbarcacao;
            Boca = boca;
            Calado = calado;
            Comprimento = comprimento;
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
            string[] tipoTransportes = { "Aquático", "Aéreo", "Terrestre" };
            Console.WriteLine("Adicionar Viatura");
            int optionTransporte;
            for (int i = 0; i < tipoTransportes.Length; i++)
            {
                Console.WriteLine($"ID {i}: {tipoTransportes[i]}");
            }

            Console.WriteLine("Introduza o ID para o tipo de transporte que esta viatura irá realizar, tendo em conta a tabela acima: ");

            if (!int.TryParse(Console.ReadLine(), out optionTransporte))
            {
                Console.WriteLine("Valor inválido para o tipo de transporte. Viatura não adicionada.");
                return;
            }

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
            //Tipo de Transporte Aquático
            if (optionTransporte == 0)
            {
                Console.WriteLine("Nome da embarcação: ");
                string nomeEmbarcacao;
                nomeEmbarcacao = Console.ReadLine();

                Console.WriteLine("Número de registo da embarcação: ");
                string numeroRegistoEmbarcacao = Console.ReadLine();

                Console.WriteLine("Tipo de embarcação (EX: Caravela, Navio, Bote etc...): ");
                string tipoEmbarcacao;
                tipoEmbarcacao = Console.ReadLine();

                Console.WriteLine("Código da embarcação: ");
                string codigoEmbarcacao = Console.ReadLine();
                

                Console.WriteLine("Boca da embarcação(M): ");

                double bocaEmbarcacao;
                if (!double.TryParse(Console.ReadLine(), out bocaEmbarcacao))
                {
                    Console.WriteLine("Boca de embarcação inválida. Viatura não adicionada.");
                }

                Console.WriteLine("Calado da embarcação(M)");

                double caladoEmbarcacao;
                if (!double.TryParse(Console.ReadLine(), out caladoEmbarcacao))
                {
                    Console.WriteLine("Calado de embarcação inválido. Viatura não adicionada.");
                }

                Console.WriteLine("Comprimento da embarcação(M)");

                double comprimentoEmbarcacao;
                if (!double.TryParse(Console.ReadLine(), out comprimentoEmbarcacao))
                {
                    Console.WriteLine("Comprimento de embarcação inválido. Viatura não adicionada: ");
                }

                ViaturaAquatica viatura = new ViaturaAquatica(marca, modelo, matricula, custoPorKm, alturaMax, larguraMax, profundidadeMax, pesoMax, tipoEmbarcacao, nomeEmbarcacao, codigoEmbarcacao, bocaEmbarcacao, caladoEmbarcacao, comprimentoEmbarcacao);
                viaturas.Add(viatura);

            }
            //Tipo de transporte Aereo
            else if (optionTransporte == 1)
            {
                Console.WriteLine("Número de registo da aeronave: ");
                string numeroRegistoAeronave = Console.ReadLine();

                int codigoAeronave;
                if (!int.TryParse(Console.ReadLine(), out codigoAeronave))
                {
                    Console.WriteLine("Número de registo de aeronave inválido. Viatura não adicionada: ");
                }

                Console.WriteLine("Envergadura da aeronave(M): ");

                double envergaduraAeronave;
                if (!double.TryParse(Console.ReadLine(), out envergaduraAeronave))
                {
                    Console.WriteLine("Envergadura de aeronave inválida. Viatura não adicionada: ");
                }


                Console.WriteLine("Altura da aeronave(M): ");

                double alturaAeronave;
                if (!double.TryParse(Console.ReadLine(), out alturaAeronave))
                {
                    Console.WriteLine("Altura de aeronave inválida. Viatura não adicionada: ");
                }

                Console.WriteLine("Comprimento da aeronave (M): ");

                double comprimentoAeronave;
                if (!double.TryParse(Console.ReadLine(), out comprimentoAeronave))
                {
                    Console.WriteLine("Comprimento de aeronave inválido. Viatura não adicionada: ");
                }

                Console.WriteLine("Novo Tipo de Aeronave (EX: Jato, Avião, Helicóptero, etc..): ");
                string tipoAeronave = Console.ReadLine();

                ViaturaAerea viatura = new ViaturaAerea(marca, modelo, matricula, custoPorKm, alturaAeronave, larguraMax, profundidadeMax, pesoMax, tipoAeronave, numeroRegistoAeronave, envergaduraAeronave, comprimentoAeronave);
                viaturas.Add(viatura);

            }
            //Transporte terrestre
            else if (optionTransporte == 2)
            {
                Console.WriteLine("Tipo de Viatura (EX: Bicicleta, Carro, Camião etc...): ");
                string tipoViatura;
                tipoViatura = Console.ReadLine();
                Viatura viatura = new Viatura(marca, modelo, matricula, custoPorKm, pesoMax, alturaMax, larguraMax, profundidadeMax, tipoViatura, tipoTransportes[optionTransporte]);
                viaturas.Add(viatura);
                Console.WriteLine("Viatura adicionada com sucesso.");
            } else 
            {
                Console.WriteLine("O tipo de transporte introduzido é inválido. Viatura não adicionada");
                return;
            }
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
            Console.WriteLine("Matricula da Viatura: ");
            string matriculaEditar = Console.ReadLine();
            Viatura viaturaEditar = viaturas.Find(v => v.Matricula == matriculaEditar);

            if (viaturaEditar != null)
            {
                string[] tipoTransportes = { "Aquático", "Aéreo", "Terrestre" };
                Console.WriteLine("Editar Viatura");
                int optionTransporte;
                for (int i = 0; i < tipoTransportes.Length; i++)
                {
                    Console.WriteLine($"ID {i}: {tipoTransportes[i]}");
                }

                Console.WriteLine("Introduza o novo ID para o tipo de transporte que esta viatura irá realizar, tendo em conta a tabela acima: ");

                if (!int.TryParse(Console.ReadLine(), out optionTransporte))
                {
                    Console.WriteLine("Valor inválido para o tipo de transporte. Viatura não adicionada.");
                    return;
                }

                Console.WriteLine("Nova Marca: ");
                string marca = Console.ReadLine();
                Console.WriteLine("Novo Modelo: ");
                string modelo = Console.ReadLine();
                Console.WriteLine("Nova Matrícula: ");
                string matricula = Console.ReadLine();
                Console.WriteLine("Novo Custo por Km: ");
                double custoPorKm;
                if (!double.TryParse(Console.ReadLine(), out custoPorKm))
                {
                    Console.WriteLine("Valor inválido para custo por Km. Viatura não adicionada.");
                    return;
                }
                Console.WriteLine("Novo Peso máximo(Kg): ");
                double pesoMax;
                if (!double.TryParse(Console.ReadLine(), out pesoMax))
                {
                    Console.WriteLine("Valor inválido para peso máximo. Viatura não adicionada.");
                    return;
                }
                Console.WriteLine("Nova Altura máxima(M): ");
                double alturaMax;
                if (!double.TryParse(Console.ReadLine(), out alturaMax))
                {
                    Console.WriteLine("Valor inválido para altura máxima. Viatura não adicionada.");
                    return;
                }
                Console.WriteLine("Nova Largura máxima(M): ");
                double larguraMax;
                if (!double.TryParse(Console.ReadLine(), out larguraMax))
                {
                    Console.WriteLine("Valor inválido para largura máxima. Viatura não adicionada.");
                    return;
                }
                Console.WriteLine("Nova Profundidade máxima(M): ");
                double profundidadeMax;
                if (!double.TryParse(Console.ReadLine(), out profundidadeMax))
                {
                    Console.WriteLine("Valor inválido para profundidade máxima. Viatura não adicionada.");
                    return;
                }
                //Tipo de Transporte Aquático
                if (optionTransporte == 0)
                {
                    Console.WriteLine("Novo Nome da embarcação: ");
                    string nomeEmbarcacao;
                    nomeEmbarcacao = Console.ReadLine();

                    Console.WriteLine("Novo Número de registo da embarcação: ");

                    int numeroRegistoEmbarcacao;

                    if (!int.TryParse(Console.ReadLine(), out numeroRegistoEmbarcacao))
                    {
                        Console.WriteLine("Numero de registo de embarcação inválido. Viatura não adicionada.");
                    }

                    Console.WriteLine("Novo Tipo de embarcação (EX: Caravela, Navio, Bote etc...): ");
                    string tipoEmbarcacao;
                    tipoEmbarcacao = Console.ReadLine();

                    Console.WriteLine("Novo Código da embarcação: ");
                    int codigoEmbarcacao;
                    if (!int.TryParse(Console.ReadLine(), out codigoEmbarcacao))
                    {
                        Console.WriteLine("Código de embarcação inválido. Viatura não adicionada.");
                    }

                    Console.WriteLine("Nova Boca da embarcação(M): ");

                    double bocaEmbarcacao;
                    if (!double.TryParse(Console.ReadLine(), out bocaEmbarcacao))
                    {
                        Console.WriteLine("Boca de embarcação inválida. Viatura não adicionada.");
                    }

                    Console.WriteLine("Novo Calado da embarcação(M)");

                    double caladoEmbarcacao;
                    if (!double.TryParse(Console.ReadLine(), out caladoEmbarcacao))
                    {
                        Console.WriteLine("Calado de embarcação inválido. Viatura não adicionada.");
                    }

                    Console.WriteLine("Novo Comprimento da embarcação(M)");

                    double comprimentoEmbarcacao;
                    if (!double.TryParse(Console.ReadLine(), out comprimentoEmbarcacao))
                    {
                        Console.WriteLine("Comprimento de embarcação inválido. Viatura não adicionada: ");
                    }
                }
                //Tipo de transporte Aereo
                else if (optionTransporte == 1)
                {
                    Console.WriteLine("Novo Número de registo da aeronave: ");

                    int codigoAeronave;
                    if (!int.TryParse(Console.ReadLine(), out codigoAeronave))
                    {
                        Console.WriteLine("Número de registo de aeronave inválido. Viatura não adicionada: ");
                    }

                    Console.WriteLine("Nova Envergadura da aeronave(M): ");

                    double envergaduraAeronave;
                    if (!double.TryParse(Console.ReadLine(), out envergaduraAeronave))
                    {
                        Console.WriteLine("Envergadura de aeronave inválida. Viatura não adicionada: ");
                    }


                    Console.WriteLine("Nova Altura da aeronave(M): ");

                    double alturaAeronave;
                    if (!double.TryParse(Console.ReadLine(), out alturaAeronave))
                    {
                        Console.WriteLine("Altura de aeronave inválida. Viatura não adicionada: ");
                    }

                    Console.WriteLine("Novo Comprimento da aeronave (M): ");

                    double comprimentoAeronave;
                    if (!double.TryParse(Console.ReadLine(), out comprimentoAeronave))
                    {
                        Console.WriteLine("Comprimento de aeronave inválido. Viatura não adicionada: ");
                    }

                    Console.WriteLine("Novo Tipo de Aeronave (EX: Jato, Avião, Helicóptero, etc..): ");
                    string tipoAeronave = Console.ReadLine();

                    Viatura viatura = new Viatura(marca, modelo, matricula, custoPorKm, pesoMax, alturaMax, larguraMax, profundidadeMax, tipoAeronave, tipoTransportes[optionTransporte]);
                    viaturas.Add(viatura);

                }
                //Transporte terrestre
                else if (optionTransporte == 2)
                {
                    Console.WriteLine("Novo Tipo de Viatura (EX: Bicicleta, Carro, Camião etc...): ");
                    string tipoViatura;
                    tipoViatura = Console.ReadLine();
                    Viatura viatura = new Viatura(marca, modelo, matricula, custoPorKm, pesoMax, alturaMax, larguraMax, profundidadeMax, tipoViatura, tipoTransportes[optionTransporte]);
                    viaturas.Add(viatura);
                    Console.WriteLine("Viatura adicionada com sucesso.");
                }
                else
                {
                    Console.WriteLine("O tipo de transporte introduzido é inválido. Viatura não adicionada");
                    return;
                }
            } else
            {
                Console.WriteLine("Viatura nao encontrada");
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
