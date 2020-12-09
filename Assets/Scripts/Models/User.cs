using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class User
{
    [SerializeField] private string _userId;
    [SerializeField] private string _nickName;
    [SerializeField] private bool _isLocal;
    [SerializeField] private int _avatarId;
    [SerializeField] private PersonalData _personalData;
    [SerializeField] private bool _isDeleted;


    public string UserId { get => _userId; set => _userId = value; }
    public string NickName { get => _nickName; set => _nickName = value; }
    public bool IsLocal { get => _isLocal; set => _isLocal = value; }
    public int AvatarId { get => _avatarId; set => _avatarId = value; }
    public PersonalData PersonalData { get => _personalData; set => _personalData = value; }
    public bool IsDeleted { get => _isDeleted; set => _isDeleted = value; }

    public User(string UserId, string NickName, bool IsLocal, PersonalData PersonalData = null, int AvatarId = 0) {
        this._userId = UserId;
        this._nickName = NickName;
        this._isLocal = IsLocal;
        this._avatarId = AvatarId;
        this._personalData = PersonalData;
    }

    public static List<User> GetTestUsersList() {
        List<User> TestUsersAccountsData = new List<User> {
            new User
            (
                UserId: Guid.NewGuid().ToString(),
                NickName: "Kamil",
                IsLocal: true,
                PersonalData: new PersonalData
                (
                    name: "Kamil",
                    age: 25,
                    startingWeight: 82,
                    startingHeight: 180,
                    birthday: new DateTime(1995,9,2),
                    gender: GenderEnum.Male.ToString()
                ),
                AvatarId: 1
            ),

            new User
            (
                UserId: Guid.NewGuid().ToString(),
                NickName: "Jakub",
                IsLocal: true,
                PersonalData: new PersonalData
                (
                    name: "Kuba",
                    age: 25,
                    startingWeight: 85,
                    startingHeight: 181,
                    birthday: new DateTime(1995,9,2),
                    gender: GenderEnum.Male.ToString()
                ),
                AvatarId: 2
            ),

            new User
            (
                UserId: Guid.NewGuid().ToString(),
                NickName:"Kondziu",
                IsLocal:true,
                PersonalData: new PersonalData
                (
                    name: "Konrad",
                    age:25,
                    startingWeight: 120,
                    startingHeight: 150,
                    birthday:new DateTime(1995,1,1),
                    gender:GenderEnum.Male.ToString()
                ),
                AvatarId:3
            )
        };

        return TestUsersAccountsData;
    }

    public void MarkUserToRemove(){
        Debug.Log("you deleted "+this._userId+" user");
        this._isDeleted = true;
    }
}
