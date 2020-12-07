using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    [SerializeField] private int userId;
    [SerializeField] private string nickName;
    [SerializeField] private bool isLocal;

    public int UserId { get => userId; set => userId = value; }
    public string NickName { get => nickName; set => nickName = value; }
    public bool IsLocal { get => isLocal; set => isLocal = value; }

    User(int UserId, string NickName, bool IsLocal)
    {
        this.userId = UserId;
        this.nickName = NickName;
        this.isLocal = IsLocal;
    }

    public static List<User> GetTestUsersList()
    {
        List<User> TestUsersAccountsData = new List<User>();
        TestUsersAccountsData.Add(new User(UserId: 1001, NickName: "Kamil", IsLocal: true));
        TestUsersAccountsData.Add(new User(UserId: 1002, NickName: "Jakub", IsLocal: true));
        TestUsersAccountsData.Add(new User(UserId: 1003, NickName: "Konrad", IsLocal: true));

        return TestUsersAccountsData;
    }
}
