using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    [SerializeField] TextMeshProUGUI userText;

    void Update(){
            
        userText.SetText("User: "+GameManager.GetComponent<StaticSelectedUserData>().currentSelectedUserData.NickName.ToString()+".");
    }
}
