using System.Collections.Generic;

namespace ObserverPattern.GameOver
{
    public sealed class GameOver
    {
        private static GameOver instance;

        public static GameOver Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameOver();
                return instance;
            }
        }

        private List<IGameOverObserver> observers = new List<IGameOverObserver>();

        public void Add(IGameOverObserver obs) => observers.Add(obs);

        public void Clear() => observers.Clear();

        public void Notify()
        {
            foreach (IGameOverObserver obs in observers)
                obs.ExecuteGameOver();
        }
    }
}