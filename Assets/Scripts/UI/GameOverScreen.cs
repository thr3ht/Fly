using Zenject;

public class GameOverScreen : Screen
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    
    protected override void OnButtonClick()
    {
        _signalBus.Fire<RestartButtonClickedSignal>();
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }
}
