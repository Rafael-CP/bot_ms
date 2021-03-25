using System;
using System.Net; // Para poder usar o WebClient

namespace Bot_MegaSena
{
    class bot
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

        Console.ReadKey(); //para o programa não fechar sozinho ao fim da execução (Náo eh mais necessario)
        }
    }
}
