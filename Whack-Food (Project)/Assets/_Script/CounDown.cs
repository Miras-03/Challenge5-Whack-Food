using ObserverPattern.GameOver;
using ObserverPattern.Start;
using System;
using System.Collections;
using UnityEngine;

public sealed class CountDown : MonoBehaviour, IStartObserver, IGameOverObserver
{
    public Action<int> OnTick;
    [SerializeField] private int currentSecond = 60;
    private const int perSecond = 1;

    public void ExecuteStart(float rate) => StartCoroutine(CountDownRoutine());

    public void ExecuteGameOver() => StopAllCoroutines();

    private IEnumerator CountDownRoutine()
    {
        while (currentSecond > 0)
        {
            yield return new WaitForSeconds(perSecond);
            currentSecond -= perSecond;
            OnTick.Invoke(currentSecond);
        }
        GameOver.Instance.Notify();
    }

    public int CurrentSecond => currentSecond;
}