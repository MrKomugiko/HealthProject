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

    public User(string UserId, string NickName, bool IsLocal, PersonalData PersonalData = null, int AvatarId = 0)
    {
        this._userId = UserId;
        this._nickName = NickName;
        this._isLocal = IsLocal;
        this._avatarId = AvatarId;
        this._personalData = PersonalData;
    }

    public static List<User> GetTestUsersList()
    {
        var calculator = new BMICalculateScript();
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
                    birthday: new DateTime(1995,9,2).ToString(),
                    gender: GenderEnum.Male.ToString(),
                    listOfWeights: new List<WeightRecord>()
                    {
                            new WeightRecord(
                                new DateTime(2020,12,14).ToString(),
                                82f,
                                180f,
                                calculator.GetBMI(82f,180f)
                            ),
                            new WeightRecord(
                                new DateTime(2020,12,15).ToString(),
                                81f,
                                180f,
                                calculator.GetBMI(81f,180f)
                            )
                    }
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
                    birthday: new DateTime(1995,9,2).ToString(),
                    gender: GenderEnum.Male.ToString(),
                    listOfWeights: new List<WeightRecord>()
                    {
                            new WeightRecord(
                                new DateTime(2020,12,14).ToString(),
                                85f,
                                181f,
                                calculator.GetBMI(85f,181f)
                            ),
                            new WeightRecord(
                                new DateTime(2020,12,15).ToString(),
                                87f,
                                181f,
                                calculator.GetBMI(87f,181f)
                            )
                    }
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
                    birthday:new DateTime(1995,1,1).ToString(),
                    gender:GenderEnum.Male.ToString(),
                    listOfWeights: new List<WeightRecord>()
                    {
                        new WeightRecord(
                            new DateTime(2020,12,14).ToString(),
                            120f,
                            150f,
                            calculator.GetBMI(120f,150f)
                        ),
                        new WeightRecord(
                            new DateTime(2020,12,15).ToString(),
                            110f,
                            150f,
                            calculator.GetBMI(110f,150f)
                        )
                    }
                ),
                AvatarId:3
            )
        };

        return TestUsersAccountsData;
    }

    public void MarkUserToRemove()
    {
        Debug.Log("you deleted " + this._userId + " user");
        this._isDeleted = true;
    }
}
