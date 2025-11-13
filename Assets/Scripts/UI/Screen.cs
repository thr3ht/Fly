using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button Button;

    [SerializeField] private float _pulseDuration;
    [SerializeField] private float _pulseScale;

    private void Start()
    {
        ButtonPulsation();
    }

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }

    public abstract void Open();
    public abstract void Close();

    protected abstract void OnButtonClick();

    private void ButtonPulsation()
    {
        Button.transform.DOScale(_pulseScale, _pulseDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine)
            .SetUpdate(true);
    }
}