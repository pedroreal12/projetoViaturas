using System.Reflection.Metadata.Ecma335;

class Main
{    
    public static int Main()
    {
        return 0;
    }

    public static void list(string className)
    {
        if (className == 'Viatura')
        {
            for (int i = 0;i < viaturas.Lenght; i++)
            {
                if (viaturas[i].id != 0)
                {
                    Console.WriteLine('Veiculo numero: ', viaturas[i].id);
                    Console.WriteLine('Marca: ', viaturas[i].marca);
                    Console.WriteLine('Modelo: ', viaturas[i].modelo);
                    Console.WriteLine('Matricula: ', viaturas[i].matricula);
                    Console.WriteLine('Custo/Km: ', viaturas[i].custoKm);
                    Console.WriteLine('Peso: ', viaturas[i].peso);
                    Console.WriteLine('Altura: ', viaturas[i].altura);
                    Console.WriteLine('Profundidade maxima: ', viaturas[i].profundidade);
                    Console.WriteLine('');
                }
            }
        } else if (className == 'Transporte')
        {
            for (int i = 0; i < transportes.Lenght; i++)
            {
                if (ttransportes[i].id != 0)
                {
                    Console.WriteLine('Transporte numero: ', transporte[i].id);
                    Console.WriteLine('Data de Saida: ', transporte[i].dataSaida);
                    Console.WriteLine('Duracao da Viagem: ', transportes[i].DuracaoViagem);
                    Console.WriteLine('Internacional: ', transportes[i].internacional);
                    Console.WriteLine('Custo Total da Viagem: ', transportes[i].custoTotalViagem);
                    for (int i2 = 0; i2 < viaturas.Lenght; i2++)
                    {
                        if (transportes[i].idViatura == viaturas[i2].id)
                        {
                            Console.WriteLine('Viatura associada ao Transporte: ', viatura[i2].marca;
                        }
                    }
                    Console.WriteLine('Destino Final: ', transportes[i].destino);
                    Console.WriteLine('Encomendas associadas ao Transporte: ', transportes[i].idEncomenda);
                    Console.WriteLine('');
                }
            }
        } else if (className == 'Encomenda')
        {
            for (int i = 0; i < encomendas.Lenght; i++)
            {
                if (encomendas[i].id != 0)
                {
                    Console.WriteLine('Numero da Encomenda: ', encomendas[i].id);
                    Console.WriteLine('Data de Entrega Prevista: ', encomendas[i].dataPrevista);
                    Console.WriteLine('Peso: ', encomendas[i].peso);
                    Console.WriteLine('Descricao da Encomenda: ', encomendas[i].descricao);
                    Console.WriteLine('Largura da Encomenda: ', encomendas[i].largura);
                    Console.WriteLine('Altura da Encomenda: ', encomendas[i].altura);
                    Console.WriteLine('');
                }
            }
        }
    }

    public static int remove(int id, string className)
    { 
        if (className == 'Viatura')
        {
            for (int i = 0; i < viaturas.Length; i++)
            {
                if (viaturas[i].id == id)
                {
                    viaturas.RemoveAt(i);
                    return 1;
                }
            }

        } else if (className == 'Transporte')
        {
            for (int i = 0; i < transportes.Length; i++)
            {
                if (transportes[i].id == id)
                {
                    transportes.RemoveAt(i);
                    return 1;
                }
            }
        } else if (className == 'Encomenda')
        {
            for (int i = 0; i < encomendas.Length; i++)
            {
                if (encomendas[i].id == id)
                {
                    encomendas.RemoveAt(i);
                    return 1;
                }
            }
        } else
        {
            return 0;
        }
    }

    public static void mainMenu()
    {
        Console.WriteLine('');
    }

}