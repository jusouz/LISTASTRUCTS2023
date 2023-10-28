using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
class Program { struct TipoBanda 
    { 
        public string nome;
        public string genero;
        public int integrantes;
        public int ranking;
    }
    
    static void addBanda(List<TipoBanda> lista)  
    {    
        TipoBanda novaBanda = new TipoBanda();      
        Console.Write("Nome da banda:");     
        novaBanda.nome = Console.ReadLine();  
        Console.Write("Genero da banda:");     
        novaBanda.genero = Console.ReadLine();   
        Console.Write("Integrantes:");     
        novaBanda.integrantes = Convert.ToInt32(Console.ReadLine());      
        Console.Write("Ranking:");   
        novaBanda.ranking = Convert.ToInt32(Console.ReadLine());
        lista.Add(novaBanda);  
    }  
    static void listaBandas(List<TipoBanda> lista)  
    {      
        int qtd = lista.Count();
        for (int i = 0; i < qtd; i++)      
        {           
            Console.WriteLine("*** Dados da banda: ***");        
            Console.WriteLine("Nome:" + lista[i].nome);         
            Console.WriteLine("Genero:" + lista[i].genero);         
            Console.WriteLine("Integrantes:" + lista[i].integrantes);        
            Console.WriteLine("Ranking:" + lista[i].ranking);        
        }
    }    

    static void salvarDados(List<TipoBanda> bandas, string nomeArquivo)
    {
        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            foreach (TipoBanda banda in bandas)
            {
                writer.WriteLine($"{banda.nome},{banda.genero},{banda.integrantes},{banda.ranking}");
            }
        }
        Console.WriteLine("Dados salvos com sucesso!");
    }


    static void carregarDados(List<TipoBanda> bandas, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                TipoBanda banda = new TipoBanda
                {
                    nome = campos[0],
                    genero = campos[1],
                    integrantes = int.Parse(campos[2]),
                    ranking = int.Parse(campos[3])
                };
                bandas.Add(banda);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    static int menu()    
    {
        Console.WriteLine("*** Sistema de cadastro de Bandas ***");
        Console.WriteLine("1-Adicionar Banda");        
        Console.WriteLine("2-Listar");
        Console.WriteLine("0-Sair");
        Console.WriteLine("Entre com uma opção:");
        int op = Convert.ToInt32(Console.ReadLine());    
        return op;    
    }  
    static void Main()    
    {   
        List<TipoBanda> listadebandas = new List<TipoBanda>();
        int op;
        carregarDados(listadebandas, "dadosBandas.txt");
        do
        {
             op = menu();
            switch (op)
            {
                case 1:
                    addBanda(listadebandas);
                    break;
                case 2:
                    listaBandas(listadebandas);
                    break;
                case 0:
                    Console.WriteLine("Saindo..");
                    salvarDados(listadebandas, "dadosBandas.txt");
                    break;
            }         
            Console.ReadKey();         
            Console.Clear();   
        } while (op != 0);       
        //--------------------        
        // Mostrar os dados       
        Console.ReadLine(); 
        }
}
