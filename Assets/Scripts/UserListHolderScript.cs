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
    [SerializeField] private string releaseMode = "Release";
    [SerializeField] private GameObject emptyUserButtonPrefab;
    [SerializeField] private List<User> UsersAccountData;
    [SerializeField] bool needToRefreshListOfUserObjects;
    public int maxNumbersOfLocalUser = 5;
    public int currentLocalUsers;
    public List<Sprite> avatarsIcon;

    void Start()
    {
        if (releaseMode == "Debug")
        {
            UsersAccountData = User.GetTestUsersList();
        }
        else if (releaseMode == "Release")
        {
            UsersAccountData = FetchUsersDataFromDevice();
        }
        currentLocalUsers = UsersAccountData.Count;

        PopulateListWithItems(UsersAccountData);
    }
    void Update()
    {
        if (needToRefreshListOfUserObjects)
        {
            currentLocalUsers = UsersAccountData.Count;
            RemoveUsersMarkedToDelete(ref UsersAccountData);
            PopulateListWithItems(UsersAccountData);
            SaveUsersDataInDeviceAsJsonFile(UsersAccountData);
            needToRefreshListOfUserObjects = false;
        }
    }
    void PopulateListWithItems(List<User> users)
    {
        if (!needToRefreshListOfUserObjects)
        {
            foreach (var user in users)
            {
                CreateUserObject(user);
            }

            if (this.transform.Find("AddNewUser") == null && users.Count < maxNumbersOfLocalUser)
            {
                CreateEmptyObject();
            }
        }
        else
        {
            if (this.transform.Find("AddNewUser") == null && users.Count < maxNumbersOfLocalUser)
            {
                CreateEmptyObject();
            }
        }
    }
    void CreateEmptyObject()
    {
        var EmptyUserObject = Instantiate(emptyUserButtonPrefab, this.transform.position, Quaternion.identity, this.transform);
        EmptyUserObject.name = "AddNewUser";
        EmptyUserObject.transform.localScale = new Vector3(0.7f, 0.7f, 1);
        EmptyUserObject.transform.Rotate(0f, 0f, 180, Space.Self);
        EmptyUserObject.GetComponent<Button>().onClick.AddListener(() => OnClick_GoToRegistrationForm());
    }
    void CreateUserObject(User userData)
    {
        var userObject = Instantiate(userButtonPrefab, this.transform.position, Quaternion.identity, this.transform);
        userObject.name = userData.UserId.ToString();
        userObject.transform.localScale = new Vector3(0.9f, 0.9f, 1);
        userObject.transform.Rotate(0f, 0f, 180, Space.Self);
        userObject.GetComponentInChildren<Text>().text = userData.NickName;
        userObject.transform.Find("Image").GetComponent<Image>().sprite = avatarsIcon.ElementAt(userData.AvatarId);
        userObject.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => userData.MarkUserToRemove());
        userObject.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => needToRefreshListOfUserObjects = true);
        userObject.GetComponent<Button>().onClick.AddListener(()=>StaticSelectedUserData.SetUser(
            Guid.Parse(userData.UserId),
            userData));
    }
    void RemoveUsersMarkedToDelete(ref List<User> usersList)
    {
        foreach (User user in usersList.Where(u => u.IsDeleted == true))
        {
            usersList.Remove(user);
            Destroy(this.transform.Find(user.UserId.ToString()).gameObject);
        }
        needToRefreshListOfUserObjects = true;
    }
    public List<User> FetchUsersDataFromDevice()
    {
        string loadedText_usersData = "";
        if (!File.Exists(Application.persistentDataPath + $"/Users.json"))
        {
                List<User> defaultUsers = User.GetTestUsersList();
                SaveUsersDataInDeviceAsJsonFile(defaultUsers);
                loadedText_usersData = File.ReadAllText(Application.persistentDataPath + "/Users.json");
        }
        else
        {
            loadedText_usersData = File.ReadAllText(Application.persistentDataPath + "/Users.json");
        };
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
                        user._personalData.Gender,
                        user._personalData.ListOfWeights
                    ),
                    user._avatarId
                )
            );
        }

        return users;
    }
    public void SaveUsersDataInDeviceAsJsonFile(List<User> userList)
    {
        UsersList_JSON testJson = new UsersList_JSON();
        testJson.Users = new List<User_JSON>();
        foreach (User user in userList)
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
                    gender: user.PersonalData.Gender,
                    listOfWeights: user.PersonalData.ListOfWeights
                    ),
                AvatarId: user.AvatarId
                )
            );
        }

        string json = JsonUtility.ToJson(testJson);
        File.WriteAllText(Application.persistentDataPath + $"/Users.json", json);
    }
    public void OnClick_GoToRegistrationForm()
    {
        SceneManager.LoadScene("RegistrationScene");
    }
}
