using System.Collections.Generic;

namespace ObserverPattern.Score
{
    public sealed class Score
    {
        private static Score instance;

        public static Score Instance
        {
            get
            {
                if (instance == null)
                    instance = new Score();
                return instance;
            }
        }

        private List<IScoreObserver> observers = new List<IScoreObserver>();

        public void Add(IScoreObserver obs) => observers.Add(obs);

        public void Clear() => observers.Clear();

        public void Notify(int point)
        {
            foreach (IScoreObserver obs in observers)
                obs.ExecutePoint(point);
        }
    }
}