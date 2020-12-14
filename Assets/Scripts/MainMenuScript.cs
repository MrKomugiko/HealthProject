using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    [SerializeField] TextMeshProUGUI userText;

[SerializeField] string nick;
    bool updateUserDataIsRequired = true;
    void Update()
    {
        nick = GameManager.GetComponent<StaticSelectedUserData>().currentSelectedUserData.NickName.ToString();
        if (updateUserDataIsRequired)
        {
            if (nick == "")
            {
                print("nick not found");
                updateUserDataIsRequired = true;
            } 
            else
            {
                print("nick is setting up");
                userText.SetText("User: " + nick + ".");
                print("user [" + nick + "] is setted2.");
                updateUserDataIsRequired = false;
            }
        }
    }
}
