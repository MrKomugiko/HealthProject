using System.Collections.Generic;
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

    void Avake() {
        releaseMode = "Debug";
        maxNumbersOfLocalUser = 5;
    }
    void Start() {
        if (releaseMode == "Debug") {
            TestUsersAccountsData = User.GetTestUsersList();
        } else {
            TestUsersAccountsData = FetchUsersDataFromDevice();
        }
        currentLocalUsers = TestUsersAccountsData.Count;

        PopulateListWithItems(TestUsersAccountsData);
    }

    void PopulateListWithItems(List<User> users) {
        #region Debug Log in consol
            foreach (var user in users) {
                print(user.UserId + "\t" + user.NickName);
            }

            if (TestUsersAccountsData.Count < maxNumbersOfLocalUser) {
                print("Avaiable to create new user.");
            }
        #endregion;

        foreach (var user in users) {
            var UserObject = Instantiate(userButtonPrefab, this.transform.position, Quaternion.identity, this.transform);
            SelfConfigureObject(UserObject, user);
        }

        if (users.Count < maxNumbersOfLocalUser) {
            var EmptyUserObject = Instantiate(emptyUserButtonPrefab, this.transform.position, Quaternion.identity, this.transform);
            EmptyUserObject.transform.localScale = new Vector3(0.7f, 0.7f, 1);
            EmptyUserObject.transform.Rotate(0f, 0f, 180, Space.Self);
            EmptyUserObject.GetComponent<Button>().onClick.AddListener(()=> OnClick_GoToRegistrationForm());   
        }
    }
        public void OnClick_GoToRegistrationForm(){
            SceneManager.LoadScene("RegistrationScene");
    }

    void SelfConfigureObject(GameObject userObject, User userData) {
        userObject.name = userData.UserId.ToString();
        userObject.transform.localScale = new Vector3(0.9f, 0.9f, 1);
        userObject.transform.Rotate(0f, 0f, 180, Space.Self);
        userObject.GetComponentInChildren<Text>().text = userData.NickName;
        userObject.transform.Find("Image").GetComponent<Image>().sprite = avatarsIcon.ElementAt(userData.AvatarId);
    }
    List<User> FetchUsersDataFromDevice() {
        return new List<User>();
    }
}
