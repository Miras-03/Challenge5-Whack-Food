using ObserverPattern.Start;
using ObserverPattern.GameOver;
using UnityEngine;

public class UIManager : MonoBehaviour, IGameOverObserver, IStartObserver
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject chooseLevel;

    private void Start()
    {
        GameOver(false);
        chooseLevel.SetActive(true);
    }

    public void ExecuteStart(float rate) => chooseLevel.SetActive(false);

    public void ExecuteGameOver() => GameOver(true);

    private void GameOver(bool flag) => gameOverPanel.SetActive(flag);
}