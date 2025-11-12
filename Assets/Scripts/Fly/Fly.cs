using UnityEngine;
using Zenject;

[RequireComponent(typeof(FlyMover))]
public class Fly : MonoBehaviour
{
    private FlyMover _mover;
    private int _score;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void Start()
    {
        _mover = GetComponent<FlyMover>();
    }

    public void ResetPlayer()
    {
        _score = 0;
        _signalBus.Fire(new ScoreChangedSignal { NewScore = _score });
        _mover.Reset();
    }

    public void Die()
    {
        _signalBus.Fire<PlayerDiedSignal>();
    }

    public void IncreaseScore()
    {
        _score++;
        _signalBus.Fire(new ScoreChangedSignal { NewScore = _score });
    }
}