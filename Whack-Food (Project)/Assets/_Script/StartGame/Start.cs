using System.Collections.Generic;

namespace ObserverPattern.Start
{
    public sealed class Start
    {
        private static Start instance;

        public static Start Instance
        {
            get
            {
                if (instance == null)
                    instance = new Start();
                return instance;
            }
        }

        private List<IStartObserver> observers = new List<IStartObserver>();

        public void Add(IStartObserver obs) => observers.Add(obs);

        public void Clear() => observers.Clear();

        public void Notify(float rate)
        {
            foreach (IStartObserver obs in observers)
                obs.ExecuteStart(rate);
        }
    }
}