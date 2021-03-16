using System;
using System.Collections.Generic;

namespace filosofos
{
    class Program
    {
        public const int totalFilosofos = 5;
        public static int totalHashis = 5;
        public static int filosofosPensando = 0;
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
            List<decimal> percentile = new List<decimal>();
            while (true)
            {
                try
                {
                    Filosofo lastToEat = null;
                    foreach (var filosofo in filosofos)
                    {
                        if (Program.totalHashis > 1 && Program.filosofosComendo < 2)
                        {
                            filosofo.PegarHasi();
                            lastToEat = filosofo;
                            filosofo.Start();
                            continue;
                        }
                        if (filosofo.Status == 'P')
                        {
                            filosofo.Wait(lastToEat);
                            filosofosPensando += 1;
                        }
                        Console.Write($"{filosofo} ");
                    }
                    Console.WriteLine();
                    percentile.Add( Program.filosofosPensando / Program.filosofosComendo );
                    if (Program.filosofosPensando == totalFilosofos) break;
                    ciclos += 1;
                    filosofosPensando = 0;
                }
                catch{
                    break;
                }
            }
            for (int i = 0; i < percentile.Count; i++)
            {
                Console.WriteLine($"ciclo: {i + 1} || percentile tpensando/tcomendo: {percentile[i]} ");
            }
        }
    }
}
