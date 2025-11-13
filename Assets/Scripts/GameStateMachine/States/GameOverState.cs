using UnityEngine;
using Zenject;

public class GameOverState : State
{
    [SerializeField] private AdManager _adManager;
    
    private GameOverScreen _gameOverScreen;

    [Inject]
    public void Construct(GameOverScreen gameOverScreen)
    {
        _gameOverScreen = gameOverScreen;
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();

        if (_adManager != null)
        {
            _adManager.ShowBanner();
        }
        else
        {
            return;
        }
    }
}