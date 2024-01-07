using TMPro;
using UnityEngine;

public sealed class TimeDisplay : MonoBehaviour
{
    [SerializeField] private CountDown countDown;
    [SerializeField] private TextMeshProUGUI timeText;

    private void OnEnable() => countDown.OnTick += UpdateTime;

    private void OnDestroy() => countDown.OnTick -= UpdateTime;

    private void UpdateTime(int time) => timeText.text = $"Time: {time}";
}