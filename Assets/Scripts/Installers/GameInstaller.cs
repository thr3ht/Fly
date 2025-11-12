using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Fly _fly;
    [SerializeField] private BarrierGenerator _barrierGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<PlayerDiedSignal>();
        Container.DeclareSignal<ScoreChangedSignal>();
        Container.DeclareSignal<PlayButtonClickedSignal>();
        Container.DeclareSignal<RestartButtonClickedSignal>();

        Container.Bind<Fly>().FromInstance(_fly).AsSingle();
        Container.Bind<BarrierGenerator>().FromInstance(_barrierGenerator).AsSingle();
        Container.Bind<StartScreen>().FromInstance(_startScreen).AsSingle();
        Container.Bind<GameOverScreen>().FromInstance(_gameOverScreen).AsSingle();
    }
}