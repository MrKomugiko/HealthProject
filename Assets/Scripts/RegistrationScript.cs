using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegistrationScript : MonoBehaviour
{
    [SerializeField] TMP_InputField NickName;
    [SerializeField] TMP_InputField Name;
    [SerializeField] TMP_InputField Age;
    [SerializeField] TMP_InputField Birthday_Day;
    [SerializeField] TMP_InputField Birthday_Month;
    [SerializeField] TMP_InputField Birthday_Year;
    [SerializeField] TMP_InputField Weight;
    [SerializeField] TMP_InputField Height;
    [SerializeField] ToggleGroup Genre;

    public void OnClick_CreateUser()
    {
        string guidID = Guid.NewGuid().ToString();
        string nickName = NickName.text;
        string name = Name.text;
        int age = Convert.ToInt32(Age.text);

        int day = Convert.ToInt32(Birthday_Day.text);
        int month = Convert.ToInt32(Birthday_Month.text);
        int year = Convert.ToInt32(Birthday_Year.text);
        DateTime birthday = new DateTime(year, month, day);

        float weight = float.Parse(Weight.text);
        float height = float.Parse(Height.text);

        string genre = Genre.ActiveToggles().FirstOrDefault().GetComponentInChildren<Text>().text;

        UserListHolderScript script = new UserListHolderScript();
        List<User> users = script.FetchUsersDataFromDevice();
        users.Add(new User(guidID, nickName, true, new PersonalData(name, age, weight, height, birthday, genre), 0));
        script.SaveUsersDataInDeviceAsJsonFile(users);

        SceneManager.LoadScene("LandingStartScene");
    }
}
