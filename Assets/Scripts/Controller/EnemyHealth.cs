using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Animator animator;
    [SerializeField] private float totalHealth = 100f;

    private float _health;

    private void Start()
    {
        _health = totalHealth;
        InitHealth();
    }

    public void ReduceHealth(float damage) 
    {
        _health -= damage;
        InitHealth();
        animator.SetTrigger("takeDamage");
        if (_health <= 0) {
            Die();
        }
    }

    private void InitHealth() 
    {
        healthSlider.value = _health / totalHealth;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
