using UnityEngine;
using Firebase.Database;
using Firebase.Auth;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class BD : MonoBehaviour
{
    DatabaseReference dbRef;
    FirebaseAuth auth;
    public Text text;
    public Text textInfo;
    public InputField email;
    public InputField password;
    
    private void Start()
    {

        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this,null);
        auth.SignOut();
    }

    private void AuthStateChanged(object sender, System.EventArgs e)
    {
        if (auth.CurrentUser != null) {
            textInfo.text = "Вход выполнен" + auth.CurrentUser.Email;
        }
        else {
             textInfo.text = "Ошибка в почте или пароле";
        }
    }

    public void SaveData(string str) 
    {
        User user = new User(str, 15, "offline");

        string json = JsonUtility.ToJson(user);
        dbRef.Child("users").Child(str).SetRawJsonValueAsync(json);
        // dbRef.Child("users").SetValueAsync(str); //  одно значение
    }

    public IEnumerator LoadData(string str)
    {
        var user = dbRef.Child("users").Child(str).GetValueAsync();

        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if(user.Exception != null) {
            Debug.LogError(user.Exception);
        }
        else if(user.Result.Value == null) {
            Debug.Log("null");
        }
        else {
            DataSnapshot snapshot = user.Result;
            Debug.Log(snapshot.Child("age").Value.ToString() + snapshot.Child("name").Value.ToString());
            text.text = snapshot.Child("age").Value.ToString();
         }
    }

    public void RemoveData(string str) 
    {
        dbRef.Child("users").Child(str).RemoveValueAsync();
    }

    public IEnumerator GetAllUser(string str) 
    {        
        var users = dbRef.Child("users").OrderByChild("age").GetValueAsync();

        yield return new WaitUntil(predicate: () => users.IsCompleted);

        if(users.Exception != null) {
            Debug.LogError(users.Exception);
        }
        else if(users.Result.Value == null) {
            Debug.Log("null");
        }
        else {
            DataSnapshot snapshot = users.Result;
            foreach(DataSnapshot childSnapshot in snapshot.Children.Reverse())
            {
            Debug.Log(childSnapshot.Child("age").Value.ToString());
            text.text = childSnapshot.Child("age").Value.ToString();
            }
         }
    }

    public IEnumerator GetAllUserSort(string str) 
    {        
        var users = dbRef.Child("users").OrderByChild("age").LimitToFirst(2).GetValueAsync();

        yield return new WaitUntil(predicate: () => users.IsCompleted);

        if(users.Exception != null) {
            Debug.LogError(users.Exception);
        }
        else if(users.Result.Value == null) {
            Debug.Log("null");
        }
        else {
            DataSnapshot snapshot = users.Result;
            foreach(DataSnapshot childSnapshot in snapshot.Children.Reverse())
            {
            Debug.Log(childSnapshot.Child("age").Value.ToString());
            text.text = childSnapshot.Child("age").Value.ToString();
            }
         }
    }

    public void ButtonLogin() 
    {
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text);
    }

    public void ButtonRegistration()
    {
        auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text);    
    } 
}

public class User
{
    public string name;
    public int age;
    public string status;

    public User(string name, int age, string status) 
    {
        this.name = name;
        this.age = age;
        this.status = status;
    }

}