using Zenject;

public class StartToGameTransition : Transition
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<PlayButtonClickedSignal>(OnPlayButtonClick);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<PlayButtonClickedSignal>(OnPlayButtonClick);
    }

    private void OnPlayButtonClick()
    {
        NeedTransit = true;
    }
}