using System;
using System.Collections.Generic;

struct jogo
{
    public string titulo;
    public string console;
    public int ano;
    public int ranking;
}

struct emprestimo
{
    public string tituloJogo;
    public int dataEmprestimo;
    public string nomePessoaEmprestimo;
    public char emprestado;
}

static void listarJogos(List<jogo> lista)
{

    foreach (jogo j in lista)
    {
        Console.WriteLine("\nJogo:" + j.titulo);
        Console.WriteLine("Console:" + j.console);
        Console.WriteLine("Ano de lançamento:" + j.ano);
        Console.WriteLine("Ranking:" + j.ranking);
    }
}

static void listarEmprestimo(List<emprestimo> lista)
{
    foreach (emprestimo m in lista)
    {
        Console.WriteLine("\nJogo emprestado:" + m.tituloJogo);
        Console.WriteLine("\nData do empréstimo:" + m.dataEmprestimo);
        Console.WriteLine("Nome da pessoa:" + m.nomePessoaEmprestimo);
        Console.WriteLine("Emprestado? " + m.emprestado);
    }
}

static void procurarPorConsole(List<jogo> lista)
{
    Console.WriteLine("Qual console deseja procurar?:");
    string console = Console.ReadLine();

    Console.WriteLine("Jogos desse console:");
    foreach (jogo nome in lista)
    {
        if (nome.console.ToUpper().Equals(console.ToUpper()))
        {
            Console.WriteLine("\nJogo:" + nome.titulo);
            Console.WriteLine("Console:" + nome.console);
            Console.WriteLine("Ano de lançamento:" + nome.ano);
            Console.WriteLine("Ranking:" + nome.ranking);
        }
        else
        {
            Console.WriteLine("Não há jogos para esse console.");
            break;
        }
    }
}
static void procurarPorTitulo(List<jogo> lista)
{
    Console.WriteLine("Qual jogo deseja procurar?");
    string nomeBusca = Console.ReadLine();
    foreach (jogo nome in lista)
    {
        if (nome.titulo.ToUpper().Equals(nomeBusca.ToUpper()))
        {
            Console.WriteLine("\nJogo:" + nome.titulo);
            Console.WriteLine("Console:" + nome.console);
            Console.WriteLine("Ano de lançamento:" + nome.ano);
            Console.WriteLine("Ranking:" + nome.ranking);
        }
    }
}

static void Cadastrar(List<jogo> lista)
{
    jogo novoJogo = new jogo();

    Console.WriteLine("Qual o título do jogo:");
    novoJogo.titulo = Console.ReadLine();
    Console.WriteLine("Qual o console:");
    novoJogo.console = Console.ReadLine();
    Console.WriteLine("Qual o ano:");
    novoJogo.ano = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Qual o ranking:");
    novoJogo.ranking = Convert.ToInt32(Console.ReadLine());

    lista.Add(novoJogo);
    Console.WriteLine("Jogo cadastrado com sucesso!");
}

static void Devolucao(List<emprestimo> listaEmp)
{
    Console.WriteLine("Qual jogo deseja fazer devolução?");
    string nomeBusca = Console.ReadLine();
    char confirma;
    int qtd = listaEmp.Count();
    for (int i = 0; i < qtd; i++)
    {
        if (listaEmp[i].tituloJogo.ToUpper().Contains(nomeBusca.ToUpper()))
        {
            Console.WriteLine($"Deseja mesmo devolver {listaEmp[i].tituloJogo} ? S/N");
            confirma = Convert.ToChar(Console.ReadLine());

            if (confirma == 's' || confirma == 'S')
            {
                listaEmp.RemoveAt(i);
                Console.WriteLine("Devolução realizada");
            }
        }
        else
        {
            Console.WriteLine("Jogo não encontrado nos emprestimos.");
            break;
        }
    }
}
static void Emprestimo(List<jogo> lista, List<emprestimo> listaEmp)
{
    Console.WriteLine("Qual jogo deseja realizar empréstimo?");
    string nomeBusca = Console.ReadLine();
    char confirma;
    int qtd = lista.Count();
    emprestimo emp = new emprestimo();

    for (int i = 0; i < qtd; i++)
    {
        if (lista[i].titulo.ToUpper().Contains(nomeBusca.ToUpper()))
        {
            Console.WriteLine($"Deseja mesmo realizar emprestimo de {lista[i].titulo}? S/N");
            confirma = Convert.ToChar(Console.ReadLine());

            if (confirma == 's' || confirma == 'S')
            {
                Console.Write("Qual a data do emprestimo:");
                emp.dataEmprestimo = Convert.ToInt32(Console.ReadLine());
                Console.Write("Qual o nome da pessoa:");
                emp.nomePessoaEmprestimo = Console.ReadLine();
                emp.emprestado = 'S';
                Console.WriteLine($"Emprestimo de {lista[i].titulo} realizado com sucesso!");
                emp.tituloJogo = lista[i].titulo;

                listaEmp.Add(emp);
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Esse jogo não está cadastrado.");
            break;
        }
    }
}

static int Menu()
{
    int op;
    Console.WriteLine("*** Catalogo e controle de coleções de jogos v1 ***");
    Console.WriteLine("1 - Cadastrar");
    Console.WriteLine("2 - Listar");
    Console.WriteLine("3 - Realizar emprestimo");
    Console.WriteLine("4 - Listar Emprestimos");
    Console.WriteLine("5 - Realizar devolução");
    Console.WriteLine("6 - Procurar por título");
    Console.WriteLine("7 - Listar todos os jogos de um console");

    op = Convert.ToInt32(Console.ReadLine());
    return op;
}
static void Main()
{
    List<jogo> lista = new List<jogo>();
    List<emprestimo> listaEmprestimo = new List<emprestimo>();

    bool programa = true;
    int operador;
    do
    {
        operador = Menu();
        switch (operador)
        {
            case 1:
                Cadastrar(lista);
                break;
            case 2:
                listarJogos(lista);
                break;
            case 3:
                Emprestimo(lista, listaEmprestimo);
                break;
            case 4:
                listarEmprestimo(listaEmprestimo);
                break;
            case 5:
                Devolucao(listaEmprestimo);
                break;
            case 6:
                procurarPorTitulo(lista);
                break;
            case 7:
                procurarPorConsole(lista);
                break;
        }
        Console.ReadKey();
        Console.Clear();
    } while (programa);

}


