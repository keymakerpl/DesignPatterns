using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{

    public class RandomNumberGenerator
    {
        public EventHandler<RandomNumberEventArgs> NumberGenerated;
        public EventHandler Finished;

        public void GenerateNumbers()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                OnNumberGenerated(String.Format("Wylosowano liczbę: {0}", random.Next()));
            }
            OnFinish();
        }

        protected virtual void OnNumberGenerated(string message)
        {
            NumberGenerated?.Invoke(this, new RandomNumberEventArgs() { messageArg = message });
        }

        protected virtual void OnFinish()
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }

    }
}
