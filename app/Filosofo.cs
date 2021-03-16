using System;
using System.Threading;

namespace filosofos
{
    public class Filosofo
    {
        public Filosofo(int id)
        {
            this.Id = id;
            this.thread = new Thread(new ThreadStart(this.Eat));
        }
        public int Id { get; set; }
        public Thread thread { get; set; }
        public char Status { get; set; } = 'P';
        public bool IsEating => Status == 'E';
        public void Start()
        {
            thread.Start();
        }
        public void Stop()
        {
            DevolverHashi();
            thread.Interrupt();
        }
        public void PegarHasi()
        {
            HashiCount += 1;
            Program.totalHashis -= 1;
        }
        public void DevolverHashi()
        {
            HashiCount -= 1;
            Program.totalHashis += 1;
        }

        public int HashiCount { get; set; } = 1;

        public void Wait(Filosofo b)
        {
            Console.Write($" {this} Let's wait.... ");
            if (b == null) return;
            lock (b)
            {
                while (b.IsEating) ;
                return;
            }
        }

        private void Eat()
        {
            if (HashiCount < 2 && Program.totalHashis < 2) return;
            Status = 'E';
            Program.filosofosComendo += 1;
            Program.filosofosPensando -= 1;
            Thread.Sleep(10 / HashiCount);
            Status = 'P';
            Program.filosofosPensando += 1;
            Program.filosofosComendo -= 1;
            Stop();
            thread = new Thread(new ThreadStart(Eat));
        }

        public override string ToString()
        {
            return $"[{typeof(Filosofo)} {Id}] {Status}";
        }
    }
}