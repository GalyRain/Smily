using UnityEngine;
using UnityEngine.UI;

public class ButtolController : MonoBehaviour
{
    public InputField input;
    private BD database;

    void Start()
    {
        database = GetComponent<BD>();
    }
    
    public void ButtonGet()
    {
        StartCoroutine(database.LoadData(input.text));
    }

    public void ButtonAdd()
    {
        database.SaveData(input.text);
    }

    public void ButtonRemove()
    {
        database.RemoveData(input.text);
    }

    public void ButtonGetAllUser()
    {
        StartCoroutine(database.GetAllUser(input.text));
    }
}
