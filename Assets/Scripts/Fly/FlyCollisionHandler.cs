using UnityEngine;
using Zenject;

public class FlyCollisionHandler : MonoBehaviour
{
    private Fly _fly;

    [Inject]
    public void Construct(Fly fly)
    {
        _fly = fly;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ScoreZone>(out _))
        {
            _fly.IncreaseScore();
        }
        else
        {
            _fly.Die();
        }
    }
}