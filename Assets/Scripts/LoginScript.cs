using System.Linq;
using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LoginScript : MonoBehaviour
{
    [SerializeField] private GameObject selectUsersWindow = null;
    [SerializeField] GameObject CreateLocalAccount_Button;
    [SerializeField] int maxNumberOfLocalAccounts = 0;
    [SerializeField] bool needUpdateButtonsLogic = true;
    void Start()
    {
        if(needUpdateButtonsLogic)
            {
            if (File.Exists(Application.persistentDataPath + $"/Users.json"))
            {
                string loadedText_usersData = File.ReadAllText(Application.persistentDataPath + $"/Users.json");
                UsersList_JSON fetchedusersfromdevice = JsonUtility.FromJson<UsersList_JSON>(loadedText_usersData);
                print(fetchedusersfromdevice.Users.Count +" = number of local users");
                if (fetchedusersfromdevice.Users.Count < maxNumberOfLocalAccounts)
                {
                    CreateLocalAccount_Button.SetActive(true);
                }
                else 
                {
                    CreateLocalAccount_Button.SetActive(false);
                }
            }
            else
            {
                CreateLocalAccount_Button.SetActive(false);
            }

            needUpdateButtonsLogic = false;
        }
    }
    public void OnClick_Login()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnClick_CreateAccount()
    {
        SceneManager.LoadScene("RegistrationScene");
    }
    public void OnClick_SelectUser()
    {
        selectUsersWindow.SetActive(true);
    }
    public void OnClick_BackFromSelectingUserWindow()
    {
        selectUsersWindow.SetActive(false);
    }
}
