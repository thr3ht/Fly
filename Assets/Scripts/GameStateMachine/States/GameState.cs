using UnityEngine;
using Zenject;

public class GameState : State
{
    [SerializeField] private AdManager _adManager;
    
    private Fly _fly;
    private BarrierGenerator _barrierGenerator;
    private StartScreen _startScreen;
    private GameOverScreen _gameOverScreen;

    [Inject]
    public void Construct(
        Fly fly, BarrierGenerator barrierGenerator, StartScreen startScreen, GameOverScreen gameOverScreen)
    {
        _fly = fly;
        _barrierGenerator = barrierGenerator;
        _startScreen = startScreen;
        _gameOverScreen = gameOverScreen;
    }

    private void OnEnable()
    {
        Time.timeScale = 1;
        _barrierGenerator.ResetPool();
        _fly.ResetPlayer();

        _startScreen.Close();
        _gameOverScreen.Close();
        
        if (_adManager != null)
        {
            _adManager.HideBanner();
        }
        else
        {
            return;
        }
    }
}