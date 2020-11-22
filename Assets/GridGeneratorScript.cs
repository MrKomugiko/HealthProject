using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridGeneratorScript : MonoBehaviour
{
    public BMICalculateScript BMICalculator;
    [SerializeField] GameObject GridCell;
    [SerializeField] int chartSize = 15;

    [SerializeField] float startHeight = 150;
    [SerializeField] float endHeight = 200;
    float heightIncrementValue => (endHeight-startHeight)/chartSize;
    [SerializeField] float startWeight = 50;
    [SerializeField] float endWeight = 120;
    float weightIncrementValue => (endWeight-startWeight)/chartSize;

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
                    print(BMI);
                }
                else
                {
                    singleGridCell.GetComponentInChildren<TextMeshProUGUI>().SetText(BMI.ToString());
                }

                singleGridCell.transform.localScale = Vector3.one;
            }
        }
    }
}
