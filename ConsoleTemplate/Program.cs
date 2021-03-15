using System;


namespace ConsoleTemplate
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"\"The length of the args is {args.Length}");
            Console.WriteLine("Following are the args passed:");

            for(int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Arg {i + 1} = {args[i]}");
            }
        }
    }
}
