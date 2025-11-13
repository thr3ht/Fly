using Zenject;

public class Fly : IInitializable
{
    private FlyMover _flyMover;
    private int _score;
    private SignalBus _signalBus;

    [Inject]
    public void Construct(FlyMover flyMover, SignalBus signalBus)
    {
        _flyMover = flyMover;
        _signalBus = signalBus;
    }

    public void Initialize()
    {
    }

    public void ResetPlayer()
    {
        _score = 0;
        _signalBus.Fire(new ScoreChangedSignal { NewScore = _score });
        _flyMover.Reset();
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