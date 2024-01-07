using ObserverPattern.Start;
using ObserverPattern.GameOver;
using System.Collections;
using UnityEngine;

public sealed class FoodSpawner : MonoBehaviour, IGameOverObserver, IStartObserver
{
    [SerializeField] private Transform[] foods;
    private const int startSec = 1;

    public void ExecuteStart(float rate) => StartCoroutine(SpawnWithDelay(rate));

    public void ExecuteGameOver() => StopAllCoroutines();

    private IEnumerator SpawnWithDelay(float rate)
    {
        yield return new WaitForSeconds(startSec);
        while (true)
        {
            int randIndex = Random.Range(0, foods.Length);
            Instantiate(foods[randIndex]).GetComponent<Food>().Rate = rate;
            yield return new WaitForSeconds(rate);
        }
    }
}