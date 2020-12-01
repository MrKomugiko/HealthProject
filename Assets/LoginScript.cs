using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    public void OnClick_Login(){
        SceneManager.LoadScene("MainScene");
    }
    public void OnClick_CreateAccount(){
        SceneManager.LoadScene("RegistrationScene");
    }
}
