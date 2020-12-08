using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserListHolderScript : MonoBehaviour
{
    [SerializeField] private GameObject userButtonPrefab;
    [SerializeField] private GameObject emptyUserButtonPrefab;

    [SerializeField] private int maxNumbersOfLocalUser;
    public int currentLocalUsers;

    [SerializeField] private List<User> TestUsersAccountsData;

    public List<Sprite> avatarsIcon;
    [SerializeField] private string releaseMode;

    void Avake()
    {
        releaseMode = "Debug";
        maxNumbersOfLocalUser = 5;
    }
    void Start()
    {
        if (releaseMode == "Debug")
        {
            TestUsersAccountsData = User.GetTestUsersList();
        }
        else if (releaseMode == "Release")
        {
            TestUsersAccountsData = FetchUsersDataFromDevice();
        }
        currentLocalUsers = TestUsersAccountsData.Count;

        PopulateListWithItems(TestUsersAccountsData);

    }

    [SerializeField] bool refreshUsersList;
    void Update()
    {
        if (refreshUsersList)
        {
            currentLocalUsers = TestUsersAccountsData.Count;
            RemoveUsersMarkedToDelete(ref TestUsersAccountsData);
            PopulateListWithItems(TestUsersAccountsData);
            SaveUserDataInDeviceAsJsonFile();
            refreshUsersList = false;
        }
    }
    void PopulateListWithItems(List<User> users)
    {
        #region Debug Log in consol
        foreach (var user in users)
        {
            print(user.UserId + "\t" + user.NickName);
        }

        if (TestUsersAccountsData.Count < maxNumbersOfLocalUser)
        {
            print("Avaiable to create new user.");
        }
        #endregion;

        if (!refreshUsersList)
        {
            foreach (var user in users)
            {
                var UserObject = Instantiate(userButtonPrefab, this.transform.position, Quaternion.identity, this.transform);
                SelfConfigureObject(UserObject, user);
            }

            if (this.transform.Find("AddNewUser") == null)
            {
                if (users.Count < maxNumbersOfLocalUser)
                {
                    var EmptyUserObject = Instantiate(emptyUserButtonPrefab, this.transform.position, Quaternion.identity, this.transform);
                    EmptyUserObject.name = "AddNewUser";

                    EmptyUserObject.transform.localScale = new Vector3(0.7f, 0.7f, 1);
                    EmptyUserObject.transform.Rotate(0f, 0f, 180, Space.Self);
                    EmptyUserObject.GetComponent<Button>().onClick.AddListener(() => OnClick_GoToRegistrationForm());
                }
            }
        }
        else
        {
            // Check if this object already exist
            if (this.transform.Find("AddNewUser") == null)
            {
                if (users.Count < maxNumbersOfLocalUser)
                {
                    var EmptyUserObject = Instantiate(emptyUserButtonPrefab, this.transform.position, Quaternion.identity, this.transform);
                    EmptyUserObject.name = "AddNewUser";
                    EmptyUserObject.transform.localScale = new Vector3(0.7f, 0.7f, 1);
                    EmptyUserObject.transform.Rotate(0f, 0f, 180, Space.Self);
                    EmptyUserObject.GetComponent<Button>().onClick.AddListener(() => OnClick_GoToRegistrationForm());
                }
            }
        }
    }
    public void OnClick_GoToRegistrationForm()
    {
        SceneManager.LoadScene("RegistrationScene");
    }

    void SelfConfigureObject(GameObject userObject, User userData)
    {
        userObject.name = userData.UserId.ToString();
        userObject.transform.localScale = new Vector3(0.9f, 0.9f, 1);
        userObject.transform.Rotate(0f, 0f, 180, Space.Self);
        userObject.GetComponentInChildren<Text>().text = userData.NickName;
        userObject.transform.Find("Image").GetComponent<Image>().sprite = avatarsIcon.ElementAt(userData.AvatarId);
        userObject.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => userData.MarkUserToRemove());
        userObject.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => refreshUsersList = true);
    }
    public void RemoveUsersMarkedToDelete(ref List<User> usersList)
    {
        // Delete users from memory
        foreach (User user in usersList.Where(u => u.IsDeleted == true))
        {
            usersList.Remove(user);

            // delete users object in application
            Destroy(this.transform.Find(user.UserId.ToString()).gameObject);
        }

        // Reload Users list in application
        refreshUsersList = true;
    }
    List<User> FetchUsersDataFromDevice()
    {
        #region hardcoded default data
        // test pass values into json formated classes
        UsersList_JSON testJson = new UsersList_JSON();
        testJson.Users = new List<User_JSON>();
        testJson.Users.Add(
            new User_JSON(
                UserId: 1001,
                NickName: "Kamil",
                IsLocal: true,
                PersonalData: new PersonalData(
                    name: "Kamil",
                    age: 25,
                    startingWeight: 82,
                    startingHeight: 180,
                    birthday: new DateTime(1995, 9, 2),
                    gender: PersonalData.GenderEnum.Male
                ),
                AvatarId: 1
            )
        );
        testJson.Users.Add(
            new User_JSON(
                UserId: 1002,
                NickName: "Jakub",
                IsLocal: true,
                PersonalData: new PersonalData(
                    name: "Kuba",
                    age: 25,
                    startingWeight: 85,
                    startingHeight: 181,
                    birthday: new DateTime(1995, 9, 2),
                    gender: PersonalData.GenderEnum.Male
                ),
                AvatarId: 2
            )
        );

        testJson.Users.Add(
           new User_JSON(
                UserId: 1003,
                NickName: "Kondziu",
                IsLocal: true,
                PersonalData: new PersonalData(
                    name: "Konrad",
                    age: 25,
                    startingWeight: 120,
                    startingHeight: 150,
                    birthday: new DateTime(1995, 1, 1),
                    gender: PersonalData.GenderEnum.Male
                ),
                AvatarId: 3
            )
        );
        #endregion

        string loadedText_usersData = File.ReadAllText(Application.persistentDataPath + "/Users.json");
        if (loadedText_usersData == null)
        {
            // create new file with dest data
            string json = JsonUtility.ToJson(testJson);
            File.WriteAllText(Application.persistentDataPath + $"/Users.json", json);
        }

        UsersList_JSON fetchedusersfromdevice = JsonUtility.FromJson<UsersList_JSON>(loadedText_usersData);

        List<User> users = new List<User>();
        foreach (User_JSON user in fetchedusersfromdevice.Users)
        {
            users.Add(
                new User(
                    user._userId,
                    user._nickName,
                    user._isLocal,
                    new PersonalData(
                        user._personalData.Name,
                        user._personalData.Age,
                        user._personalData.StartingWeight,
                        user._personalData.StartingHeight,
                        user._personalData.Birthday,
                        user._personalData.Gender
                    ),
                    user._avatarId
                )
            );
        }

        return users;
    }

    void SaveUserDataInDeviceAsJsonFile()
    {
        UsersList_JSON testJson = new UsersList_JSON();
        testJson.Users = new List<User_JSON>();
        foreach (User user in TestUsersAccountsData)
        {
            testJson.Users.Add(
                new User_JSON(
                UserId: user.UserId,
                NickName: user.NickName,
                IsLocal: user.IsLocal,
                PersonalData: new PersonalData(
                    name: user.PersonalData.Name,
                    age: user.PersonalData.Age,
                    startingWeight: user.PersonalData.StartingWeight,
                    startingHeight: user.PersonalData.StartingHeight,
                    birthday: user.PersonalData.Birthday,
                    gender: user.PersonalData.Gender
                    ),
                AvatarId: user.AvatarId
                )
            );
        }

        string json = JsonUtility.ToJson(testJson);
        File.WriteAllText(Application.persistentDataPath + $"/Users.json", json);

    }
}
