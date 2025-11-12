using UnityEngine;

[RequireComponent(typeof(Fly))]
public class FlyCollisionHandler : MonoBehaviour
{
    private Fly _fly;

    private void Start()
    {
        _fly = GetComponent<Fly>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone scoreZone))
        {
            _fly.IncreaseScore();
        }
        else
        {
            _fly.Die();
        }
    }
}