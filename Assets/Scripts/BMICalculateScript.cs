using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BMICalculateScript : MonoBehaviour
{
    [SerializeField] TMP_InputField HeightInput;
    [SerializeField] TMP_InputField WeightInput;
    [SerializeField] TextMeshProUGUI BMIResult;
    public void OnClick_CalculateBMI()
    {

        float height = float.Parse(HeightInput.text) / 100;
        float weight = float.Parse(WeightInput.text);

        float BMI = weight / (height * height);
        //print($"wzrost: [{height}]");
        //print($"waga: [{weight}]");

        //print($"Twoje BMI to: [{Math.Round(BMI,2)}]");

        BMIResult.SetText(Math.Round(BMI, 2).ToString());

        BMIResult.color = GetColorBasedOnBMIIndex(BMI);
    }

    private Color GetColorBasedOnBMIIndex(float BMI)
    {
        Color color = Color.clear;
        if (BMI <= 18.5f)
        {
            color = new Color32(0, 162, 232, 255); // BLUE
        }
        else if (BMI <= 24.9f)
        {
            color = new Color32(34, 177, 76, 255); // GREEN
        }
        else if (BMI <= 29.9f)
        {
            color = new Color32(255, 242, 0, 255); // yellow
        }
        else if (BMI <= 34.9f)
        {
            color = new Color32(237, 28, 36, 255); // RED
        }
        else if (BMI >= 35f)
        {
            color = new Color32(255, 0, 128, 255); // PINK
        }
        return color;
    }

    public float GetBMI(float weight, float height) => (float)Math.Round(weight / (height / 100 * height / 100), 1);
}
