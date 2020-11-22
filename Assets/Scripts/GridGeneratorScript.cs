using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GridGeneratorScript : MonoBehaviour
{
    public List<Sprite> listOfCollors;
    BMICalculateScript BMICalculator;
    [SerializeField] GameObject GridCell;
    [SerializeField] int chartSize = 16;
    [SerializeField] float startHeight = 150;
    [SerializeField] float endHeight = 200;
    float heightIncrementValue => (endHeight - startHeight) / (chartSize - 2);
    [SerializeField] float startWeight = 50;
    [SerializeField] float endWeight = 120;
    float weightIncrementValue => (endWeight - startWeight) / (chartSize - 2);

    void Start()
    {
        BMICalculator = GameObject.FindObjectOfType<BMICalculateScript>().GetComponent<BMICalculateScript>();

        float weight = startWeight;
        float height = startHeight;
        for (int i = chartSize - 1; i >= 0; i--)
        {
            for (int j = 0; j < chartSize; j++)
            {
                height = startHeight + ((j - 1) * heightIncrementValue);
                weight = startWeight + ((i - 1) * weightIncrementValue);

                float BMI = BMICalculator.GetBMI(weight, height);
                var singleGridCell = Instantiate(GridCell);
                singleGridCell.transform.SetParent(this.transform);
                // singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText($"[i{i},j{j}]");
                // GENEROWANIE WARTOSCI W KOMÓRKACH
                if (BMI % 1 == 0f)
                {
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(BMI.ToString() + ",0");
                    UpdateColor(BMI, singleGridCell.GetComponent<SpriteRenderer>());
                }
                else
                {
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(BMI.ToString());
                    UpdateColor(BMI, singleGridCell.GetComponent<SpriteRenderer>());
                }
                //GENEROWANIEETYKIET WAGI I WZROSTU NA OSIACH
                if (j == 0)
                {
                    // OŚ WAGi (piowowa)
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(Mathf.Round((startWeight + (weightIncrementValue * (i - 1)))).ToString());
                    UpdateColor(1f, singleGridCell.GetComponent<SpriteRenderer>());
                }
                if (i == 0)
                {
                    // OŚ WYSOKOŚCI (POSIOMA)
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(Math.Round(Convert.ToDecimal((startHeight + (heightIncrementValue * (j - 1)))), 1).ToString());
                    UpdateColor(1f, singleGridCell.GetComponent<SpriteRenderer>());
                }

                if (i == 0 && j == 0)
                {
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText("/");
                }

                singleGridCell.transform.localScale = Vector3.one;
            }
        }

    }

    public void UpdateColor(float bmiValue, SpriteRenderer cellSprite)
    {
        if (bmiValue == 1f)
        {
            // label
            cellSprite.sprite = listOfCollors.Where(p => p.name == "BRIGHTBLUE").First();
        }
        else
        //var logger = GameObject.Find("androidLogger").GetComponent<TextMeshProUGUI>();
        if (bmiValue <= 18.5f)
        {
            // UNDERWEIGHT
            cellSprite.sprite = listOfCollors.Where(p => p.name == "BLUE").First();
            //  logText+="blue ";
            //  this.GetComponent<Image>().color = Color.blue;


        }
        else if (bmiValue <= 24.9f)
        {
            // NORMAL
            cellSprite.sprite = listOfCollors.Where(p => p.name == "GREEN").First();
            //    logText+="green ";
            //    this.GetComponent<Image>().color = Color.green;

        }
        else if (bmiValue <= 29.9f)
        {
            // OVERWEIGHT
            cellSprite.sprite = listOfCollors.Where(p => p.name == "YELLOW").First();
            //   logText+="yellow ";

            //    this.GetComponent<Image>().color = Color.yellow;
        }
        else if (bmiValue <= 34.9f)
        {
            // OBESE
            cellSprite.sprite = listOfCollors.Where(p => p.name == "RED").First();
            //   logText+="red ";

            //    this.GetComponent<Image>().color = Color.red;
        }
        else if (bmiValue >= 35f)
        {
            // EXTREMELYOBESE
            cellSprite.sprite = listOfCollors.Where(p => p.name == "PINK").First();
            //  logText+="pink ";

            //    this.GetComponent<Image>().color = Color.magenta;
        }
        //logger.SetText(logText);
    }

    public void GenerateCustomizedUserChart(float userHeight, float userWeight, int chartSize = 16, float weightInceraseRate = 2, float heightInceraseRate = 3)
    {

        double middleIndex = Math.Round(((chartSize - 1) / 2f)) + 1;

        startWeight = float.Parse((userWeight - (weightInceraseRate * (middleIndex - 1))).ToString());
        endWeight = float.Parse((userWeight + (weightInceraseRate * (middleIndex - 1))).ToString());
        //            print($"Start weight: {startWeight}, user weight = {userWeight}, end weight = {endWeight}");

        startHeight = float.Parse((userHeight - (heightInceraseRate * (middleIndex - 1))).ToString());
        endHeight = float.Parse((userHeight + (heightInceraseRate * (middleIndex - 1))).ToString());
        //          print($"Start Height: {startHeight}, user Height = {userHeight}, end Height = {endHeight}");

        float weight = startWeight;
        float height = startHeight;

        BMICalculator = GameObject.FindObjectOfType<BMICalculateScript>().GetComponent<BMICalculateScript>();
        for (int i = chartSize - 1; i >= 0; i--)
        {
            for (int j = 0; j < chartSize; j++)
            {
                height = startHeight + ((j - 1) * heightIncrementValue);
                weight = startWeight + ((i - 1) * weightIncrementValue);

                float BMI = BMICalculator.GetBMI(weight, height);
                var singleGridCell = Instantiate(GridCell);
                singleGridCell.transform.SetParent(this.transform);
                // singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText($"[i{i},j{j}]");
                // GENEROWANIE WARTOSCI W KOMÓRKACH
                if (BMI % 1 == 0f)
                {
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(BMI.ToString() + ",0");
                    UpdateColor(BMI, singleGridCell.GetComponent<SpriteRenderer>());
                }
                else
                {
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(BMI.ToString());
                    UpdateColor(BMI, singleGridCell.GetComponent<SpriteRenderer>());
                }

                // Sprawdzanie czy dana komorka jest Wynikiem i czy jest wazna do podwietlenia
                if(i == middleIndex-1 && j==middleIndex-1){
                    singleGridCell.GetComponent<CellScript>().IsSelected = true;
                    singleGridCell.GetComponent<CellScript>().IsImportant = true;
                }
                if(i== middleIndex-1 || j == middleIndex-1){
                    singleGridCell.GetComponent<CellScript>().IsImportant = true;
                }
                
                



                //GENEROWANIEETYKIET WAGI I WZROSTU NA OSIACH
                // Dol srodek, niewazny punkt
                if (i == 0 && j == 0)
                {
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText("/");
                    UpdateColor(1f, singleGridCell.GetComponent<SpriteRenderer>());
                    singleGridCell.GetComponent<CellScript>().IsImportant = true;

                }

                else if (j == 0)
                {
                    // OŚ WAGi (piowowa)
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(Mathf.Round((startWeight + (weightIncrementValue * (i - 1)))).ToString());
                    UpdateColor(1f, singleGridCell.GetComponent<SpriteRenderer>());
                    singleGridCell.GetComponent<CellScript>().IsImportant = true;

                    
                }
                else if (i == 0)
                {
                    // OŚ WYSOKOŚCI (POSIOMA)
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(Math.Round(Convert.ToDecimal((startHeight + (heightIncrementValue * (j - 1)))), 1).ToString());
                    UpdateColor(1f, singleGridCell.GetComponent<SpriteRenderer>());
                    singleGridCell.GetComponent<CellScript>().IsImportant = true;

                }


                singleGridCell.transform.localScale = Vector3.one;
            }
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
}
