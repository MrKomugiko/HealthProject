using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class AddNewWeightScript : MonoBehaviour
{
    [SerializeField] GameObject oldAddButton;
    [SerializeField] GameObject currentSaveButton;
    [SerializeField] TMP_InputField HeightInput;
    [SerializeField] TMP_InputField WeightInput;

    void Start()
    {
        oldAddButton.SetActive(false);
    }

    public void OnClick_CalculateBMI()
    {
        float height = float.Parse(HeightInput.text);
        float weight = float.Parse(WeightInput.text);

        var calculator = new BMICalculateScript();
        print(calculator.GetBMI(weight, height).ToString());


        WeightRecord newRecord = new WeightRecord(DateTime.Now.ToString(),weight,height,calculator.GetBMI(weight, height));

        UpdateUserData(newRecord);
        
        oldAddButton.SetActive(true);

        GameObject.FindObjectOfType<HistoryScript>().updateIsRequired = true;

        this.gameObject.SetActive(false);
    }

    void UpdateUserData(WeightRecord newRecord)
    {
        // aktualizacja lokalna statecznych danych ( ale czy o potrzebne... hmm? )
        User userData = GameObject.Find("GameManager").GetComponent<StaticSelectedUserData>().currentSelectedUserData;
        userData.PersonalData.ListOfWeights.Add(newRecord);

        var script = new UserListHolderScript();
        // pobranie WSZYSTKICH uzytkownikow na urzadzeniu ( w pliku )
        List<User> listOfUsers = script.FetchUsersDataFromDevice();

        // wyszukanie aktualnego uzytkownika i dodanie do jego listy wag nowego wpisu
        listOfUsers.Where(u => u.UserId == GameObject.Find("GameManager").GetComponent<StaticSelectedUserData>().currentSelectedUserID)
                                                 .First().PersonalData.ListOfWeights
                                                 .Add(newRecord);

        // nadpisanie istniejącego pliku o nowe dane
        script.SaveUsersDataInDeviceAsJsonFile(listOfUsers);
    }

    bool checkingDataNeeded = true;
    void FixedUpdate()
    {
        if (checkingDataNeeded)
        {
            bool reloadNeeded = false;
            if (GameObject.Find("GameManager").GetComponent<StaticSelectedUserData>().currentSelectedUserData.PersonalData.StartingHeight.ToString() != "0")
            {
                reloadNeeded = true;
            }
            
            if (reloadNeeded)
            {
                print(GameObject.Find("GameManager").GetComponent<StaticSelectedUserData>().currentSelectedUserData.PersonalData.StartingHeight.ToString());
                HeightInput.SetTextWithoutNotify(GameObject.Find("GameManager").GetComponent<StaticSelectedUserData>().currentSelectedUserData.PersonalData.StartingHeight.ToString());
                reloadNeeded = false;
                checkingDataNeeded = false;
            }
        }

        string height = HeightInput.text;
        string weight = WeightInput.text;
        if (height == string.Empty || weight == string.Empty)
        {
            currentSaveButton.SetActive(false);
        }
        else
        {
            currentSaveButton.SetActive(true);
        }
    }

    public void OnClick_OpenAddNewWeighWindow(){
        this.gameObject.SetActive(true);
    }
    public void OnClick_CloseAddNewWeighWindow(){
        this.gameObject.SetActive(false);
        oldAddButton.SetActive(true);
    }
}
