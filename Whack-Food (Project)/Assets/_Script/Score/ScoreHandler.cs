using UnityEngine;

namespace ObserverPattern.Score
{
    public sealed class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private ScoreDisplay scoreDisplay;

        private void OnEnable()
        {
            AddObserver(ScoreSingleton.Instance);
            AddObserver(scoreDisplay);
        }

        private void OnDestroy() => Clear();

        private void AddObserver(IScoreObserver observer) => Score.Instance.Add(observer);

        private void Clear() => Score.Instance.Clear();
    }
}