using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //Preciso para formatar dados em bits;

namespace AprendendoFiles      //Manipulando Arquivos:
{
    class Program
    {
        [System.Serializable]
        struct Produto
        {
            public string nome;
            public float preco;

            public Produto(string nome, float preco)
            {
                this.nome = nome;
                this.preco = preco;
            }
        }
        static void Main(string[] args)
        {
            //Manipulando Arquivos de Texto:

            //Stream => fluxo de comunicação entre c# e o arquivo, no caso .txt
            //StreamWriter escritor = new StreamWriter("teste.txt");

            //criando um fluxo Append, onde não excluí os dados antigos do arquivo;
            StreamWriter escritor = File.AppendText("teste.txt");

            //escritor.WriteLine("Udemy");
            escritor.WriteLine("Eduardo");

            escritor.Close(); // => Para fechar arquivo dentro do código; 
            
            //escritor.WriteLine("Eduardo");
            //escritor.WriteLine("Rezende");
            //escritor.WriteLine("Meu Nome");

            //Lendo Arquivos de Texto:

            StreamReader leitor = new StreamReader("teste.txt");

            //ReadToEnd lê todos os arquivos do texto até o fim;
            string conteudo = leitor.ReadToEnd(); //Salva todo texto do arquivo dentro de uma unica string;

            Console.WriteLine(conteudo);

            //Utilidade em salvar cada linha do arquivo dentro de uma Lista/Array;
            List<string> linhas = new List<string>();

            //Método de ler todas as linhas do arquivo de forma mais limpa;
            string linha = "";
            while (linha != null)
            {
                linha = leitor.ReadLine();
                if (linha != null)
                {
                    linhas.Add(linha); // => Cada linha uma variável !=
                    //Console.WriteLine(linha);
                }
            }

            leitor.Close();

            //Console.WriteLine(linhas[7]);

            foreach (string nome in linhas)
            {
                Console.WriteLine(nome);
            }

            /*Console.WriteLine(leitor.ReadLine());
            Console.WriteLine(leitor.ReadLine());    Forma demorada e errada;
            Console.WriteLine(leitor.ReadLine());    ReadLine lê linha por linha do arquivo de texto;
            Console.WriteLine(leitor.ReadLine());
            Console.WriteLine(leitor.ReadLine());*/

            Console.WriteLine("Arquivo gerado !");
            Console.ReadLine();

            //Manipulando Arquivos Binários: +++++++++++++++++++++++++++++++++++

            //Vantagem de trabalhar com arquivos binários é a possibilidade de salvar listas inteiras de dados; 
            //Salvam listas inteiras de dados em um único arquivo;

            //int a = 120;
            //string nome = "edu";   Exemplos de variáveis que podemos criar para armazenar dados dentro do arquivo;
            //float b = 12.5f;

            List<string> lang = new List<string>();  //Útil para armazenar Lists;
            lang.Add("C#");
            lang.Add("Java");
            lang.Add("JavaScript");
            lang.Add("PHP");

            Produto banana = new Produto("Banana", 5f);
            
            //Criando um arquivo binário:
            FileStream stream = new FileStream("meuarquivo.edu", FileMode.OpenOrCreate);
            BinaryFormatter codificador = new BinaryFormatter();

            //Escrevendo dados em um arquivo binário:
            //codificador.Serialize(stream, lang);
            //codificador.Serialize(stream, banana);

            //codificador.Serialize(stream, a);  //Serealizador, função => pega um formato de dado e converte para uma cadeia de bits;
            //codificador.Serialize(stream, nome);  Exemplos de dados que podemos salvar no arquivo;
            //codificador.Serialize(stream, b); 

            //Para ler um arquivo binário = precisamos saber as ordens corretas de onde cada dado do arquivo está;
            List<string> listadoArquivo = (List<String>)codificador.Deserialize(stream); // => Deserialização é o processo de leitura em um arquivo binário;
            Produto prod = (Produto)codificador.Deserialize(stream);

            Console.WriteLine(listadoArquivo[3]);
            Console.WriteLine(prod.nome);
           
            stream.Close();
            
            Console.ReadLine();

            Console.WriteLine("Foi");
            Console.ReadLine();
        }
    }
}
