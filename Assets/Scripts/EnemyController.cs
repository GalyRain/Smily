using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 2f;
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float TimeToWait = 5f;

    private Rigidbody2D _rigidbody;
    private Vector2 _leftBoundaryPosition;
    private Vector2 _rightBoundaryPosition;

    private bool _isFacingRight = true;
    private bool _isWait = false;
    private float  _waitTime;

    public bool IsFacingRight
    {
        get => _isFacingRight;
    }

   private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _leftBoundaryPosition = transform.position;
        _rightBoundaryPosition = _leftBoundaryPosition + Vector2.right * walkDistance;
        _waitTime = TimeToWait;
    }

    private void FixedUpdate()
    {
        Vector2 nextPoint = Vector2.right * walkSpeed * Time.fixedDeltaTime;

        if (!_isFacingRight) {
            nextPoint.x *= -1;
        }

        if (!_isWait) {
            _rigidbody.MovePosition((Vector2)transform.position + nextPoint);
        }
    }

    private void Update()
    {
        if (_isWait) {
            Wait();
        }

        if (ShouldWait()) {
            _isWait = true;
        }
    }    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftBoundaryPosition, _rightBoundaryPosition);
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private bool ShouldWait() 
    {
        bool isOutOfRightBoudary = _isFacingRight && transform.position.x >= _rightBoundaryPosition.x;
        bool isOutOfLeftBoudary = !_isFacingRight && transform.position.x <= _leftBoundaryPosition.x;

        return isOutOfRightBoudary || isOutOfLeftBoudary;
    }

    private void Wait() 
    {
        _waitTime -= Time.deltaTime;
        if (_waitTime < 0f) {
            _waitTime = TimeToWait;
            _isWait = false;
            Flip();
        }
    }
}
