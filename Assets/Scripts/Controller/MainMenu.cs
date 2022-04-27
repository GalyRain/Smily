using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void StartHandler() 
    {
        SceneManager.LoadScene(1);
    }

    public void ResultHandler()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitHandler()
    {
        Application.Quit();
    }
}