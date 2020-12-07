using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GridGeneratorScript : MonoBehaviour
{
    [SerializeField] GameObject GridCell = null;
    public List<Sprite> listOfCollors = new List<Sprite>();
    BMICalculateScript BMICalculator = null;
    int chartSize = 16;
    float weight=0, height=0, startHeight=0, startWeight=0, weightIncrementRate =0, heightIncrementRate=0;
    void Start()
    { 
        BMICalculator = GameObject.FindObjectOfType<BMICalculateScript>().GetComponent<BMICalculateScript>();
        GenerateSimpleChart();
    }
    void GenerateSimpleChart()
    {
        #region configure default values
            height = 180;
            weight = 80;
            weightIncrementRate = 3;
            heightIncrementRate = 2;
            double middleIndex = Math.Round(((chartSize - 1) / 2f)) + 1;
            startWeight = float.Parse((weight - (weightIncrementRate * (middleIndex - 1))).ToString());
            startHeight = float.Parse((height - (heightIncrementRate * (middleIndex - 1))).ToString());
        #endregion;

        for (int i = chartSize - 1; i >= 0; i--)
        {
            for (int j = 0; j < chartSize; j++)
            {
                height = startHeight + ((j - 1) * heightIncrementRate);
                weight = startWeight + ((i - 1) * weightIncrementRate);

                float BMI = BMICalculator.GetBMI(weight, height);
                var singleGridCell = Instantiate(GridCell);
                singleGridCell.transform.SetParent(this.transform);
                singleGridCell.transform.localScale = Vector3.one;

                MakeShureBMITextIsDecimal(BMI, singleGridCell);
                UpdateColor(BMI, singleGridCell.transform.Find("ColorBackground").GetComponent<SpriteRenderer>());
                ConfigureIfAxisLabels(i, j, singleGridCell);
            }
        }

    }
    void ConfigureIfAxisLabels(int i, int j, GameObject gridCellObject)
    {
        if (i == 0 || j == 0)
        {
            if (i == 0 && j == 0)
            {
                gridCellObject.GetComponentInChildren<TextMeshProUGUI>().SetText("/");
            }
            else if (j == 0)
            {
                // OŚ WAGi (piowowa)
                gridCellObject.GetComponentInChildren<TextMeshProUGUI>().SetText(Mathf.Round((startWeight + (weightIncrementRate * (i)))).ToString());
            }
            else if (i == 0)
            {
                // OŚ WYSOKOŚCI (POSIOMA)
                gridCellObject.GetComponentInChildren<TextMeshProUGUI>().SetText(Math.Round(Convert.ToDecimal((startHeight + (heightIncrementRate * (j)))), 1).ToString());
            }
            UpdateColor(1f, gridCellObject.transform.Find("ColorBackground").GetComponent<SpriteRenderer>());
        }
    }
    void MakeShureBMITextIsDecimal(float BMI, GameObject gridCellObject)
    {
        if (BMI % 1 == 0f)
        {
            gridCellObject.GetComponentInChildren<TextMeshProUGUI>().SetText(BMI.ToString() + ",0");
        }
        else
        {
            gridCellObject.GetComponentInChildren<TextMeshProUGUI>().SetText(BMI.ToString());
        }
    }
    void ConfigureIfIsImportant(int i, int j, double middleIndex, GameObject gridCellObject)
    {
        if ((i == 0 || j == 0) || (i == middleIndex - 1 || j == middleIndex - 1))
        {
            gridCellObject.GetComponent<CellScript>().IsImportant = true;
        }
        if (i == middleIndex - 1 && j == middleIndex - 1)
        {
            gridCellObject.GetComponent<CellScript>().IsSelected = true;
        }
    }
    public void UpdateColor(float bmiValue, SpriteRenderer cellSprite)
    {
        if (bmiValue == 1f)
        {
            // LABEL TEXT
            cellSprite.sprite = listOfCollors.Where(p => p.name == "BRIGHTBLUE").First();
        }
        else if (bmiValue <= 18.5f)
        {
            // UNDERWEIGHT
            cellSprite.sprite = listOfCollors.Where(p => p.name == "BLUE").First();
        }
        else if (bmiValue <= 24.9f)
        {
            // NORMAL
            cellSprite.sprite = listOfCollors.Where(p => p.name == "GREEN").First();
        }
        else if (bmiValue <= 29.9f)
        {
            // OVERWEIGHT
            cellSprite.sprite = listOfCollors.Where(p => p.name == "YELLOW").First();
        }
        else if (bmiValue <= 34.9f)
        {
            // OBESE
            cellSprite.sprite = listOfCollors.Where(p => p.name == "RED").First();
        }
        else if (bmiValue >= 35f)
        {
            // EXTREMELYOBESE
            cellSprite.sprite = listOfCollors.Where(p => p.name == "PINK").First();
        }
    }
    public void ClearOldGrid()
    {
        CellScript[] oldChartItems = GameObject.Find("GridHolder").GetComponentsInChildren<CellScript>();
        foreach (var cell in oldChartItems)
        {
            Destroy(cell.gameObject);
        }
    }
    public void GenerateCustomizedUserChart(float userHeight, float userWeight, int chartSize = 16, float weightInceraseRate = 3, float heightInceraseRate = 2)
    {
        double middleIndex = Math.Round(((chartSize - 1) / 2f)) + 1;
       
        startWeight = float.Parse((userWeight - (weightInceraseRate * (middleIndex - 1))).ToString());
        startHeight = float.Parse((userHeight - (heightInceraseRate * (middleIndex - 1))).ToString());

        for (int i = chartSize - 1; i >= 0; i--)
        {
            for (int j = 0; j < chartSize; j++)
            {
                height = startHeight + ((j - 1) * heightInceraseRate);
                weight = startWeight + ((i - 1) * weightInceraseRate);

                float BMI = BMICalculator.GetBMI(weight, height);
                var singleGridCell = Instantiate(GridCell);
                singleGridCell.transform.SetParent(this.transform);
                singleGridCell.transform.localScale = Vector3.one;

                MakeShureBMITextIsDecimal(BMI, singleGridCell);
                UpdateColor(BMI, singleGridCell.transform.Find("ColorBackground").GetComponent<SpriteRenderer>());
                ConfigureIfAxisLabels(i, j, singleGridCell);
                ConfigureIfIsImportant(i, j, middleIndex, singleGridCell);
            }
        }
    }
}
