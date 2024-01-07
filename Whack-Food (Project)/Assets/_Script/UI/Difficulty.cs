using UnityEngine;
using UnityEngine.UI;
using ObserverPattern.Start;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private FoodSpawner foodSpawner;
    private Button button;

    [SerializeField] private Difficulties difficulties;

    private void Awake() => button = GetComponent<Button>();

    private void OnEnable() => button.onClick.AddListener(ChooseDifAndStart);

    private void OnDestroy() => button.onClick.RemoveAllListeners();

    private void ChooseDifAndStart()
    {
        switch (difficulties)
        {
            case Difficulties.Easy:
                Start.Instance.Notify(2);
                break;
            case Difficulties.Medium:
                Start.Instance.Notify(1);
                break;
            case Difficulties.Hard:
                Start.Instance.Notify(0.5f);
                break;
            default:
                break;
        }
    }
}

internal enum Difficulties
{
    Easy, 
    Medium,
    Hard
}