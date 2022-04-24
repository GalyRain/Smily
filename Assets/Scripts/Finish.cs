using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject massageUI;

    private bool _isActivated = false;

    public void Activate() 
    {
        _isActivated = true;
        massageUI.SetActive(false);
    }

    public void FinishLevel() 
    {
        if (_isActivated)
        {
            levelCompleteCanvas.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
        else {
            massageUI.SetActive(true);
        }
    }
}
