using System;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticSelectedUserData : MonoBehaviour
{
    public static Guid SelectedUserID;
    public static User SelectedUserData;
    public static string RecentLoggedUser;

    [SerializeField] public string currentSelectedUserID;
    [SerializeField] public User currentSelectedUserData;
    [SerializeField] public string recentLoggedUser;


    void Start()
    {
        var script = new UserListHolderScript();
        string recentLoggedUser = script.FetchLastLoggedInUser();
  
        if (SelectedUserData == null)
        {
            SelectedUserData = script.FetchUsersDataFromDevice_ByID(recentLoggedUser);
            SelectedUserID = Guid.Parse(SelectedUserData.UserId);

            RecentLoggedUser = recentLoggedUser;

            if(recentLoggedUser != "" && SceneManager.GetActiveScene().name == "LandingStartScene"){
                SceneManager.LoadScene("MainScene");
            }
        }
    }
    void Update()
    {
        currentSelectedUserID = SelectedUserID.ToString();
        currentSelectedUserData = SelectedUserData;
        recentLoggedUser = RecentLoggedUser;
    }

    public static void SetUser(Guid newUSerID, User userdata)
    {
        SelectedUserID = newUSerID;
        SelectedUserData = userdata;
        RecentLoggedUser = $"Default-{userdata.NickName}";
        print("User id is changed to " + SelectedUserID.ToString());
        GameObject.Find("LoginSection").GetComponent<LoginScript>().OnClick_Login();
    }

    public void SaveUserForNextLogin()
    {
        RecentLoggedUser = $"{SelectedUserData.UserId}";
        print($"saved { SelectedUserData.NickName } for next auto Login.");

        var script = new UserListHolderScript();
        script.SaveLastUserLoggedInDeviceJsonFile(RecentLoggedUser);
    }
}
