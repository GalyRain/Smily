using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private GameObject currentHitObject;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private float circleRadius;
    [SerializeField] private float maxDistance;

    private EnemyController _enemyController;
    private Vector2 _origin;
    private Vector2 _direction;

    private float _currentHitDistance;

    private void Start()
    {
        _enemyController = GetComponent<EnemyController>();
    }

    private void Update() 
    {
        if (_enemyController.IsFacingRight)
        {
            _direction = Vector2.right;
        }
        else {
            _direction = Vector2.left;
        }
        _origin = transform.position;
        

        RaycastHit2D hit = Physics2D.CircleCast(_origin, circleRadius, _direction, maxDistance, layerMask);

        if (hit) {
            currentHitObject = hit.transform.gameObject;
            _currentHitDistance = hit.distance;
            if (currentHitObject.CompareTag("Player")) {
            }
            else {
                currentHitObject = null;
                _currentHitDistance = maxDistance;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_origin, _origin + _direction * _currentHitDistance);
        Gizmos.DrawWireSphere(_origin + _direction * _currentHitDistance, circleRadius);
    }

}
