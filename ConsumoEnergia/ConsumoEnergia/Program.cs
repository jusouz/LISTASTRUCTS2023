using System;
using System.Collections.Generic;
using System.IO;

struct Eletrodomestico
{
    public string nome;
    public double potencia;
    public double tempoMedio;
}

static void removerEletro(List<Eletrodomestico> lista, string nomeBusca)
{
    int qtd = lista.Count();
    for (int i = 0; i < qtd; i++)
    {
        if (lista[i].nome.ToUpper().Equals(nomeBusca.ToUpper()))
        {
            Console.WriteLine($"Quer mesmo excluir {nomeBusca}? S/N");
            char resposta;
            resposta = Convert.ToChar(Console.ReadLine());

            if (resposta == 'S' || resposta == 's')
            {
                lista.RemoveAt(i);
                Console.WriteLine("Eletrodomestico excluido com sucesso!");
                break;
            }
            else
            {
                Console.WriteLine("Operação Cancelada");
            }
        }
    }
}

static void carregarDados(List<Eletro> lista, string nomeArquivo)
{
    if (File.Exists(nomeArquivo))
    {
        string[] linhas = File.ReadAllLines(nomeArquivo);
        foreach (string linha in linhas)
        {
            string[] campos = linha.Split(',');
            Eletro eletro = new Eletro();
            {
                eletro.nome = campos[0];
                eletro.potencia = double.Parse(campos[1]);
                eletro.tempoMedio = double.Parse(campos[2]);

            };

            lista.Add(eletro);
        }
        Console.WriteLine("Dados carregados com sucesso!");
    }
    else
    {
        Console.WriteLine("*** Dados não encotrados ***");
    }
}

static void salvarDados(List<Eletrodomestico> lista, string nomeArquivo)
{
    using (StreamWriter writer = new StreamWriter(nomeArquivo))
    {
        foreach (Eletrodomestico Eletrodomestico in lista)
        {
            writer.WriteLine($"{Eletrodomestico.nome},{Eletrodomestico.potencia},{Eletrodomestico.tempoMedio}");
        }
    }
    Console.WriteLine("Dados salvos com sucesso!");
}

static void buscarNome(List<Eletrodomestico> lista, string NomeProcurado)
{
    int qtd = lista.Count();
    for (int i = 0; i < qtd; i++)
    {
        if (lista[i].nome.ToUpper().Contains(NomeProcurado.ToUpper()))
        {
            Console.WriteLine("\nDADOS");
            Console.WriteLine("Nome:" + lista[i].nome);
            Console.WriteLine("Potencia W:" + lista[i].potencia);
            Console.WriteLine("Tempo medio de uso:" + lista[i].tempoMedio);
        }
    }
}

static void calcularCustoEletro(List<Eletrodomestico> lista, string nomeBusca)
{
    double consumoDia, valorGastoDia, kwRS;
    Console.Write("Valor do Kw em R$");
    kwRS = Convert.ToDouble(Console.ReadLine());
    foreach (Eletrodomestico Eletrodomestico in lista)
    {
        if (Eletrodomestico.nome.ToUpper().Equals(nomeBusca.ToUpper()))
        {
            consumoDia = Eletrodomestico.potencia * Eletrodomestico.tempoMedio;
            valorGastoDia = consumoDia * kwRS;
            Console.WriteLine($"Consumo em KW por dia:" + $"{consumoDia}, por mês:{consumoDia * 30}");
        }
    }
}
static void consumo(List<Eletrodomestico> lista)
{
    int qtd = lista.Count();
    double potencia, tempo, consumo = 0, valordia = 0, valormes = 0;

    Console.WriteLine("Qual o valor do Kw em R$: ");
    double kwRS = Convert.ToDouble(Console.ReadLine());

    for (int i = 0; i < qtd; i++)
    {
        consumo += lista[i].potencia * lista[i].tempoMedio;
        valordia += lista[i].potencia * lista[i].tempoMedio * kwRS;
        valormes += lista[i].potencia * lista[i].tempoMedio * kwRS;
    }

    Console.WriteLine("O Valor do dia do consumo dessa casa  é: " + valordia);
    valormes = valormes * 30;
    Console.WriteLine("O Valor do mes do consumo dessa casa  é: " + valormes);
}

static void comparar(List<Eletrodomestico> lista)
{
    Console.WriteLine("Digite o valor em W:");
    int p = Convert.ToInt32(Console.ReadLine());

    foreach (Eletrodomestico Eletrodomestico in lista)
    {
        if (Eletrodomestico.potencia > p)
        {
            Console.WriteLine($"O eletrodoméstico {Eletrodomestico.nome} maior que {p}");
            Console.WriteLine("Potencia: " + Eletrodomestico.potencia);
            Console.WriteLine("TempoMedio (horas):" + Eletrodomestico.tempoMedio);
        }
    }
}

static void cadastrar(List<Eletrodomestico> lista)
{
    Eletrodomestico cadastro = new Eletrodomestico();
    double gasto;

    Console.Write("Escreva o nome do eletrodoméstico: ");
    cadastro.nome = Console.ReadLine();
    Console.Write("Escreva a potência em W do eletrodoméstico: ");
    cadastro.potencia = Convert.ToDouble(Console.ReadLine());
    Console.Write("Escreva o tempo medio de uso (horas): ");
    cadastro.tempoMedio = Convert.ToDouble(Console.ReadLine());
    lista.Add(cadastro);
}

static void listar(List<Eletrodomestico> lista)
{
    int qtd = lista.Count();
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Eletrodomésticos Cadastrados");
    Console.WriteLine("---------------------------------");

    for (int i = 0; i < qtd; i++)
    {
        Console.WriteLine($"\n {i + 1} - " + lista[i].nome);
        Console.WriteLine("\nNome:" + lista[i].nome);
        Console.WriteLine("Potencia W:" + lista[i].potencia);
        Console.WriteLine("Tempo medio de uso:" + lista[i].tempoMedio);
    }
}
static int menu()
{
    int op;
    Console.Write("\n");
    Console.WriteLine("\t0-Sair");
    Console.WriteLine("\t1-Cadastrar");
    Console.WriteLine("\t2-Listar");
    Console.WriteLine("\t3-Buscar por nome");
    Console.WriteLine("\t4-Consumo total da casa");
    Console.WriteLine("\t5-Remover Eletro");
    Console.WriteLine("\t6-Consumo por aparelho");
    Console.WriteLine("\t7-Buscar por que gastam mais de que um valor x");
    Console.Write("\nDigite uma opção:");

    op = Convert.ToInt32(Console.ReadLine());
    return op;
}

static void Main()
{
    List<Eletrodomestico> lista = new List<Eletrodomestico>();
    carregarDados(lista, "dados.txt");
    int op = 0;
    string nomeP;
    do
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Sistema de controle de Energia C#");
        Console.WriteLine("---------------------------------");
        op = menu();
        switch (op)
        {
            case 0:
                Console.WriteLine("Saindo");
                op = 0;
                salvarDados(lista, "dados.txt");
                break;

            case 1:
                cadastrar(lista);
                Console.WriteLine("Cadastro realizado com sucesso!");
                break;

            case 2:
                listar(lista);
                break;

            case 3:
                Console.WriteLine("Qual Eletro quer buscar:");
                nomeP = Console.ReadLine();
                buscarNome(lista, nomeP);

                break;

            case 4:
                consumo(lista);
                break;

            case 5:
                Console.WriteLine("Qual Eletro quer excluir:");
                nomeP = Console.ReadLine();
                removerEletro(lista, nomeP);
                break;

            case 6:
                Console.WriteLine("Qual Eletro quer buscar:");
                nomeP = Console.ReadLine();
                calcularCustoEletro(lista, nomeP);
                break;

            case 7:
                comparar(lista);

                break;
        }
        if (op != 0 && op != 1 && op != 2 && op != 3 && op != 4 && op != 5 && op != 6 && op != 7)
        {
            Console.WriteLine("\n**Digite uma opção válida**");
        }
        Console.ReadKey();
        Console.Clear();
    } while (op != 0);
}
