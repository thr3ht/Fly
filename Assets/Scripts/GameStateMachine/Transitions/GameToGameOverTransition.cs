using Zenject;

public class GameToGameOverTransition : Transition
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayerDiedSignal>(OnGameOver);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayerDiedSignal>(OnGameOver);
    }

    private void OnGameOver()
    {
        NeedTransit = true;
    }
}