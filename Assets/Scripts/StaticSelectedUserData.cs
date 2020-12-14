using System;
using System.Runtime.Serialization.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSelectedUserData : MonoBehaviour
{
    public static Guid SelectedUserID;
    public static User SelectedUserData;

    [SerializeField] public string currentSelectedUserID;
    [SerializeField] public User currentSelectedUserData;

    void Start(){
        if(SelectedUserData == null){
           SelectedUserData = new User
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
            );

            SelectedUserID = Guid.Parse(SelectedUserData.UserId);
        }
    }
    void Update()
    {
        currentSelectedUserID = SelectedUserID.ToString();    
        currentSelectedUserData = SelectedUserData;
    }

    public static void SetUser(Guid newUSerID, User userdata){
        SelectedUserID = newUSerID;
        SelectedUserData = userdata;
        print("User id is changed to "+ SelectedUserID.ToString());
        GameObject.Find("LoginSection").GetComponent<LoginScript>().OnClick_Login();
    }
}
