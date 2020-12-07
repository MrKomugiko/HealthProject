using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{

    [SerializeField] GameObject selectUsersWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick_Login(){
        SceneManager.LoadScene("MainScene");
    }
    
    public void OnClick_SelectUser(){
        selectUsersWindow.SetActive(true);
    }
    public void OnClick_BackFromSelectingUserWindow(){
        selectUsersWindow.SetActive(false);
    }
}
