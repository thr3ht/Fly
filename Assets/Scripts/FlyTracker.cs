using UnityEngine;
using Zenject;

public class FlyTracker : MonoBehaviour
{
    [SerializeField] private float _xOffset;
    
    private FlyMover _flyMover;

    [Inject]
    public void Construct(FlyMover flyMover)
    {
        _flyMover = flyMover;
    }
    
    private void Update()
    {
        transform.position =
            new Vector3(_flyMover.transform.position.x - _xOffset, transform.position.y, transform.position.z);
    }
}