using Newtonsoft.Json;
using System;


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var outVal = new Class1().ParseFiles("C:\\Users\\fjina\\OneDrive\\Ambiente de Trabalho\\Victoria 3\\game\\common\\technology\\technologies");
            Console.WriteLine(JsonConvert.SerializeObject(outVal));

            Console.ReadLine();
        }
    }
}
