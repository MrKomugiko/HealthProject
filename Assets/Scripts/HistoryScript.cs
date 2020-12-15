using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HistoryScript : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] TextMeshProUGUI historyText;

    bool updateIsRequired = true;
    void Update()
    {
        List<WeightRecord> userWeightHistoryData =
        gameManager.GetComponent<StaticSelectedUserData>().currentSelectedUserData.PersonalData.ListOfWeights;

        if (updateIsRequired)
        {
            string textHistoryData = "";
            foreach (WeightRecord record in userWeightHistoryData)
            {
                textHistoryData += $"TIME \t\t[{Convert.ToDateTime(record._time).ToShortDateString()}] \nBMI \t\t[{record._bmiValue}]\nWEIGHT \t[{record._weight}]\n"+
                                   $"- - - - - - - - - - - - - - - - - - - - - - - \n";
            }
            historyText.SetText(textHistoryData);

            print("text");
        }

        if (userWeightHistoryData.Count > 0)
        {
            updateIsRequired = false;
        }
    }
}
