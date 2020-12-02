using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World on Ubuntu!");
            var lst = GetSampleList();
            Console.WriteLine($"List size is {lst.Count}");
            
            foreach(var item in lst)
                Console.WriteLine(item);
                
                
            Console.Write("Informe um item para localizar: ");
            var qry = Console.ReadLine();
            
            if (lst.FirstOrDefault(o => o == qry) != null)
                Console.WriteLine($"{qry} foi encontrado!");
            else
                Console.WriteLine($"{qry} não foi encontrado");
        }
        
        static List<string> GetSampleList() 
        {
            return new List<string>(
                new string[] { "item 1", "item 2", "item 3" });
        }
    }
}
