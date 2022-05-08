using UnityEngine;
using System;
using System.Diagnostics;

public class Finish : MonoBehaviour
{
    Stopwatch watch = new Stopwatch();

    [SerializeField] private GameObject levelCompleteCanvas;
    [SerializeField] private GameObject massageUI;

    private bool _isActivated = false;

    public void Start()
    {
        watch.Start();
    }
    public void Activate() 
    {
        _isActivated = true;
        massageUI.SetActive(false);

        watch.Stop();
        TimeSpan ts = watch.Elapsed;
        Result.AddNewResult(ts);
        GameState.State = GameState.States.Pass;
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
