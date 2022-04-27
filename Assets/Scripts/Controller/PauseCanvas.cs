using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    public void ContinuedHeandler()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
