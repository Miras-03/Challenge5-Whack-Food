using UnityEngine;
using ObserverPattern.Score;
using ObserverPattern.GameOver;
using System.Collections;

public sealed class Food : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;
    private RateSingleton rateSingleton;

    [SerializeField] private int point = 5;

    private void Awake() => rateSingleton = RateSingleton.Instance;

    private void OnEnable()
    {
        StartCoroutine(FoodRemoveRoutine());
    }

    private void OnMouseDown()
    {
        Score.Instance.Notify(point);
        Explode();
    }

    private void Explode()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private IEnumerator FoodRemoveRoutine()
    {
        yield return new WaitForSeconds(rateSingleton.Rate);
        if (gameObject != null)
        {
            Explode();
            GameOver.Instance.Notify();
        }
    }
}