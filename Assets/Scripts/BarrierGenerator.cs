using UnityEngine;

public class BarrierGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _barrierPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private int _poolSize = 10;
    
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;
    
    private Camera _camera;
    private ObjectPool<Transform> _pool;
    private float _elapsedTime = 0;

    private void Start()
    {
        _camera = Camera.main;
        _pool = new ObjectPool<Transform>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject barrier = Instantiate(_barrierPrefab, _container);
            barrier.SetActive(false);
            _pool.Add(barrier.transform);
        }
    }

    private void Update()
    {
        SpawnBarrier();
        DisableBarriersOffScreen();
    }
    
    public void ResetBarriers()
    {
        _pool.ResetPool();
        _elapsedTime = 0;
    }

    private void SpawnBarrier()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (_pool.TryGet(out Transform barrier))
            {
                _elapsedTime = 0;
                
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                barrier.position = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                barrier.gameObject.SetActive(true);
            }
        }
    }

    private void DisableBarriersOffScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(-0.5f, 0));

        foreach (var barrier in _pool.GetActive())
        {
            if (barrier.position.x < disablePoint.x)
            {
                barrier.gameObject.SetActive(false);
            }
        }
    }
}
