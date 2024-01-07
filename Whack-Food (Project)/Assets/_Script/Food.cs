using UnityEngine;
using ObserverPattern.Score;
using ObserverPattern.GameOver;
using System.Collections;

public sealed class Food : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;

    [SerializeField] private int point = 5;
    private const float minRange = -3.75f;
    private const float spaceBetweenSquares = 2.5f;

    public float Rate { get; set; }

    private void Start()
    {
        transform.position = RandomSpawnPosition();
        StartCoroutine(FoodRemoveRoutine());
    }

    private void OnMouseDown()
    {
        Score.Instance.Notify(point);
        Explode();
    }

    private void OnCollisionEnter() => Explode();

    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minRange + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minRange + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;
    }

    private int RandomSquareIndex() => Random.Range(0, 4);

    private void Explode()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private IEnumerator FoodRemoveRoutine()
    {
        yield return new WaitForSeconds(Rate);
        if (gameObject != null)
        {
            Explode();
            GameOver.Instance.Notify();
        }
    }
}