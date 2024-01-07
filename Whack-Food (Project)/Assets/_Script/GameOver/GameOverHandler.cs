using UnityEngine;

namespace ObserverPattern.GameOver
{
    public sealed class GameOverHandler : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private FoodSpawner foodSpawner;
        [SerializeField] private CountDown countDown;

        private void OnEnable()
        {
            Add(uiManager);
            Add(foodSpawner);
            Add(countDown);
        }

        private void OnDestroy() => Clear();

        private void Add(IGameOverObserver obs) => GameOver.Instance.Add(obs);

        private void Clear() => GameOver.Instance.Clear();
    }
}