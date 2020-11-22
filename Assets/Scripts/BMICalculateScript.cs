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
    public void OnClick_CalculateBMI(){

        float height = float.Parse(HeightInput.text)/100;
        float weight = float.Parse(WeightInput.text);

        float BMI = weight/(height*height);
        print($"wzrost: [{height}]");
        print($"waga: [{weight}]");

        print($"Twoje BMI to: [{Math.Round(BMI,2)}]");

        BMIResult.SetText(Math.Round(BMI,2).ToString());

        OnClick_ChangeColorsToImages();
    }

    public void OnClick_ChangeColorsToImages(){
        var listOfCells = GameObject.Find("GridHolder").GetComponentsInChildren<Image>();
        foreach (Image cell in listOfCells)
        {
            cell.color = Color.magenta;
        }

    }
    public float GetBMI(float weight, float height) => (float)Math.Round(weight/(height/100*height/100),1);
}
