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
   try
   {
        nick = GameManager.GetComponent<StaticSelectedUserData>().currentSelectedUserData.PersonalData.Name.ToString();
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
                userText.SetText("Witaj " + nick + ".");
                GameManager.GetComponent<StaticSelectedUserData>().SaveUserForNextLogin();
                updateUserDataIsRequired = false;
            }
        }
    
   }
   catch (System.Exception)
   {
       
   }
    }
}
