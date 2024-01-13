using ObserverPattern.Start;
using ObserverPattern.GameOver;
using System.Collections;
using UnityEngine;

public sealed class FoodSpawner : MonoBehaviour, IGameOverObserver, IStartObserver
{
    private ObjectPooler pooler;

    private const int startSec = 1;
    private float rate;
    private const float minRange = -3.75f;
    private const float spaceBetweenSquares = 2.5f;

    private void Awake() => pooler = GetComponent<ObjectPooler>();

    public void ExecuteStart(float rate)
    {
        this.rate = RateSingleton.Instance.Rate = rate;
        pooler.CreateObjects(transform);
        StartCoroutine(SpawnWithDelay());
    }

    public void ExecuteGameOver() => StopAllCoroutines();

    private IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(startSec);
        while (true)
        {
            pooler.GetObject(PickUpTag(), RandomSpawnPosition(), Quaternion.identity);
            yield return new WaitForSeconds(rate);
        }
    }

    private string PickUpTag()
    {
        ObjectsType[] types = { ObjectsType.Skull, ObjectsType.EnergyCan, ObjectsType.Cookie, ObjectsType.Steak };
        int randIndex = Random.Range(0, types.Length);
        return types[randIndex].ToString();
    }

    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minRange + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minRange + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;
    }

    private int RandomSquareIndex() => Random.Range(0, 4);

    private enum ObjectsType
    {
        Skull,
        EnergyCan,
        Cookie,
        Steak
    }
}