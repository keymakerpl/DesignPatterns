using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface IObserver
    {
        void Update(int value);
    }


    public class Target
    {
        private int value;
        List<IObserver> observers = new List<IObserver>();

        public Target()
        {
            value = 0;
        }

        public void AddObserver(IObserver observer)
        {
            if (observers.Contains(observer)) return;

            observers.Add(observer);

        }

        public void RemoveObserver(IObserver observer)
        {
            if (observers.Contains(observer)) observers.Remove(observer);
        }

        void Notify()
        {
            observers.ForEach(e => e.Update(value));
        }
    }


    public class ObserverClass
    {

    }
}
