using UnityEngine;
using TMPro;

public class ShowResult : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI informText;

    void Start()
    {
        ResultCollection resultCollection = Result.TakeResult();

        if (resultCollection.results.Length != 0)
        {
            resultText.text = resultCollection.results[resultCollection.results.Length - 1].time;
        }
        else
        {
            resultText.text = "Oops! There is nothing here yet))";
        }

        switch (GameState.State)
        {
            case GameState.States.Faild:
                {
                    if (informText != null)
                    {
                        informText.text = "You've lost((";
                    }
                    break;
                }
            case GameState.States.Pass:
                {
                    if (informText != null)
                    {
                        informText.text = "You have won!";
                    }
                    break;
                }
            default: break;
        }
    }
}
