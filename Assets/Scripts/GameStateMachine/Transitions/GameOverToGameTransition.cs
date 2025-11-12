using Zenject;

public class GameOverToGameTransition : Transition
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(GameOverScreen gameOverScreen, SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<RestartButtonClickedSignal>(OnRestartButtonClick);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<RestartButtonClickedSignal>(OnRestartButtonClick);
    }

    private void OnRestartButtonClick()
    {
        NeedTransit =  true;
    }
}