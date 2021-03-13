using System;
using System.Collections.Generic;

namespace filosofos
{
    class Program
    {
        public const int totalFilosofos = 5;
        public static int totalHashis = 5;
        public static int filosofosComFome = 0;
        public static int filosofosComendo = 0;
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Filosofo> filosofos = new List<Filosofo>();
            for (int i = 0; i < Program.totalFilosofos; i++)
            {
                filosofos.Add(new Filosofo(i));
            }
            int ciclos = 1;
            while (true)
            {
                Console.Write($"iniciando ciclo {ciclos} ");
                foreach (var filosofo in filosofos)
                {
                    if (Program.totalHashis > 1 && Program.filosofosComendo < 2)
                    {
                        filosofo.PegarHasi();
                        filosofo.Start();
                    }
                    if (filosofo.Status == 'P') filosofosComFome += 1;
                    Console.Write($"{filosofo} ");
                }
                Console.WriteLine();
                if (Program.filosofosComFome == totalFilosofos) break;
                ciclos += 1;
            }
            Console.WriteLine(ciclos);
        }
    }
}
