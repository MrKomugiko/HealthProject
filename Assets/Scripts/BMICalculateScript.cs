using System;
using TMPro;
using UnityEngine;

public class BMICalculateScript : MonoBehaviour
{
    [SerializeField] TMP_InputField HeightInput;
    [SerializeField] TMP_InputField WeightInput;
    [SerializeField] TextMeshProUGUI BMIResult;

    public float RecentCalculatedBMIValue;
    public void OnClick_CalculateBMI()
    {
        float height = float.Parse(HeightInput.text);
        float weight = float.Parse(WeightInput.text);

        float BMI = GetBMI(weight,height);

        BMIResult.SetText(BMI.ToString());
        BMIResult.color = GetColorBasedOnBMIIndex(BMI);

        // Clear default or old grid
    try
    {
         GameObject.Find("GridHolder").GetComponent<GridGeneratorScript>().ClearOldGrid();
        // Genereate new grid
        GameObject.Find("GridHolder").GetComponent<GridGeneratorScript>().GenerateCustomizedUserChart(height,weight);
    }   
    catch (System.Exception)
    {
    }

        
        RecentCalculatedBMIValue = BMI;
    }
    public float GetBMI(float weight, float height) => (float)Math.Round(weight / (height / 100 * height / 100), 1);
    
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
}
