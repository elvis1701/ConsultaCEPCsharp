using ConsultarCEPs.CEPService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsultarCEPs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o CEP que deseja consultar: ");
            var cep = Console.ReadLine();

            if (!string.IsNullOrEmpty(cep))
            {
                ConsultaCEP(cep);
            }

        }

        public static void ConsultaCEP(string cep)
        {
            using (var ws = new AtendeClienteClient())
            {
                try
                {
                    var resposta = ws.consultaCEP(cep);

                    Console.WriteLine("");
                    Console.WriteLine("Endereço Localizado: ");
                    Console.WriteLine(string.Format("Rua: {0}", resposta.end));
                    Console.WriteLine(string.Format("Bairro: {0}", resposta.bairro));
                    Console.WriteLine(string.Format("Cidade: {0}", resposta.cidade));
                    Console.WriteLine(string.Format("UF: {0}", resposta.uf));
                    Console.WriteLine(string.Format("CEP: {0}", resposta.cep));
                    Console.WriteLine("");
                    Console.WriteLine("Pressione qualquer tecla para encerrar...");

                    Console.ReadKey();
                }
                catch (FaultException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("CEP inválido!");
                    Console.WriteLine("");
                    Console.WriteLine("Pressione qualquer tecla para encerrar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
