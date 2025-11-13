using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction OnFlyPressed;

    private PlayerInputAction _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInputAction();
        _playerInput.Player.Fly.performed += ctx => OnFlyPressed?.Invoke();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}