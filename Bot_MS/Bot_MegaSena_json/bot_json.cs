using System;
using System.Net;
using System.Linq;
using Newtonsoft.Json;

namespace Bot_MegaSena_json
{
    class bot_json
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira o número do concurso");
            string num_Concurso = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(num_Concurso))
            {
                num_Concurso = "2355";
            }

            string url = @"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage//p=concurso=" + num_Concurso;
            string json;

            using (WebClient wc = new WebClient()) //criar no using faz com que o objeto seja deletado no fim do programa
            {
                wc.Headers["Cookie"] = "security=true";
                json = wc.DownloadString(url); 
            } // eh preciso tranformar o objeto json em .NET com a biblioteca Newtonsoft.Json

            Resultado resultado_MS = JsonConvert.DeserializeObject<Resultado>(json); //Vai desserializar um objeto json no tipo Resultado, ou seja 
                                                                                     //pega a variavel json e transforma em Resultado   
            Console.WriteLine(resultado_MS.tipoJogo);
            Console.WriteLine("\n");
            Console.WriteLine("VALOR ARRECADADO: ");
            Console.WriteLine(resultado_MS.valorArrecadado);
            Console.WriteLine("\n");

            resultado_MS.listaDezenas.ForEach(num =>  //imprimir lista 
            {
                Console.WriteLine(num.Substring(1, 2)); // melhora o num de casas decimais
            });

        }

    }
}