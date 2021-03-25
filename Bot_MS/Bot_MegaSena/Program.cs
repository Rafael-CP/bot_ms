using System;

namespace Bot_MegaSena
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira o número do concurso");
            string num_Concurso = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(num_Concurso))
            {
                num_Concurso = 2354;
            }
            //Console.ReadKey();
        }
    }
}
