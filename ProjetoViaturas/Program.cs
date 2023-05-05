using System;

namespace Viatura
{
    class Viatura_Classe
    {
        public static void Main(string[] args)
        {
            var viaturas = new Viatura_Classe[];
        }

        public static void addViatuaras() 
        {
            Console.WriteLine("Adicionar viatura");
            Console.WriteLine("Marca da viatura:");
            string marca = Console.ReadLine();
            Console.WriteLine("Modelo da viatura:");
            string modelo = Console.ReadLine();
            Console.WriteLine("Matricula da viatura:");
            string matricula = Console.ReadLine();
            Console.WriteLine("Custo/Km da viatura:");
            double custo = Console.ReadLine();
            Console.WriteLine("Peso da encomenda(Kg):");
            double peso = Console.ReadLine();
            Console.WriteLine("Altura da encomenda (cm):");
            int altura = Console.ReadLine();
            Console.WriteLine("Largura da encomenda(cm):");
            int largura = Console.ReadLine();
            Console.WriteLine("Profundidade maxima da encomenda(cm):");
            double profundidade = Console.ReadLine(); 
        }

        public static void editViaturas(int id)
        {
            Console.WriteLine("Editar Viaturas");

            for (int i = 0; i < viaturas.Lenght; i++)
            {
                if (viaturas[i].id == id)
                {
                    Console.WriteLine("Marca da viatura:");
                    string marca = Console.ReadLine();
                    Console.WriteLine("Modelo da viatura:");
                    string modelo = Console.ReadLine();
                    Console.WriteLine("Matricula da viatura:");
                    string matricula = Console.ReadLine();
                    Console.WriteLine("Custo/Km da viatura:");
                    double custo = Console.ReadLine();
                    Console.WriteLine("Peso da encomenda(Kg):");
                    double peso = Console.ReadLine();
                    Console.WriteLine("Altura da encomenda (cm):");
                    int altura = Console.ReadLine();
                    Console.WriteLine("Largura da encomenda(cm):");
                    int largura = Console.ReadLine();
                    Console.WriteLine("Profundidade maxima da encomenda(cm):");
                    double profundidade = Console.ReadLine();
                }
            }
        }
    }
}

namespace Encomendas
{
    class Encomendas_Classe
    {
        public static void Main(string[] args)
        {
            var encomendas = new Encomendas_Classe[];
        }

        public static void addEncomendas() 
        {
            Console.WriteLine("Adicionar encomenda:");
            Console.WriteLine("Data prevista:");
            string dataPrevista = Console.ReadLine();
            Console.WriteLine("Peso da encomenda(Kg):");
            string pesoEncomenda = Console.ReadLine();
            Console.WriteLine("Descricao da encomenda:");
            string descricao = Console.ReadLine();
            Console.WriteLine("Largura da encomenda(cm):");
            int largura = Console.ReadLine();
            Console.WriteLine("Altura da encomenda(cm):");
            int altura = Console.ReadLine();
        }

        public static void editEncomenda(int id)
        {
            Console.WriteLine("Editar Encomenda");

            for(int i = 0; i < encomendas.Lenght; i++)
            {
                if (encomandas[i].id == id)
                {
                    Console.WriteLine("Data prevista:");
                    string dataPrevista = Console.ReadLine();
                    Console.WriteLine("Peso da encomenda(Kg):");
                    string pesoEncomenda = Console.ReadLine();
                    Console.WriteLine("Descricao da encomenda:");
                    string descricao = Console.ReadLine();
                    Console.WriteLine("Largura da encomenda(cm):");
                    int largura = Console.ReadLine();
                    Console.WriteLine("Altura da encomenda(cm):");
                    int altura = Console.ReadLine();
                }
            }
        }
    }
}

namespace Transportes
{
    class Transportes_Classe
    {
        public static void Main (string[] args)
        {
            var transportes = new Transportes_Classe();
        }

        public static void addTransporte()
        {
            Console.WriteLine("Adicionar Transporte");
            Console.WriteLine("Data de saida:");
            string dataSaida = Console.ReadLine();
            Console.WriteLine("Duracao da viagem(minutos):");
            int duracaoViagem = Console.ReadLine();
            Console.WriteLine("Viagem internacional? (Sim/Não)");
            char internacional = Console.ReadLine();
            Console.WriteLine("Custo total da viagem(€):");
            double custoViagem = Console.ReadLine();
            Console.WriteLine("Viatura associada ao transporte(Id da viatura):");
            int idViatura = Console.ReadLine();
            Console.WriteLine("Destino Final:");
            string destinoFinal = Console.ReadLine();
            Console.WriteLine("Encomenda associada ao transporte(Id da encomenda)):");
            int idEncomenda = Console.ReadLine();
        }

        public static void editTransportes(int id)
        {
            Console.WriteLine("Editar Transportes")
            for (int i = 0; i < transportes.Lenght; i++)
            {
                if (transportes[i].id == id)
                {
                    Console.WriteLine("Data de saida:");
                    string dataSaida = Console.ReadLine();
                    Console.WriteLine("Duracao da viagem(minutos):");
                    int duracaoViagem = Console.ReadLine();
                    Console.WriteLine("Viagem internacional? (Sim/Não)");
                    char internacional = Console.ReadLine();
                    Console.WriteLine("Custo total da viagem(€):");
                    double custoViagem = Console.ReadLine();
                    Console.WriteLine("Viatura associada ao transporte(Id da viatura):");
                    int idViatura = Console.ReadLine();
                    Console.WriteLine("Destino Final:");
                    string destinoFinal = Console.ReadLine();
                    Console.WriteLine("Encomenda associada ao transporte(Id da encomenda)):");
                    int idEncomenda = Console.ReadLine();
                }
            }
        }
    }
}

namespace Transportadora
{
    class Transportadora_Classe
    {
        public static void Main(string[] args)
        {
            var transportadora = new Transportadora_Classe();
        }

        public static void addTransportadora()
        {
            Console.WriteLine("Adicionar Transportadora");
            Console.WriteLine("Nome:");
            string nomeTransportadora = Console.ReadLine();
            Console.WriteLine("Localizcao da sede:");
            string sedeTransportadora = Console.ReadLine();
        }

        public static void editTransportadora(int id)
        {
            Console.WriteLine("Editar Transportadora")
            for (int i = 0; i < transportadora.Lenght; i++)
            {
                if (transportadora[i].id == id)
                {
                    Console.WriteLine("Adicionar Transportadora");
                    Console.WriteLine("Nome:");
                    string nomeTransportadora = Console.ReadLine();
                    Console.WriteLine("Localizcao da sede:");
                    string sedeTransportadora = Console.ReadLine();
                }
            }
        }
    }
}


/*

while (true) 
{
menu();
int option = InputValidation.ValidateIntBetween("Opcao: ",0,2);

switch (option)
{
case 1:
    viaturas[0] = new viaturas(); // Menu Viaturas
    break;

case 2:
    //Menu Encomendas

case3: 
    //Menu Transportes

case
    

case 0:
    return;
}
}
 */

