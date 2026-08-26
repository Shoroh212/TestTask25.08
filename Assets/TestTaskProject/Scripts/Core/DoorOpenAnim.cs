using UnityEngine;

public class DoorOpenAnim : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _openHeight = 6f;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private bool _isOpening;

    private void Start()
    {
        _startPosition = _door.transform.position;
        _targetPosition = _startPosition + Vector3.up * _openHeight;


    }

    private void Update()
    {
        if (!_isOpening)
            return;

        _door.transform.position = Vector3.MoveTowards(
            _door.transform.position,
            _targetPosition,
            _speed * Time.deltaTime
        );

        if (_door.transform.position == _targetPosition)
        {
            _isOpening = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            OpeningDoor();
        }
    }

    private void OpeningDoor()
    {
        _isOpening = true;
    }
}
