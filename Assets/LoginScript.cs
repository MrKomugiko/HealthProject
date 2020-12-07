using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{

    [SerializeField] private GameObject selectUsersWindow = null;

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
