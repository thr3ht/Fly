using UnityEngine;
using Zenject;

public class GameOverState : State
{
    private GameOverScreen _gameOverScreen;
    [SerializeField] private AdManager _adManager;

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