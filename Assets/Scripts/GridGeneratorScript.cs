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
    [SerializeField] int chartSize = 15;
    [SerializeField] float startHeight = 150;
    [SerializeField] float endHeight = 200;
    float heightIncrementValue => (endHeight-startHeight)/chartSize;
    [SerializeField] float startWeight = 50;
    [SerializeField] float endWeight = 120;
    float weightIncrementValue => (endWeight-startWeight)/chartSize;
    //string logText= "";
    void Start()
    {
        BMICalculator = GameObject.FindObjectOfType<BMICalculateScript>().GetComponent<BMICalculateScript>();
        for (int i = chartSize; i > 0; i--)
        {
            for (int j = 0; j < chartSize; j++)
            {
                float BMI = BMICalculator.GetBMI((startWeight+(weightIncrementValue*i)),(startHeight+(heightIncrementValue*j)));
                var singleGridCell = Instantiate(GridCell);
                singleGridCell.transform.SetParent(this.transform);
               // singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText($"[i{i},j{j}]");
                if(BMI%1 == 0f)
                {
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(BMI.ToString()+",0");
                }
                else
                {
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(BMI.ToString());
                }

                singleGridCell.transform.localScale = Vector3.one;
                UpdateColor(BMI,singleGridCell.GetComponent<SpriteRenderer>());
            }
        }

    }

    public void UpdateColor(float bmiValue, SpriteRenderer cellSprite)
    {
        var logger = GameObject.Find("androidLogger").GetComponent<TextMeshProUGUI>();
        if (bmiValue <= 18.5f)
        {
            // UNDERWEIGHT
            cellSprite.sprite = listOfCollors.Where(p=>p.name == "BLUE").First();
            //logText+="blue ";
          //  this.GetComponent<Image>().color = Color.blue;


        }
        else if (bmiValue <= 24.9f)
        {
            // NORMAL
            cellSprite.sprite = listOfCollors.Where(p=>p.name == "GREEN").First();
            //logText+="green ";
        //    this.GetComponent<Image>().color = Color.green;

        }
        else if (bmiValue <= 29.9f)
        {
            // OVERWEIGHT
            cellSprite.sprite =listOfCollors.Where(p=>p.name == "YELLOW").First();
            //logText+="yellow ";
        
         //    this.GetComponent<Image>().color = Color.yellow;
        }
        else if (bmiValue <= 34.9f)
        {
            // OBESE
            cellSprite.sprite = listOfCollors.Where(p=>p.name == "RED").First();
            //logText+="red ";

        //    this.GetComponent<Image>().color = Color.red;
        }
        else if (bmiValue >= 35f)
        {
            // EXTREMELYOBESE
            cellSprite.sprite = listOfCollors.Where(p=>p.name == "PINK").First();
            //logText+="pink ";

        //    this.GetComponent<Image>().color = Color.magenta;
        }
       // logger.SetText(logText);
    }
}
