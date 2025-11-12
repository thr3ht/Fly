using UnityEngine;
using Zenject;

public class StartState : State
{
    private StartScreen _startScreen;
    private GameOverScreen _gameOverScreen;

    [Inject]
    public void Construct(StartScreen startScreen, GameOverScreen gameOverScreen)
    {
        _startScreen = startScreen;
        _gameOverScreen = gameOverScreen;
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        
        _startScreen.Open();
        _gameOverScreen.Close();
    }
}