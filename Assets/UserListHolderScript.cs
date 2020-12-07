using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserListHolderScript : MonoBehaviour
{
    [SerializeField] private GameObject UserButtonPrefab;
    [SerializeField] private GameObject EmptyUserButtonPrefab;

    [SerializeField] private int maxNumbersOfLocalUser = 5;
    [SerializeField] public int currentLocalUsers;

    [SerializeField] private List<User> TestUsersAccountsData;

    void Start()
    {
        TestUsersAccountsData = User.GetTestUsersList();
        currentLocalUsers = TestUsersAccountsData.Count;
        // TODO: Intantiate userbutton prefabs equal fetched users datas 
        foreach (User userData in TestUsersAccountsData)
        {
            print(userData.UserId + "\t" + userData.NickName);
        }

        if (TestUsersAccountsData.Count < maxNumbersOfLocalUser)
        {
            // TODO: create emptyUser button if is not full
            print("Avaiable to create new user.");
        }
    }
}
