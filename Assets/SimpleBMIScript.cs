using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SimpleBMIScript : MonoBehaviour
{
    [SerializeField] GameObject Pointer;
    [SerializeField] Vector2 parentSize;
    [SerializeField] Vector2 startingPosition;
    [SerializeField] float BMIValue;
    [SerializeField] float sectionWidth = 216;
    [SerializeField] BMIType bmiType;
    void Start()
    {
        BMIValue = 25;
        parentSize = this.gameObject.GetComponent<RectTransform>().rect.size;
        startingPosition = new Vector2((parentSize.x / -2), (parentSize.y / -2));

        //every dim background should be turn off in first use
        List<Image> listOfDimBg = GameObject.FindObjectsOfType<Image>().Where(p => p.name == "DarkBackground_off").ToList();
        foreach (var background in listOfDimBg)
        {
            background.enabled = false;
        }

        bmiType = BMIType.normal;
    }
    enum BMIType
    {
        underweight,
        normal,
        overweight,
        obese,
        extremeObese
    }
    public void UpdateSimpleGraphForBmi(BMICalculateScript calculationResult)
    {
        BMIValue = calculationResult.RecentCalculatedBMIValue;
        Pointer.transform.localPosition = startingPosition;

        if (BMIValue < 18.5f) { bmiType = BMIType.underweight; }
        else if (BMIValue > 18.5 && BMIValue < 25) { bmiType = BMIType.normal; }
        else if (BMIValue >= 25 && BMIValue < 30) { bmiType = BMIType.overweight; }
        else if (BMIValue >= 30 && BMIValue < 35) { bmiType = BMIType.obese; }
        else if (BMIValue >= 35) { bmiType = BMIType.extremeObese; }

        switch (bmiType)
        {
            case BMIType.underweight:
                Pointer.transform.localPosition = new Vector2(startingPosition.x, startingPosition.y);
                break;

            case BMIType.normal:
                Pointer.transform.localPosition = new Vector2(startingPosition.x + sectionWidth, startingPosition.y);
                break;

            case BMIType.overweight:
                Pointer.transform.localPosition = new Vector2(startingPosition.x + (2 * sectionWidth), startingPosition.y);
                break;

            case BMIType.obese:
                Pointer.transform.localPosition = new Vector2(startingPosition.x + (3 * sectionWidth), startingPosition.y);
                break;

            case BMIType.extremeObese:
                Pointer.transform.localPosition = new Vector2(startingPosition.x + (4 * sectionWidth), startingPosition.y);
                break;
        }
    }
    /*
    Setting ranges of pointer move depend of X localisation and bmi types

    1 - underweight       <18.5)
    2 - normal          (18.5 - 25.0)
    3 - overweight      (25.0 - 30.0)
    4 - obese           (30.0 - 35.0)
    5 - extreme obese    >35.0
    */
}
