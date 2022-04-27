using UnityEngine;
using UnityEngine.UI;

public class ButtolController : MonoBehaviour
{
    public InputField input;
    private BD bd;

    void Start()
    {
        bd = GetComponent<BD>();
    }
    
    public void ButtonGet()
    {
        StartCoroutine(bd.LoadData(input.text));
    }

    public void ButtonAdd()
    {
        bd.SaveData(input.text);
    }

    public void ButtonRemove()
    {
        bd.RemoveData(input.text);
    }

    public void ButtonGetAllUser()
    {
        StartCoroutine(bd.GetAllUser(input.text));
    }
}
