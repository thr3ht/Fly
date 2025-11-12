using TMPro;
using UnityEngine;
using Zenject;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void OnEnable()
    {
        _signalBus.Subscribe<ScoreChangedSignal>(OnScoreChanged);
    }

    private void OnDisable()
    {
        _signalBus.Unsubscribe<ScoreChangedSignal>(OnScoreChanged);
    }
    
    private void OnScoreChanged(ScoreChangedSignal signal)
    {
        _score.text = signal.NewScore.ToString();
    }
}
