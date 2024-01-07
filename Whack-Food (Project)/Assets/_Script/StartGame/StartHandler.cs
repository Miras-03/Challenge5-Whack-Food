using UnityEngine;

namespace ObserverPattern.Start
{
    public sealed class StartHandler : MonoBehaviour
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

        private void Add(IStartObserver obs) => Start.Instance.Add(obs);

        private void Clear() => Start.Instance.Clear();
    }
}