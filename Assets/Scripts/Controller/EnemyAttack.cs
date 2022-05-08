using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private float damage = 20f;
    [SerializeField] private float timeToDamage = 1f;

    private float _damageTime;
    private bool _isDamega = true;

    private void Start()
    {
        _damageTime = timeToDamage;
    }

    private void Update()
    {
        if (!_isDamega) {
            _damageTime -= Time.deltaTime;
            if (_damageTime <= 0f) {
                _isDamega = true;
                _damageTime = timeToDamage;
            } 
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null && _isDamega) {
            playerHealth.ReduceHealth(damage);
            _isDamega = false;
        }
    }
}
