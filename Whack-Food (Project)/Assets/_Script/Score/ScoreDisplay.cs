using TMPro;
using UnityEngine;
using ObserverPattern.Score;

public class ScoreDisplay : MonoBehaviour, IScoreObserver
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int scoreCount;

    private void Start() => UpdateScore();

    public void ExecutePoint(int point) => UpdateScore();

    private void UpdateScore()
    {
        scoreCount = ScoreSingleton.Instance.Score;
        scoreText.text = $"Score: {scoreCount}";
    }
}