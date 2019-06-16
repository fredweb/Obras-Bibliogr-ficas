using System;
using System.Collections.Generic;

namespace ObrasBiograficas
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberNames = default(int);
            var names = new List<NameAuthor>();
            string texto = "Por favor, digite um número de Nomes: ";
            string mensagemDeErro = "Valor digitado inválido!";
            int valor = GetInteger(texto, mensagemDeErro);

            for (int i = 0; i < valor; i++)
            {
                Console.WriteLine("Digite o nome do autor.");
                string input = Console.ReadLine();
                names.Add(new NameAuthor(input));
            }

            foreach (var autor in names)
            {
                Console.WriteLine(autor.ToString());
            }

        }

        public static int GetInteger(string texto, string mensagemDeErro)
        {
            Console.WriteLine(texto);
            string input = Console.ReadLine();
            int valor = 0;

            if (int.TryParse(input, out valor) && valor > 0)
            {
                return valor;
            }
            else
            {
                Console.WriteLine(mensagemDeErro);
                return GetInteger(texto, mensagemDeErro);
            }
        }
    }
}
