using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class FlyMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10f;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private PlayerInput _playerInput;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInput.OnFlyPressed += OnFly;

        _maxRotation = Quaternion.Euler(0f, 0f, _maxRotationZ);
        _minRotation = Quaternion.Euler(0f, 0f, _minRotationZ);

        Reset();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        _playerInput.OnFlyPressed -= OnFly;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }

    private void OnFly()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        _rigidbody.velocity = new Vector2(_speed, 0);
        transform.rotation = _maxRotation;
        _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
    }
}