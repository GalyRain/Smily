using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public void ResultHandler()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
        Time.timeScale = 1f;
    }
}