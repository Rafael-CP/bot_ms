using System;
using System.Net; // Para usar o WebClient
using System.Text.RegularExpressions; // Para usar o Regex
using System.Collections.Generic; //Para usar o List
using System.Linq; // Manipular listas

namespace Bot_MegaSena
{
    class bot_html
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira o número do concurso");
            string num_Concurso = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(num_Concurso)){
                num_Concurso = "2355";
            }

        string url = @"http://www1.caixa.gov.br/loterias/loterias/megasena/megasena_pesquisa_new.asp?submeteu=sim&opcao=concurso&txtConcurso=" + num_Concurso;
        string html;

        using (WebClient wc = new WebClient()) //criar no using faz com que o objeto seja deletado no fim do programa
        {
                wc.Headers["Cookie"] = "security=true";
                html = wc.DownloadString(url); //baixa stringa url do site
        }
        Console.WriteLine(html);

        // Agora vamos filtrar a html obtida para obtermos apenas o que queremos
        html = html.Replace("<span class=\"num_sorteio\"><ul>", ""); //retira span
        html = html.Replace("</ul></span>", ""); 
        html = html.Replace("</li>", "");

        Console.WriteLine("\n");
        Console.WriteLine(html);
        Console.WriteLine("\n");

        // Os elementos que queremos estao dentro de <li>, portanto temos que filtrar ainda mais
        string[] vet = Regex.Split(html,"<li>"); //split faz com que tudo nos <li> virem elementos no vetor 
        List<int> resultado = new List<int>(); //cria uma lista em que sera mostrado o resultado
        // cada elemento de vet sera passado para lista. No ultimo elemento deverá ocorrer uma filtragem extra 

        for(int i = 1; i <= 6; i++)
            {
                if (i == 6)
                {
                    resultado.Add(int.Parse(vet[i].Substring(0, 2))); // pega os dois primeiros caracteres apenas
                }
                else
                {
                    resultado.Add(int.Parse(vet[i]));
                }
            }

        Console.WriteLine("Concurso" + num_Concurso);
        Console.WriteLine("Resultado:");
        resultado.OrderBy(x => x).ToList().ForEach(num => { //ordena o proprio valor em ordem crescente 
            Console.WriteLine(num);                         //e os coloca em uma lista para poder usar o ForEach
        });  
            Console.ReadKey(); //para o programa não finalizar sozinho ao fim da execução (Nao eh mais necessario)
        }
    }
}
