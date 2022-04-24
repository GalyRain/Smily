using UnityEngine;

public class LeverArm : MonoBehaviour
{
    [SerializeField] Animator animator;
    private Finish _finish;

    private void Start()
    {
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
    }

    public void ActivateLeverArm()
    {
        animator.SetTrigger("activate");
        _finish.Activate();
    }
}
