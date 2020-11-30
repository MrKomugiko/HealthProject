using System;
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
    [SerializeField] List<Image> listOfDimBg;
    BMICalculateScript calculatorScript = null;
    void Start()
    {
        BMIValue = 25;
        parentSize = this.gameObject.GetComponent<RectTransform>().rect.size;
        startingPosition = new Vector2((parentSize.x / -2), (parentSize.y / -2));

DimmingAllBMISections();
    }
    enum BMIType
    {
        underweight,
        normal,
        overweight,
        obese,
        extremeObese
    }
       [SerializeField] float positionAdjustForScale;

    public void UpdateSimpleGraphForBmi(BMICalculateScript calculationResult)
    {
        Pointer.SetActive(true);
        BMIValue = calculationResult.RecentCalculatedBMIValue;
        Pointer.transform.localPosition = startingPosition;

        GetBMITypeBasedOnBMIValue(out bmiType, BMIValue);

        DimmingAllBMISections();

        float startPosition;
        float endPosition;

        switch (bmiType)
        {
            case BMIType.underweight:
                startPosition = startingPosition.x;
                positionAdjustForScale = sectionWidth*(BMIValue / 18.5f);

                Pointer.transform.localPosition = new Vector2(startPosition + (positionAdjustForScale), startingPosition.y);
                listOfDimBg.ElementAt(0).enabled = false;
                break;

            case BMIType.normal:
                startPosition = startingPosition.x + sectionWidth;
                positionAdjustForScale = sectionWidth*((BMIValue-18.5f) / (24.99f-18.5f));

                Pointer.transform.localPosition = new Vector2(startPosition + (positionAdjustForScale), startingPosition.y);
                listOfDimBg.ElementAt(1).enabled = false;
                break;

            case BMIType.overweight:
                startPosition = startingPosition.x + (2 * sectionWidth);
                positionAdjustForScale = sectionWidth*((BMIValue-24.99f) / (29.99f-24.99f));

                Pointer.transform.localPosition = new Vector2(startPosition + (positionAdjustForScale), startingPosition.y);
                listOfDimBg.ElementAt(2).enabled = false;
                break;

            case BMIType.obese:
                startPosition = startingPosition.x + (3 * sectionWidth);
                positionAdjustForScale = sectionWidth*((BMIValue-29.99f) / (34.99f-29.99f));

                Pointer.transform.localPosition = new Vector2(startPosition + (positionAdjustForScale), startingPosition.y);
                listOfDimBg.ElementAt(3).enabled = false;
                break;

            case BMIType.extremeObese:
                if (BMIValue > 40f) { BMIValue = 40f; }

                startPosition = startingPosition.x + (4 * sectionWidth);
                positionAdjustForScale =  sectionWidth*((BMIValue-35.99f) / (39.99f-34.99f));

                Pointer.transform.localPosition = new Vector2(startPosition + (positionAdjustForScale), startingPosition.y);
                listOfDimBg.ElementAt(4).enabled = false;
                break;
        }
    }

    private void DimmingAllBMISections()
    {
        foreach (var images in listOfDimBg)
        {
            images.enabled = true;
        }
    }

    private void GetBMITypeBasedOnBMIValue(out BMIType bmiType, float BMIValue)
    {
        if (BMIValue <= 18.5f) { bmiType = BMIType.underweight; }
        else if (BMIValue > 18.5 && BMIValue < 25) { bmiType = BMIType.normal; }
        else if (BMIValue >= 25 && BMIValue < 30) { bmiType = BMIType.overweight; }
        else if (BMIValue >= 30 && BMIValue < 35) { bmiType = BMIType.obese; }
        else { bmiType = BMIType.extremeObese; }
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
