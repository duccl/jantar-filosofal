using System;
using System.Threading;

namespace filosofos
{
	public class Filosofo
  	{
		public Filosofo(int id){
			this.Id = id;
			this.thread = new Thread(new ThreadStart(this.Eat));
		}
		public int Id {get; set;}
		public Thread thread {get; set;}
		public char Status {get; set;} = 'P';
		public bool IsEating => Status == 'E';
		public void Start(){
			try{
				thread.Start();
			}
			catch(ThreadStateException tse){
				string errMotivation = Status == 'P' ? "starve" : "ate a lot";
				Console.WriteLine($"\n {this} {errMotivation} because {tse?.Message}! \n Call ambulance now....🚑");
				Environment.Exit(1);
			}
		}
		public void Stop(){
            DevolverHashi();
			thread.Interrupt();
		}
        public void PegarHasi(){
			HashiCount += 1;
			Program.totalHashis -=1;
		}
        public void DevolverHashi(){
			HashiCount -= 1;
            Program.totalHashis += 1;
		}
		
    	public int HashiCount {get; set;} = 1;

		private void Eat(){
			if(HashiCount < 2 && Program.totalHashis < 2) return;
			Status = 'E';
			Program.filosofosComendo += 1;
            Program.filosofosComFome -= 1;
			Thread.Sleep( new Random().Next(10) * 10/HashiCount);
			Status = 'P';
            Stop();
            Program.filosofosComFome += 1;
			Program.filosofosComendo -= 1;
            thread = new Thread(new ThreadStart(Eat));
		}
		
		public override string ToString(){
			return $"[{typeof(Filosofo)} {Id}] {Status}";
		}
  	}
}