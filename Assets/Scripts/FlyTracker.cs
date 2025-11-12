using UnityEngine;

public class FlyTracker : MonoBehaviour
{
    [SerializeField] private Fly _fly;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        transform.position = new Vector3(_fly.transform.position.x - _xOffset, transform.position.y, transform.position.z);
    }
}
