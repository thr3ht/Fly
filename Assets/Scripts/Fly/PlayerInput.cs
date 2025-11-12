using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputAction _playerInput;
    
    public event UnityAction OnFlyPressed;
    
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
